using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> civilians = new List<GameObject>();
    public List<GameObject> enemies = new List<GameObject>();
    void Start()
    {
        //var civs = FindObjectsOfType<CivilianScript>();
        //foreach (var civ in civs) {
        //    civilians.Add(civ.gameObject);
        //}
    }

    public void UpdateCivilians() {
        civilians.Clear();
        var civs = new List<GameObject>();
        var civs2 = FindObjectsOfType<CivilianScript>();
        foreach (var civ in civs2)
        {
            civs.Add(civ.gameObject);
        }
        if (civs == null) {
            Debug.Log("no civilians");
            Debug.Break();
        }
        for (int i = 0; i < civs.Count; i++) {
            civilians.Add(civs[i]);
        }
        print("civilians updated");
    }

    public GameObject GetNearestCiv(Vector3 enemyPos) {
        var tempList = new List<Vector3>();
        float shortestDist = 999f;
        var index = 0;
        for (var i = 0; i < civilians.Count; i++) {
            tempList.Add(civilians[i].transform.position);
        }
        for (int i = 0; i < tempList.Count; i++) { 
            if (Vector3.Distance(enemyPos, tempList[i]) + (civilians[i].GetComponent<CivilianScript>().enemiesComing.Count * 3) < shortestDist) {
                shortestDist = Vector3.Distance(enemyPos, tempList[i]) + (civilians[i].GetComponent<CivilianScript>().enemiesComing.Count * 3);
                index = i;
            }
        }
        print("nearest civ run" + civilians[index]);
        return civilians[index];
    }
}
