using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadsController : MonoBehaviour
{
    
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        transform.position += new Vector3(0, 0, transform.GetChild(1).GetComponent<Renderer>().bounds.size.z * 3);
    }
}
