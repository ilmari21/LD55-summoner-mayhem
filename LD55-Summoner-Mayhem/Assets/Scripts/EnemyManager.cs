using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> civilians = new List<GameObject>();
    void Start()
    {
        var civs = FindObjectsOfType<CivilianScript>();
        foreach (var civ in civs) {
            civilians.Add(civ.gameObject);
        }
    }

    public void UpdateCivilians() {
        for (int i = 0; i < civilians.Count; i++) {
            if (civilians[i] == null) {
                civilians.RemoveAt(i);
            }
        }
        var civs = FindObjectsOfType<CivilianScript>();
        for (int i = 0; i < civilians.Count; i++) {
            if (civilians.Contains(civs[i].gameObject)) {
                continue;
            } else {
                civilians.Add(civs[i].gameObject);
            }
        }
    }

    public Vector3 GetNearestCiv(Vector3 enemyPos) {
        var tempList = new List<Vector3>();
        float shortestDist = 999f;
        var index = 0;
        for (var i = 0; i < civilians.Count; i++) {
            tempList.Add(civilians[i].transform.position);
        }
        for (int i = 0; i < tempList.Count; i++) { 
            if (Vector3.Distance(enemyPos, tempList[i]) < shortestDist) {
                shortestDist = Vector3.Distance(enemyPos, tempList[i]);
                index = i;
            }
        }
        return tempList[index];
    }
}
