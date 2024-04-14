using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionMover : MonoBehaviour
{
    [SerializeField]
    float minionSpeed;

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

        transform.SetParent(GameObject.Find("MinionFolder").transform);

    }

    void Update()
    {
        var fixPos = new Vector3(transform.position.x, transform.position.y, 0);
        transform.position = fixPos;
    }
}
