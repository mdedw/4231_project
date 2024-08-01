using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public Transform player_transform;
    public Vector2 rotate;
    [SerializeField] public Animator player_animator;
    private Vector3 inputDirection;
   
    
    private float player_speed;
    private float normal_height;
    private float cam_amount;
    private float current_health;
    private float max_health = 100.0f;
    private float lookSpeed;
    private int spaceCooldown = 0;
    private Quaternion plantRotate = new Quaternion(90, 0, 0, 90);
    private Quaternion plant2Rotate = new Quaternion(0, 0, 0, 0);
    

    // Start is called before the first frame update
    void Start()
    {

        player_animator = GetComponent<Animator>();

        player_speed = 0.015f;
        normal_height = 0.1f;
        lookSpeed = 5.0f;

        player_transform.position = new Vector3(0, normal_height, 0);

        cam_amount = 3.0f;

        current_health = 100.0f;
        updateHealth(0.0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        float current_x = player_transform.position.x;
        float current_z = player_transform.position.z;
        spaceCooldown--;

        MovePlayer();
        
        if (Input.GetKey(KeyCode.UpArrow)) {
            player_transform.position = new Vector3(current_x, normal_height, current_z + player_speed);
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            player_transform.position = new Vector3(current_x, normal_height, current_z - player_speed);
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            player_transform.position = new Vector3(current_x - player_speed, normal_height, current_z);
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            player_transform.position = new Vector3(current_x + player_speed, normal_height, current_z);
        }

        if (Input.GetKey(KeyCode.P)) {
            if (spaceCooldown < 1) {
                if (GameManager.instance.seedAmount > 0) {
                    Instantiate(GameManager.instance.plant1Prefab, player_transform.position, plantRotate);
                    spaceCooldown = 50;
                    GameManager.instance.seedAmount--;
                }
                GUI_manager.instance.SetSeedDisplay();
            }
        }

        if (Input.GetKey(KeyCode.L)) {
            if (spaceCooldown < 1) {
                if (GameManager.instance.seed2Amount > 0) {
                    Instantiate(GameManager.instance.plant2Prefab, player_transform.position, plant2Rotate);
                    spaceCooldown = 50;
                    GameManager.instance.seed2Amount--;
                }
                GUI_manager.instance.SetSeedDisplay();
            }

        }

        if (Input.GetKey(KeyCode.M)) {
            if (spaceCooldown < 1) {
                if (GameManager.instance.seed3Amount > 0) {
                    Instantiate(GameManager.instance.plant3Prefab, player_transform.position, Quaternion.identity);
                    spaceCooldown = 50;
                    GameManager.instance.seed3Amount--;
                }
                GUI_manager.instance.SetSeedDisplay();
            }

        }

        if (Input.GetKey(KeyCode.Space)) {
            if (spaceCooldown < 1) {
                player_animator.SetTrigger("attack");
                Instantiate(GameManager.instance.projectilePrefab, player_transform.position, Quaternion.identity);
                spaceCooldown = 50;
            }

        }
        if (Input.GetKey(KeyCode.Q)) {
            Application.Quit();
            Debug.Log("Player quit");
        }
        if (current_health <= 0) {
            GameManager.instance.GameOver();
        }  
    }


    private void OnTriggerEnter (Collider other) {
        if (other.tag == "enemy") {
        updateHealth(-3.0f);
        //knockback
        player_transform.position += (GameManager.instance.crystalTransform.position - player_transform.position).normalized * 2.1f;
        }
        if (other.tag == "enemy2") {
        updateHealth(-5.0f);
        //knockback
        player_transform.position += (GameManager.instance.crystalTransform.position - player_transform.position).normalized * 2.1f;
        }
        if (other.tag == "enemy3") {
        updateHealth(-8.0f);
        player_transform.position += (GameManager.instance.crystalTransform.position - player_transform.position).normalized * 2.1f;
        }
    }


    public void OnTriggerStay(Collider other) {
        if (other.tag == "plant3") {
            if (current_health < max_health) {
                updateHealth(0.5f);
            }
        }
    }


    private void OnTriggerExit (Collider other) {
        if (other.tag == "border") {
            player_transform.position += (GameManager.instance.crystalTransform.position - player_transform.position).normalized * 3.1f;
        }
    }


    private void MovePlayer() {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        inputDirection = new Vector3(h, 0, v) + player_transform.position;

        if (h != 0 || v != 0) {
            
            Vector3 toFaceDirection = inputDirection - player_transform.position;

            Quaternion targetRotation = Quaternion.LookRotation(toFaceDirection);

            player_transform.rotation = Quaternion.Lerp(player_transform.rotation, targetRotation, (lookSpeed * Time.deltaTime));
        }

        float speedValue = Mathf.Max(Mathf.Abs(h), Mathf.Abs(v));

        player_animator.SetFloat("speed", speedValue);
    }


    public void updateHealth(float value) {
        current_health += value;
        if (current_health < 0.1f) {
            print("dead");
        }
        if (current_health > max_health) {
            current_health = max_health;
        }
        GUI_manager.instance.updateHealthBar(current_health / max_health);
    }
}
