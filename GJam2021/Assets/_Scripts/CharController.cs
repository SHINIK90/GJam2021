using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public Transform body;
    // Start is called before the first frame update
    void Start(){
        body = transform.Find("Body");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)){
            body.localScale = new Vector3(-1f,body.localScale.y, body.localScale.z);
            transform.position = transform.position + new Vector3(-1f * movementSpeed * Time.deltaTime, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.D)){
            body.localScale = new Vector3(1f,body.localScale.y, body.localScale.z);
            transform.position = transform.position + new Vector3(1f * movementSpeed * Time.deltaTime, 0f, 0f);
        }
    }
}
