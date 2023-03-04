using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class EnemyGeneration : MonoBehaviour
{
    [SerializeField] private Goblin goblinPrefab;
    [SerializeField] private Orc orcPrefab;

    private float xMin;
    private float xMax;
    void Start()
    {
        //goblinPrefab = GameObject.Find("Goblin");
        //orcPrefab = GameObject.Find("Orc");

        StartCoroutine(SpawnObjects(goblinPrefab, 10, 2));
        StartCoroutine(SpawnObjects(orcPrefab, 5, 2));
    }

    IEnumerator SpawnObjects(Enemy enemy, int enemyAmount, int delay)
    {
        for (int i = 0; i < enemyAmount; i++)
        {
            Instantiate(enemy, GetRandomPositionX(), Quaternion.identity);

            yield return new WaitForSeconds(delay);
        }
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
