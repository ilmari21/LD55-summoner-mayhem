using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionMover : MonoBehaviour
{
    [SerializeField]
    float minionSpeed;

    public GameObject target;

    Rigidbody2D rb;

    NavMeshAgent agent;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        agent = GetComponent<NavMeshAgent>();

        if (target == null) 
        { 
            target = GameObject.Find("Character");
        }
    }

    void Update()
    {
        agent.SetDestination(target.transform.position);
        //rb.velocity = (target.transform.position - transform.position) * minionSpeed;
    }
}
