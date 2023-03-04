using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControl : MonoBehaviour
{
    private float x = 0f;
    private float y = 0f;

    private const int minCamSize = 7;
    private const int maxCamSize = 15;
    private int camSize = 15;

    [SerializeField] private float cameraSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x = Gamepad.current.rightStick.x.ReadValue();
        y = Gamepad.current.rightStick.y.ReadValue();

        transform.Translate(x * Time.deltaTime * cameraSpeed, y * Time.deltaTime * cameraSpeed, 0f);

        if (Gamepad.current.rightShoulder.wasPressedThisFrame)
        {
            if (camSize + 1 < maxCamSize)
            {
                camSize++;
            }
            Camera.main.orthographicSize = camSize;
        }
        else if (Gamepad.current.leftShoulder.wasPressedThisFrame)
        {
            if (camSize - 1 > minCamSize)
            {
                camSize--;
            }
            Camera.main.orthographicSize = camSize;
        }
    }
}
