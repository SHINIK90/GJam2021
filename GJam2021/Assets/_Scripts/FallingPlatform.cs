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

    // Update is called once per frame
    void Update()
    {
        //transform.position = transform.position + new Vector3(0f, -1f * fallingSpeed * Time.deltaTime, 0f);
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
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Invoke("DropPlatform", 0.5f);
            //Destroy(gameObject, 2f);
        }
    }*/
}
