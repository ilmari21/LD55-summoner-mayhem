using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilianScript : MonoBehaviour, IDamageable
{
    [SerializeField] int staringHealth;
    int health;
    public List<GameObject> enemiesComing = new List<GameObject>();
    EnemyManager enemyManager;
    GameManager gameManager;

    void Awake () 
    { 
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        Invoke("SetColliderOn", 5f);
    }

    void SetColliderOn()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        enemyManager = FindObjectOfType<EnemyManager>();
        health = staringHealth;
        enemyManager.civilians.Add(gameObject);
    }

    void Update()
    {
        if (health <= 0) {
            print("Game Over");
            enemyManager.civilians.Remove(gameObject);
            enemyManager.UpdateCivilians();
            Destroy(gameObject);
            gameManager.GameOver();
        }

        for (int i = 0; i < enemiesComing.Count; i++)
        {
            if (enemiesComing[i] == null) 
            { 
                enemiesComing.RemoveAt(i);
            }
        }
    }

    public void Damage(int damage) {
        health -= damage;
    }

}
