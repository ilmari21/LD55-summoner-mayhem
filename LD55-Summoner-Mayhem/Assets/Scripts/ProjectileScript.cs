using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int damage;
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.GetComponent<IDamageable>() != null) {
            var enemy = coll.gameObject.GetComponent<IDamageable>();
            enemy.Damage(damage);
        }
        Destroy(gameObject);
    }
}
