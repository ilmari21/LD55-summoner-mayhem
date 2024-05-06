using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteOrientation : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRend;

    void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        print(spriteRend);
    }

    void Update()
    {
        transform.rotation = Quaternion.identity;
        if (transform.rotation.z >= 0)
        {
            print(transform.rotation.z);
            SetSpriteFlip(true);
        }
    }

    void SetSpriteFlip(bool flipped)
    {
        spriteRend.flipX = flipped;
    }
}
