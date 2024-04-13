using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonerScript : MonoBehaviour
{
    public GameObject spawnPrefab;
    public List<GameObject> spawnList = new List<GameObject>();
    float spawnInterval = 2f;
    float spawnTimer = 0f;
    public Transform minionsFolder;


    void Awake()
    {
        if (spawnPrefab == null) 
        {
            print("no prefab");
        }
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > spawnInterval)
        {
            var newMinion = Instantiate(spawnPrefab);
            newMinion.transform.parent = minionsFolder;
            newMinion.transform.position = this.transform.position;
            spawnTimer = 0;
        }
    }
}
