using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float moveSpeed;
    Vector3 playerStartPos;

    void Start()
    {
        playerStartPos = transform.position;
        rb = GetComponent<Rigidbody2D>(); 
    }

    void FixedUpdate()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");
        var move = new Vector2 (xInput, yInput);
        rb.velocity = move * moveSpeed;
        var mouseCoords = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var lookVector = new Vector3(mouseCoords.x, mouseCoords.y, 0);
        transform.up = lookVector - transform.position;
    }

    public void ResetPlayer() {
        transform.position = playerStartPos;
    }
}
