using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionAttack : MonoBehaviour
{
    [SerializeField] int damage;

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.GetComponent<IDamageable>() != null) {
            var enemy = coll.gameObject.GetComponent<IDamageable>();
            enemy.Damage(damage);
        }
    }

}
