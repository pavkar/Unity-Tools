using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TowerShootControl : MonoBehaviour
{

    [SerializeField] private ArrowControl ProjectilePrefab;
    [SerializeField] private Transform LaunchOffset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Gamepad.current.buttonSouth.wasPressedThisFrame)
        {
            Debug.Log("Pressed south");

            ProjectilePrefab.transform.rotation = transform.rotation;
            // TODO: when arrow is fired it is then a little bit smaller,
            // then it gradually goes bigger to give an idea that is going higher
            // then it starts going smaller again until it lands (stops) or hits something
            Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);
        }
    }
}
