using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharController : MonoBehaviour
{
    bool facingRight= true;
    float facingRightValue= 1f;
    public GameObject derecha, izquierda;
    Vector2 bullet;
    public float fireRate;
    float nextFire=0;
    public Image DashCooldownBar;
    public float movementSpeed = 20f;
    public Transform body;
    public Rigidbody rigidbody;
    public float jumpForce = 10f;
    public float dashForce = 10f;
    bool dashActive = false;
    bool dashRight = false;
    float time = 0;
    public float dashCooldown=2f;
    // Start is called before the first frame update
    void Start(){
        body = transform.Find("Body");
        rigidbody = transform.GetComponent<Rigidbody>();
        //jumpForce = 10f;
        //dashForce = 15f;
        time = dashCooldown;
    }

    // Update is called once per frame
    void FixedUpdate(){
        if (Input.GetKey(KeyCode.W) && rigidbody.velocity.y == 0){
            rigidbody.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
        //DASH
        //Debug.Log(time);
        DashCooldownBar.fillAmount = time / dashCooldown;
        time += Time.deltaTime;
        
        if(facingRight){facingRightValue = 1f;}else{facingRightValue = -1f;}

        if (Input.GetKey(KeyCode.Space) && time >= dashCooldown) {
            Debug.Log("DASH");
            rigidbody.AddForce(dashForce*facingRightValue, 0, 0, ForceMode.Impulse);
            time = 0;  
            dashActive = true;
            if(facingRightValue == 1){
                dashRight = true;
            }else{dashRight = false;}
        }
        if(time <= dashCooldown && dashActive){
            //rigidbody.velocity = new Vector3(rigidbody.velocity.x,0,0);
            if(Input.GetKey(KeyCode.A)  && dashRight|| Input.GetKey(KeyCode.D) && !dashRight){
                rigidbody.velocity = new Vector3(0,0,0);
                dashActive = false;
                Debug.Log("STOP DASH");
            }
        }
    }
    void Update()
    {

        //SISTEMA DE MOVIMIENTO
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
