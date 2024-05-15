using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public int defaultHealth;
    [SerializeField] int health;
    GameManager manager;
    PlayerController playerCon;
    [SerializeField] float invDuration;
    float timer = 0f;
    [SerializeField] Slider healthSlider;
    [SerializeField] Material hitMat;
    [SerializeField] float flickerTimer;
    bool flickerStarted;

    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        health = defaultHealth;
        playerCon = GetComponent<PlayerController>();
        hitMat.SetFloat("_hit", 0f);
    }

    void Update()
    {
        if (health <= 0) {
            manager.GameOver();
        }
        if (playerCon.invulnerable == true) {
            timer += Time.deltaTime;
            if (flickerStarted == false) {
                StartFlicker();
            }
            if (timer >= invDuration) {
                playerCon.invulnerable = false;
                hitMat.SetFloat("_hit", 0f);
                flickerStarted = false;
                timer = 0f;
            }
        }
    }

    void StartFlicker() {
        flickerStarted = true;
        hitMat.SetFloat("_hit", 1.1f);
        Invoke("EndFlicker", flickerTimer);
    }

    void EndFlicker() {
        hitMat.SetFloat("_hit", 0f);
        if (playerCon.invulnerable == true) {
            Invoke("StartFlicker", flickerTimer);
        }
    }

    public void Damage(int damage) {
        if (playerCon.invulnerable == false) {
            health -= damage;
            AudioFW.Play("PlayerTakesDmg");
            UpdateHealthBar();
        }
    }

    public void ResetHp() {
        health = defaultHealth;
    }

    public void UpdateHealthBar() {
        healthSlider.value = health;
    }

}
