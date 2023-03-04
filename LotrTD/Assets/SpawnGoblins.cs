using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGoblins : MonoBehaviour
{
    [SerializeField] private GoblinMovement GoblinPrefab;

    private float x0 = 0f;
    private float x1 = 0f;
    private float y0 = 0f;
    private float y1 = 0f;

    private float spawnTime = 0f;
    private float randomInterval = 0f;

    // Start is called before the first frame update
    void Start()
    {
        var r = GetComponent<Renderer>();
        if (r == null)
            return;

        Bounds bounds = r.bounds;
        Debug.Log("Center of box: " + bounds.center);
        Debug.Log("Box x size: " + bounds.size.x);
        Debug.Log("Box y size: " + bounds.size.y);

        x0 = bounds.center.x - bounds.size.x / 2;
        x1 = bounds.center.x + bounds.size.x / 2;

        y0 = bounds.center.y + bounds.size.y / 2;
        y1 = bounds.center.y - bounds.size.y / 2;

        Debug.Log(string.Format("topleft ({0},{1}), topright ({2},{3}), botleft ({4},{5}), botright ({6},{7})", 
            x0, y0, x1, y0, x0, y1, x1, y1));

    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTime + randomInterval <= Time.time)
        {
            float randomX = Random.Range(x0, x1);
            float randomY = Random.Range(y0, y1);

            // TODO: goblin could have different height, width, speed, health depends on width and height etc.
            // damage depends on size also etc.
            Instantiate(GoblinPrefab, new Vector3(randomX, randomY, 1), transform.rotation);

            spawnTime = Time.time;
            randomInterval = Random.Range(0.5f, 5f);
        }
    }
}
