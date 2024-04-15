using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinPlayers : MonoBehaviour
{
    public GameObject player;
    public GameObject animation;

    void Update()
    {
        animation.transform.position = player.transform.position;
    }
}
