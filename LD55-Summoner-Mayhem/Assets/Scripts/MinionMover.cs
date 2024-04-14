using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionMover : MonoBehaviour
{

    GameObject target;

    NavMeshAgent agent;

    EnemyManager enemyManager;

    private void Awake()
    {
        enemyManager = FindObjectOfType<EnemyManager>();

        enemyManager.enemies.Add(gameObject);

        agent = GetComponent<NavMeshAgent>();

        target = enemyManager.GetNearestCiv(transform.position);

        target.GetComponent<CivilianScript>().enemiesComing.Add(gameObject);

        agent.SetDestination(target.transform.position);

    }

    void Update()
    {
        var fixPos = new Vector3(transform.position.x, transform.position.y, 0);
        transform.position = fixPos;
    }
}
