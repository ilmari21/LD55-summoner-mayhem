using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonerScript : MonoBehaviour
{
    public GameObject spawnPrefab;
    public List<GameObject> spawnList = new List<GameObject>();
    public int maxMinions = 10;
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
        if (spawnTimer > spawnInterval && spawnList.Count < maxMinions)
        {
            var spawnPos = new Vector3(transform.position.x, transform.position.y + 1);
            var newMinion = Instantiate(spawnPrefab, spawnPos, Quaternion.identity);
            newMinion.transform.parent = minionsFolder;
            spawnList.Add(newMinion);
            spawnTimer = 0;
        }
    }
}
