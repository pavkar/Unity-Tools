using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{
    public GameObject entityPrefab;
    public int numEntities = 10;
    public float xMin = -15f;
    public float xMax = 15f;
    public string objectName = "Enemy";

    public static bool isEnemyGenerated = false;

    void Start()
    {
        GameObject enemyObject = GameObject.Find(objectName);
        if (enemyObject != null && !isEnemyGenerated)
        {
            for (int i = 0; i < numEntities; i++)
            {
                Vector3 position = new Vector3(UnityEngine.Random.Range(xMin, xMax), 0f, 0f);

                Instantiate(enemyObject, position, enemyObject.transform.rotation);
            }
            isEnemyGenerated = true;
        }
        else
        {
            Debug.LogError("Object named " + objectName + " not found!");
        }


    }
}
