using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree_script : MonoBehaviour
{

    private float current_tree_health;
    private float max_tree_health = 1000.0f;

    // Start is called before the first frame update
    void Start()
    {
        current_tree_health = 1000.0f;
        updateTreeHealth(0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (current_tree_health <= 0) {
            GameManager.instance.GameOver();
        }  
    }


    private void OnTriggerStay(Collider other) {
        if (other.tag == "enemy") {
            updateTreeHealth(-0.5f);
        }
        if (other.tag == "plant3") {
            if (current_tree_health < max_tree_health) {
                updateTreeHealth(0.5f);
            }
        }
    }


    public void updateTreeHealth(float value) {
        current_tree_health += value;
        if (current_tree_health < 0.1f) {
            print("GAME OVER");
        }
        GUI_manager.instance.updateTreeBar(current_tree_health / max_tree_health);
    }
}
