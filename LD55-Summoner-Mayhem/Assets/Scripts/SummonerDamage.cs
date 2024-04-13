using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonerDamage : MonoBehaviour, IDamageable
{
    [SerializeField] int defaultHealth;
    int health;
    GameManager manager;
    void Awake()
    {
        manager = FindObjectOfType<GameManager>();
        health = defaultHealth;
        manager.summoners.Add(gameObject);
    }

    void Update() {
        if (health <= 0) {
            manager.summoners.Remove(gameObject);
            Destroy(gameObject);
        }    
    }

    public void Damage(int damage) {
        health -= damage;
    }
}
