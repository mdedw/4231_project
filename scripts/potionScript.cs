using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potionScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       ParticleSystem ps = GetComponent<ParticleSystem>();
       ps.Play();
    }
}
