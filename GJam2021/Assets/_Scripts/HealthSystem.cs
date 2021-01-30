using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public Image HealthBar;
    public float CurrentHealth;
    public float MaxHealth;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.fillAmount = CurrentHealth / MaxHealth;
        if (Input.GetKeyDown(KeyCode.A)) {
            RecibirDaño(10);
        }
        if (CurrentHealth >= MaxHealth) {
            CurrentHealth = MaxHealth;
        }
        if (CurrentHealth <= 0) {
            //dead
        }
    }
    void RecibirDaño(float Damage) {
        CurrentHealth -= Damage;
    }
}
