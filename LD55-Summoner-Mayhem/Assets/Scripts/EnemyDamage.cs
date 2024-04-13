using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour, IDamageable
{
    [SerializeField] int defaultHealth;
    public int health;

    void Awake () {
        health = defaultHealth;
    }

    void Update() {
        if (health <= 0) {
            Destroy(transform.parent.gameObject);
        }    
    }

    public void Damage(int i) {
        health -= i;
     }
}
