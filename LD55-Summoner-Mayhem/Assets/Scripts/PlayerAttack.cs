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
    [SerializeField] int shootAtkDmg;
    [SerializeField] GameObject projectilePrefab;
    public bool canAttack = true;
    float attackTimer;
    LayerMask layerMask = 3;

    void Start()
    {
        usedWeapon = weapon.melee;
        attackTimer = defAtkSpeed;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (usedWeapon == weapon.melee) {
                canAttack = true;
                usedWeapon = weapon.shooting;
            } else if (usedWeapon == weapon.shooting) {
                canAttack = true;
                usedWeapon = weapon.melee;
            }
        }

        //if (Input.GetKeyDown(KeyCode.Mouse0) && canAttack) {
        //    if (usedWeapon == weapon.melee) {
        //        DefaultAttack(defAtkDmg, defAtkSpeed);
        //    } else if (usedWeapon == weapon.shooting) {
        //        ShootingAttack(shootAtkSpeed);
        //    }
        //}

        if (Input.GetKeyDown(KeyCode.Mouse0) && canAttack && usedWeapon == weapon.melee) {
            DefaultAttack(defAtkDmg, defAtkSpeed);
        } else if (Input.GetKey(KeyCode.Mouse0)) {
            ShootingAttack(shootAtkSpeed);
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
        //Instantiate(projectilePrefab, transform.position, transform.rotation);
        //attackTimer = speed;
        var hit = Physics2D.Raycast(transform.position, transform.up, 100, layerMask);
        if (hit.collider == null) {
            Debug.Log("Raycast hitting nothing");
            return;
        }
        print(hit.collider.gameObject);
        Debug.DrawRay(transform.position, transform.up * Vector3.Distance(transform.position, hit.collider.transform.position), Color.red, 1.0f);
        if (hit.collider.gameObject.layer == 7) {
            print("Shoot");
            print(hit.collider.gameObject);
            var enemyDamage = hit.collider.GetComponent<IDamageable>();
            enemyDamage.Damage(shootAtkDmg);
            attackTimer = speed;
            canAttack = false;
        }
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
