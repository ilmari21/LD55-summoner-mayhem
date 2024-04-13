using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilianScript : MonoBehaviour, IDamageable
{
    [SerializeField] int staringHealth;
    int health;

    public List<GameObject> enemies = new List<GameObject>();

    void Start()
    {
        health = staringHealth;
    }

    void Update()
    {
        if (health <= 0) {
            print("Game Over");
            Time.timeScale = 0;
            Destroy(gameObject);
        }
    }

    public void Damage(int damage) {
        health -= damage;
    }

}
