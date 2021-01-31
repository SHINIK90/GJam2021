using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("DropPlatform", 0.5f);
            //Destroy(gameObject, 2f);
        }
    }
    
    void DropPlatform()
    {
        rb.isKinematic = false;
        Destroy(gameObject, 2f);
    }
}
