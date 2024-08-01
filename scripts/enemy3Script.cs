using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy3Script : MonoBehaviour
{

    [SerializeField] private Transform enemy_transform;
    private Transform target;
    [SerializeField] public Animator enemy_animator;
    private float closeEnough;
    private float enemy_health;
    private float moveSpeed;
    
  
    // Start is called before the first frame update
    void Start()
    {
        enemy_health = 4.0f;
        closeEnough = 0.0f;
        moveSpeed = 1.6f;
        enemy_animator = GetComponent<Animator>();
        float current_x = enemy_transform.position.x;
        float current_y = enemy_transform.position.y;
        float current_z = enemy_transform.position.z;
        float randomAmount = Random.Range(-8, 8);
        enemy_transform.position = new Vector3(current_x += randomAmount, current_y, current_z);
        SetTarget(GameManager.instance.player_transform);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy_health < 0.0f) {
            enemyDeath();
        }
        MoveTowardsTarget();
        facePlayer();
    }


    private void enemyDeath() {
        float dropChance = Random.Range(-10, 10);
            if (dropChance > -5) {
                GameManager.instance.seed3Amount += 2;
            }
            GUI_manager.instance.SetSeedDisplay();
            GUI_manager.instance.ChangeScore(3);
            Destroy(gameObject);
    }
    

    private void SetTarget(Transform t) {
        target = t;
    }

    private void MoveTowardsTarget() {
        if (Vector3.Distance(enemy_transform.position, target.position) < closeEnough) {
            enemy_animator.SetFloat("speed", 0.0f);
            enemy_animator.SetTrigger("attack");
            enemy_animator.SetFloat("speed", 0.0f);
            //print("attack");
        } else {
        Vector3 towardsTarget = (target.position - enemy_transform.position).normalized;
        Vector3 moveAmount = (moveSpeed * towardsTarget * Time.deltaTime);
        enemy_transform.position += moveAmount;
    }

    }

    private void facePlayer() {
        if (target == null) {
            enemy_animator.SetFloat("speed", 0.0f);
        } else {

        enemy_animator.ResetTrigger("attack");
        enemy_animator.SetFloat("speed", 1.0f);
        
        Vector3 towardsPlayer = enemy_transform.position - GameManager.instance.player_transform.position;
        Vector3 towardsCrystal = enemy_transform.position - GameManager.instance.crystalTransform.position;
        if (towardsPlayer.magnitude < 5f) {
            SetTarget(GameManager.instance.player_transform);
        Quaternion targetRotation = Quaternion.LookRotation(towardsPlayer);
        
        enemy_transform.rotation = Quaternion.Lerp(enemy_transform.rotation, targetRotation, Time.deltaTime * 5f);
        } else {
            SetTarget(GameManager.instance.crystalTransform);
            Quaternion targetCrystal = Quaternion.LookRotation(towardsCrystal);
            enemy_transform.rotation = Quaternion.Lerp(enemy_transform.rotation, targetCrystal, Time.deltaTime * 5f);
        }
        }
    }


    private void OnTriggerEnter(Collider other) {
        if (other.tag == "player") {
            enemy_health -= 1.0f;
        }
        if (other.tag == "plant1") {
            //GetComponent<AudioSource>().Play();
            enemy_health -= 3.0f;
            enemy_transform.position += (enemy_transform.position - GameManager.instance.crystalTransform.position ).normalized * 2.3f;
        }
        if (other.tag == "projectile") {
            
            enemy_health -= 4.5f;
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.tag == "plant2") {
            enemy_health -= 0.06f;
            moveSpeed = 0.000001f;
        } else {
            moveSpeed = 1.7f;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "plant2") {
            moveSpeed = 1.7f; // goes faster because he's mad
        }
    }
}


