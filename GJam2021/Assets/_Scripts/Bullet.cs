using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speedX;
    float speedY = 0;
    Rigidbody rb;
    public float damage = 10;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speedX, speedY);
        Destroy(gameObject, 1.5f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemigo")
        {
            other.GetComponent<HealthSystem>().RecibirDaño(damage);
            Destroy(gameObject);
        }
    }
}
