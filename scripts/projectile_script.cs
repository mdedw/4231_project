using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile_script : MonoBehaviour
{

    [SerializeField] private Transform projectileTransform;
    [SerializeField] private Rigidbody projectileRigid;
    [SerializeField] private ParticleSystem ps;
    private Vector3 target;
    

    // Start is called before the first frame update
    void Start()
    {
        //projectileTransform = GameManager.instance.player_transform.position;
        projectileTransform.position = GameManager.instance.player_transform.position;
        //projectileTransform.position = GameManager.instance.player_transform.position;
        GetComponent<Rigidbody>().velocity = GameManager.instance.player_transform.forward * 7.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //projectileTransform.position = Vector3.Lerp(target, projectileTransform.position, 1);
    }


    private void OnTriggerEnter(Collider other) {
        if (other.tag == "enemy") {
            //GameManager.instance.potionEffect(projectileTransform.position.x, projectileTransform.position.y, projectileTransform.position.z);
            
            Destroy(gameObject);
        }
    }


    private void OnTriggerExit(Collider other) {
        if (other.tag == "border") {
            Destroy(gameObject);
        }
    }
}
