using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum PlayerState
{
    Idle,
    Moving
}

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float moveSpeed;
    [SerializeField] float knockBack;
    Vector3 playerStartPos;
    PlayerHealth playerHp;
    public bool invulnerable;
    public List<GameObject> enemiesComing = new List<GameObject>();

    public PlayerState playerState;

    void Start()
    {
        playerState = PlayerState.Idle;
        invulnerable = false;
        playerStartPos = transform.position;
        rb = GetComponent<Rigidbody2D>(); 
        playerHp = GetComponent<PlayerHealth>();
    }

    void FixedUpdate()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");
        var move = new Vector2 (xInput, yInput);
        //rb.velocity = move * moveSpeed;
        rb.AddForce (move.normalized * moveSpeed,ForceMode2D.Impulse);
        if (rb.velocity != Vector2.zero)
        {
            playerState = PlayerState.Moving;
        }
        else if (rb.velocity == Vector2.zero)
        {
            playerState = PlayerState.Idle;
        }
    }

    void Update() {
        var mouseCoords = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var lookVector = new Vector3(mouseCoords.x, mouseCoords.y, 0);
        transform.up = lookVector - transform.position;
    }

    public void ResetPlayer() {
        transform.position = playerStartPos;
        playerHp.ResetHp();
        playerHp.UpdateHealthBar();
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.layer == 7) {
            invulnerable = true;
            KnockBack(coll.transform.position);
        }
    }

    void KnockBack(Vector3 enemyPos) {
        var dir = transform.position - enemyPos;
        var dir2d = new Vector2(dir.x, dir.y);
        rb.AddForce(dir2d * knockBack, ForceMode2D.Impulse);
        print("knockback");
    }
}
