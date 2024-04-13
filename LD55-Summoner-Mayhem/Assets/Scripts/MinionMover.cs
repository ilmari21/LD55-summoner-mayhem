using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionMover : MonoBehaviour
{
    [SerializeField]
    float minionSpeed;

    Vector3 target;

    NavMeshAgent agent;

    EnemyManager enemyManager;

    private void Awake()
    {
        enemyManager = FindObjectOfType<EnemyManager>();

        agent = GetComponent<NavMeshAgent>();

        target = enemyManager.GetNearestCiv(transform.position);

        agent.SetDestination(target);

    }

    void Update()
    {
        var fixPos = new Vector3(transform.position.x, transform.position.y, 0);
        transform.position = fixPos;
    }
}
