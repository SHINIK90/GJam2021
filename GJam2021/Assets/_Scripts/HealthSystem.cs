using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public Image HealthBar;
    public float CurrentHealth;
    public float MaxHealth;
    public Animator enemy1Anim;
    float time = 0f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.fillAmount = CurrentHealth / MaxHealth;
        if (Input.GetKeyDown(KeyCode.X)) {
            RecibirDaño(10);
        }
        if (CurrentHealth >= MaxHealth) {
            CurrentHealth = MaxHealth;
        }
        if (CurrentHealth <= 0) {
            die();
        }
    }
    public void RecibirDaño(float Damage) {
        CurrentHealth -= Damage;
    }
    void die() {
        if (tag == "Player") {

        }
        else
        {
            enemy1Anim.SetTrigger("Die");
            time += Time.deltaTime;
            if(time >= 1.4f){
                Destroy(gameObject);
            }
            
        }
    }
}
