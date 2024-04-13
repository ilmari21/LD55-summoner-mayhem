using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionMover : MonoBehaviour
{
    [SerializeField]
    float minionSpeed;

    public GameObject target;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if (target == null) 
        { 
            target = GameObject.Find("Character");
        }
    }

    void Update()
    {
        rb.velocity = (target.transform.position - transform.position) * minionSpeed;
    }
}
