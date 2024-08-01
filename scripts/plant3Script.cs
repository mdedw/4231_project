using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plant3Script : MonoBehaviour
{
    
    
    private float plant_health;
    private Animator plant_animator;
    // Start is called before the first frame update
    void Start()
    {
        //Vector3 eulers = this.transform.rotation.eulerAngles;
        //this.transform.rotation = Quaternion.Euler(new Vector3(eulers.x, eulers.y, 180));
        //plant_animator = GetComponent<Animator>();
        plant_health = 100.0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (plant_health < 0.0f) {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter(Collider other) {
        if (other.tag == "enemy") {
            plant_health -= 50.0f;
        }
        if (other.tag == "enemy2") {
            plant_health -= 70.0f;
        }
        if (other.tag == "enemy3") {
            plant_health -= 100.0f;
        }
    }


    public void OnTriggerStay(Collider other) {
        if (other.tag == "player") {
            plant_health -= 5.0f;
        }
        if (other.tag == "tree") {
            plant_health -= 5.0f;
        }
    }
}
