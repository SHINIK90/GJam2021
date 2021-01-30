using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    bool facingRight=true;
    //SISTEMA DE DISPARO
    public GameObject derecha, izquierda;
    Vector2 bullet;
    public float fireRate;
    float nextFire=0;
    //--------

    public float movementSpeed = 20f;
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
            facingRight = false;
        }

        if (Input.GetKey(KeyCode.D)){
            body.localScale = new Vector3(1f,body.localScale.y, body.localScale.z);
            transform.position = transform.position + new Vector3(1f * movementSpeed * Time.deltaTime, 0f, 0f);
            facingRight = true;
        }
        //SISTEMA DE DISPARO
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            disparar();
        }
        //--------
    }
    void disparar() {
        bullet = transform.position;
        if (facingRight)
        {
            bullet += new Vector2(+1f, -0.40f);
            Instantiate(derecha, bullet, Quaternion.identity);
        }
        else {
            bullet += new Vector2(-1f, -0.40f);
            Instantiate(izquierda, bullet, Quaternion.identity);
        }
    }
}
