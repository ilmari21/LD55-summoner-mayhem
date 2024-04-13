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

    public List<GameObject> civilians;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        agent = GetComponent<NavMeshAgent>();

        var civs = FindObjectsOfType<CivilianScript>();

        foreach ( var civ in civs )
        {
            civilians.Add(civ.gameObject);
        }
    }

    void Update()
    {
        if (target == null)
        {
            FindTarget();
        }

        agent.SetDestination(target.transform.position);
        var fixPos = new Vector3(transform.position.x, transform.position.y, 0);
        transform.position = fixPos;
    }

    void FindTarget()
    {
        int index = -1;
        float shortestDistance = 999999999;
        for (int i = 0; i < civilians.Count; i++)
        {
            if (Vector3.Distance(transform.position, civilians[i].transform.position) < shortestDistance)
            {
                shortestDistance = Vector3.Distance(transform.position, civilians[i].transform.position);
                index = i;
            }
        }
        target = civilians[index];
    }
}
