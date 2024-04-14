using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public int defaultHealth;
    [SerializeField] int health;
    GameManager manager;
    PlayerController playerCon;
    [SerializeField] float invDuration;
    float timer = 0f;

    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        health = defaultHealth;
        playerCon = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (health <= 0) {
            manager.GameOver();
        }
        if (playerCon.invulnerable == true) {
            timer += Time.deltaTime;
            if (timer >= invDuration) {
                playerCon.invulnerable = false;
                timer = 0f;
            }
        }
    }

    public void Damage(int damage) {
        if (playerCon.invulnerable == false) {
            health -= damage;
        }
    }

    public void ResetHp() {
        health = defaultHealth;
    }

}
