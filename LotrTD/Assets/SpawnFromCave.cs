using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFromCave : MonoBehaviour
{
    [SerializeField] private GoblinMovement GoblinPrefab;
    private float spawnTime = 0f;
    private float randomInterval = 0f;

    private float spawnLocationX = 0f;
    private float spawnLocationY = 0f;
    // Start is called before the first frame update
    void Start()
    {
        var r = GetComponent<Renderer>();
        if (r == null)
            return;

        Bounds bounds = r.bounds;

        spawnLocationX = bounds.center.x;
        spawnLocationY = bounds.center.y;
        spawnTime = Time.time;
        randomInterval = Random.Range(1f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTime + randomInterval <= Time.time)
        {
            // TODO: goblin could have different height, width, speed, health depends on width and height etc.
            // damage depends on size also etc.
            Instantiate(GoblinPrefab, new Vector3(spawnLocationX, spawnLocationY, 1), transform.rotation);

            spawnTime = Time.time;
            randomInterval = Random.Range(1f, 10f);
        }
    }
}
