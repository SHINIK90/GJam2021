using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo1 : MonoBehaviour
{
    public Transform target;
    public float chaseSpeed = 10f;
    public float returnSpeed = 5f;
    public float minDistance = 1f;
    private float range;
    public Vector2 Origin;

    private void Start()
    {
        Origin = transform.position;
    }
    void Update()
    {
        range = Vector2.Distance(transform.position, target.position);

        if (range < minDistance)
        {
            Debug.Log(range);

            transform.position = Vector2.MoveTowards(transform.position, target.position, chaseSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, Origin, returnSpeed * Time.deltaTime);
        }
    }
}
