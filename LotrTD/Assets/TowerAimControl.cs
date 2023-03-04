using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TowerAimControl : MonoBehaviour
{
    private float x = 0f;
    private float y = 0f;
    private float prevAngle = 0f;
    private float angle = 0f;
    private float xZero = 0f;
    private float yZero = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Im printing to the console2");

        // Show all gamepads in the system.
        Debug.Log(string.Join("\n", Gamepad.all));

    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Iput get axis horizontal and vertical?
        x = Gamepad.current.leftStick.x.ReadValue();
        y = Gamepad.current.leftStick.y.ReadValue();

        angle = 0;
        if (x == xZero && y == yZero)
        {
            angle = prevAngle;
        }
        else if (x >= 0)
        {
            angle = Mathf.Atan(y / x);
            angle *= Mathf.Rad2Deg;
            angle -= 90;
            prevAngle = angle;
        }
        else
        {
            angle = Mathf.Asin(y / Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2)));
            angle *= Mathf.Rad2Deg;

            if (y > 0)
            {
                angle = -360 + (90 - angle);
            }
            else
            {
                angle = (-angle - 270);
            }
            prevAngle = angle;
        }

        transform.rotation = Quaternion.Euler(xZero, yZero, angle);
    }
}
