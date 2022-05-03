using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Animal : MonoBehaviour
{
    [SerializeField] protected float speed;

    int range = 5;

    float nextActionTime;
    float period = 10f;


    public void Update()
    {
        Move(); // ABSTRACTION
    } 

    protected virtual void Move()
    {
        if (Time.time > nextActionTime)
        {
            Vector3 position = transform.position;

            Vector3 offset = new Vector3(Random.Range(-range, range), Random.Range(-range, range), Random.Range(-range, range));

            GetComponent<NavMeshAgent>().SetDestination(position + offset);

            nextActionTime = Time.time + period;
        }
    }

    public virtual void Action()
    {

    }
}
