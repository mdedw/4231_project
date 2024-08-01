using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plant2_script : MonoBehaviour
{
   private float plant_health;
   [SerializeField] private Transform plant2Transform;
    // Start is called before the first frame update
    void Start()
    {
        plant2Transform = GetComponent<Transform>();
        plant_health = 8.0f;
        plant2Transform.position = new Vector3(plant2Transform.position.x, 0.1f, plant2Transform.position.z);
        
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
            plant_health -= 1.0f;
        }
        if (other.tag == "enemy2") {
            plant_health -= 3.0f;
        }
        if (other.tag == "enemy3") {
            plant_health -= 5.0f;
        }
    }
}

