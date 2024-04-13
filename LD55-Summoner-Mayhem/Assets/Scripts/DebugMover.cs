using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMover : MonoBehaviour
{
    public GameObject character;

    [SerializeField]
    float speed;

    void Awake()
    {
        
    }

    void FixedUpdate()
    {
        {
            float horizontal = Input.GetAxis("Horizontal");
            var deltaH = speed * horizontal * Vector3.right * Time.deltaTime;
            transform.position += deltaH;

            float vertical = Input.GetAxis("Vertical");
            var deltaV = speed * vertical * Vector3.up * Time.deltaTime;
            transform.position += deltaV;
        }
    }
}
