using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour, IDamageable
{
    [SerializeField] int defaultHealth;
    EnemyManager manager;
    public int health;

    void Awake () {
        manager = FindObjectOfType<EnemyManager>();
        health = defaultHealth;
    }

    void Update() {
        if (health <= 0) {
            manager.enemies.Remove(gameObject);
            Destroy(transform.parent.gameObject);
        }    
    }

    public void Damage(int i) {
        health -= i;
     }
}
