using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo1 : MonoBehaviour
{
    public GameObject player;
    public Transform target;
    public float chaseSpeed = 10f;
    public float returnSpeed = 5f;
    public float minDistance = 1f;
    public float attackDistance = 1f;
    public float damage = 10f;
    private float range;
    public Vector3 Origin;
    private float time=0;
    public float timeWithoutDamage = 2f;
    Vector3 temp;
    public bool stoppedFollow;

    private void Start()
    {
        Origin = transform.position;
        time = timeWithoutDamage;
    }
    void Update()
    {
        range = Vector2.Distance(transform.position, target.position);
        if (range < minDistance)
        {
            stoppedFollow = true;
            temp = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
            //transform.Translate(Vector2.MoveTowards(transform.position, target.position, range)*chaseSpeed*Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, temp, chaseSpeed * Time.deltaTime);
            if((transform.position.x - target.position.x) > 0){
                transform.localScale = new Vector3(-1.5f,transform.localScale.y, transform.localScale.z);
            }else{
                transform.localScale = new Vector3(1.5f,transform.localScale.y, transform.localScale.z);
            }
            if (range < attackDistance)
            {

                if (time < timeWithoutDamage) {
                    time += Time.deltaTime;
                }
                else
                {
                    Debug.Log("DAMAGE");
                    player.GetComponent<HealthSystem>().RecibirDaño(damage);
                    //target.GetComponent<HealthSystem>().RecibirDaño(damage);
                    time = 0;
                }
                
                
            }
            
        }
        else
        {
            if(stoppedFollow){
                transform.localScale = new Vector3(transform.localScale.x * -1,transform.localScale.y, transform.localScale.z);
                stoppedFollow = false;
            }
            transform.position = Vector2.MoveTowards(transform.position, Origin, returnSpeed * Time.deltaTime);
        }

    }
}
