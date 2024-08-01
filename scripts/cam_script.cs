using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam_script : MonoBehaviour
{

    public Transform cam_transform;
    public Transform player_transform;
    

    // Start is called before the first frame update
    void Start()
    {
        //float u = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        float current_x = player_transform.position.x;
        float current_y = player_transform.position.y;
        float current_z = player_transform.position.z;

        cam_transform.position = new Vector3(current_x, current_y + 3.4f, current_z - 6.0f);
        Vector3 towardsPlayer = GameManager.instance.player_transform.position - cam_transform.position;
        cam_transform.rotation = Quaternion.LookRotation(towardsPlayer);
    }
}
