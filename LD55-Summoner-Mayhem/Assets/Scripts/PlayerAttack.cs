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
    public bool canAttack = true;
    float attackTimer;
    EightWayMovingAnimation animationMover;

    void Start()
    {
        animationMover = GetComponent<EightWayMovingAnimation>();
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
            animationMover.animator.Play(animationMover.meleeAnimations[animationMover.publicSector]);
        } else if (Input.GetKey(KeyCode.Mouse0) && canAttack && usedWeapon == weapon.shooting) {
            ShootingAttack(shootAtkSpeed);
        }
        if (Input.GetKey(KeyCode.Mouse0) && usedWeapon == weapon.shooting) {
            AudioFW.PlayLoop("Gunfire");
        } else {
            AudioFW.StopLoop("Gunfire");
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
                AudioFW.Play("SwordHit");
            }
        } else {
            AudioFW.Play("SwordMiss");
        }
        attackTimer = speed;
        canAttack = false;
    }

    void ShootingAttack(float speed) {
        var scatterOffset = Random.Range(-10f, 10f);
        print(scatterOffset);
        var projectileRot = transform.rotation;
        projectileRot *= Quaternion.Euler(0f, 0f, scatterOffset);
        Instantiate(projectilePrefab, transform.position, projectileRot);
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
