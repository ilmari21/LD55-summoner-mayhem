using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilianScript : MonoBehaviour, IDamageable
{
    [SerializeField] int staringHealth;
    int health;
    public int enemiesComing;
    EnemyManager enemyManager;

    void Start()
    {
        enemyManager = FindObjectOfType<EnemyManager>();
        health = staringHealth;
    }

    void Update()
    {
        if (health <= 0) {
            print("Game Over");
            enemyManager.civilians.Remove(gameObject);
            enemyManager.UpdateCivilians();
            Destroy(gameObject);
        }
    }

    public void Damage(int damage) {
        health -= damage;
    }

}
