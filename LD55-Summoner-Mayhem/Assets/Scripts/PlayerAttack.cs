using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] BoxCollider2D attackColl;
    List<IDamageable> enemyList = new List<IDamageable>();
    enum weapon {melee, shooting}
    [SerializeField] weapon usedWeapon;
    [SerializeField] int defAtkDmg;
    [SerializeField] float defAtkSpeed;
    [SerializeField] float shootAtkSpeed;
    [SerializeField] GameObject projectilePrefab;
    bool canAttack = true;
    float attackTimer;

    void Start()
    {
        usedWeapon = weapon.melee;
        attackTimer = defAtkSpeed;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (usedWeapon == weapon.melee) {
                usedWeapon = weapon.shooting;
            } else if (usedWeapon == weapon.shooting) {
                usedWeapon = weapon.melee;
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && canAttack) {
            if (usedWeapon == weapon.melee) {
                DefaultAttack(defAtkDmg, defAtkSpeed);
            } else if (usedWeapon == weapon.shooting) {
                ShootingAttack(shootAtkSpeed);
            }
        }
        if (canAttack == false) {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0) {
                canAttack = true;
            }
        }
    }
    void DefaultAttack(int damage, float speed) {
        print("Default Attack");
        if (enemyList.Count > 0) {
            foreach (var enemy in enemyList) {
                enemy.Damage(damage);
            }
        }
        attackTimer = speed;
        canAttack = false;
    }

    void ShootingAttack(float speed) {
        print("Shoot");
        Instantiate(projectilePrefab, transform.position, transform.rotation);
        attackTimer = speed;
        canAttack = false;
    }


    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.GetComponent<IDamageable>() != null) {
            enemyList.Add(coll.GetComponent<IDamageable>());
        }
    }

    void OnTriggerExit2D(Collider2D coll) {
        if (coll.GetComponent<IDamageable>() != null) {
            enemyList.Remove(coll.GetComponent<IDamageable>());
        }
    }
}
