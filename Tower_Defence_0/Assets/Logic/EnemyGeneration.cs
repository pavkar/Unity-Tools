using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{
    public GameObject entityPrefab;
    public int numEntities = 10;
    public float xMin;
    public float xMax;
    public string objectName = "Enemy";

    public static bool isEnemyGenerated = false;

    void Start()
    {
        Instantiate(GenerateGoblin(), GetRandomPositionX(), Quaternion.identity);

        //if (goblin != null && !isEnemyGenerated)
        //{
        //    for (int i = 0; i < numEntities; i++)
        //    {
        //        Vector3 position = new Vector3(UnityEngine.Random.Range(xMin, xMax), 0f, 0f);

        //        Instantiate(enemyObject, position, enemyObject.transform.rotation);
        //    }
        //    isEnemyGenerated = true;
        //}
        //else
        //{
        //    Debug.LogError("Object named " + objectName + " not found!");
        //}


    }

    private Goblin GenerateGoblin()
    {
        GameObject goblinGameObject = new GameObject("Goblin");
        goblinGameObject.transform.position = GetRandomPositionX();

        goblinGameObject.AddComponent<SpriteRenderer>();
        goblinGameObject.AddComponent<BoxCollider2D>();
        goblinGameObject.AddComponent<Rigidbody2D>();

        return goblinGameObject.AddComponent<Goblin>();
    }

    private Vector3 GetRandomPositionX()
    {
        GameObject enemySpawn = GameObject.Find("EnemySpawn");

        xMin = enemySpawn.transform.position.x - (enemySpawn.transform.localScale.x / 2);
        xMax = enemySpawn.transform.position.x + (enemySpawn.transform.localScale.x / 2);

        Vector3 position = new Vector3(
            UnityEngine.Random.Range(xMin - 1, xMax - 1),
            enemySpawn.transform.position.y,
            0f);

        return position;
    }
}
