using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionMover : MonoBehaviour
{

    GameObject target;

    NavMeshAgent agent;

    EnemyManager enemyManager;

    bool targettingPlayer;

    PlayerController player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();

        enemyManager = FindObjectOfType<EnemyManager>();

        enemyManager.enemies.Add(gameObject);

        agent = GetComponent<NavMeshAgent>();

        target = enemyManager.GetNearestCiv(transform.position);

        if (target == player.gameObject)
        {
            targettingPlayer = true;
            target.GetComponent<PlayerController>().enemiesComing.Add(gameObject);
        }

        else
        {
            target.GetComponent<CivilianScript>().enemiesComing.Add(gameObject);
        }

        agent.SetDestination(target.transform.position);

    }

    void Update()
    {
        if (targettingPlayer)
        {
            agent.SetDestination(player.transform.position);
        }

        var fixPos = new Vector3(transform.position.x, transform.position.y, 0);
        transform.position = fixPos;
    }
}
