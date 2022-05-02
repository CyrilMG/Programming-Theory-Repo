using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5;

    [SerializeField] List<GameObject> playerCharacters;

    NavMeshAgent navMeshAgent;

    Animal target;

    Animator animator;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = speed;
        navMeshAgent.acceleration = 999;
        navMeshAgent.angularSpeed = 999;

    }

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var animal = hit.collider.GetComponentInParent<Animal>();

                if (animal != null)
                {
                    GoTo(animal);
                }
                else
                {
                    Goto(hit.point);
                }
            }
        }

        if (target != null)
        {
            float distance = Vector3.Distance(target.transform.position, transform.position);
            if (distance < 2.0f)
            {
                navMeshAgent.isStopped = true;
                AnimalInRange();
            }
        }

        animator.SetFloat("Speed_f", navMeshAgent.velocity == Vector3.zero ? 0 : 0.5f);
    }

    private void AnimalInRange()
    {
        if (target is Chicken)
        {

        }
        else if (target is Cow)
        {

        }
    }

    void GoTo(Animal newTarget)
    {
        target = newTarget;

        if (target != null)
        {
            navMeshAgent.SetDestination(target.transform.position);
            navMeshAgent.isStopped = false;
        }
    }

    void Goto(Vector3 position)
    {
        target = null;

        navMeshAgent.SetDestination(position);
        navMeshAgent.isStopped = false;
    }

    public void SetCharacter(string name)
    {
        foreach(GameObject character in playerCharacters)
        {
            character.SetActive(character.name == name);
        }
    }
}
