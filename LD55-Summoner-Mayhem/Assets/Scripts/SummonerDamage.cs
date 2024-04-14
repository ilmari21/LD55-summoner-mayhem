using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SummonerDamage : MonoBehaviour, IDamageable
{
    [SerializeField] int defaultHealth;
    int health;
    GameManager manager;
    public GameObject civilianPrefab;
    EnemyManager enemyManager;
    void Awake()
    {
        manager = FindObjectOfType<GameManager>();
        enemyManager = FindObjectOfType<EnemyManager>();
        health = defaultHealth;
        manager.summoners.Add(gameObject);
    }

    void Update() {
        if (health <= 0) {
            manager.summoners.Remove(gameObject);
            var newCiv = Instantiate(civilianPrefab, gameObject.transform.position, Quaternion.identity);
            enemyManager.civilians.Add(newCiv);
            Destroy(gameObject);
        }    
    }

    public void Damage(int damage) {
        health -= damage;
    }
}
