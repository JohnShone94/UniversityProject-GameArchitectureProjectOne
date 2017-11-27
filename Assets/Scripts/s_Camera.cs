//****** Donations are greatly appreciated.  ******
//****** You can donate directly to Jesse through paypal at  https://www.paypal.me/JEtzler   ******

using UnityEngine;
using System.Collections;

public class s_Camera : MonoBehaviour
{
    public float distance = 20.0f;                          // Default Distance 
    public float rotSpeed = 1000.0f;                           // Orbit speed (Left/Right)
    public float zoomSpeed = 1000.0f;                           // Orbit speed (Up/Down)

    public s_MapCreation map;

    private float xDeg = 0.0f;
    private float yDeg = 0.0f;
    private float zDeg = 0.0f;
    private float moveHorizontal;
    private float moveVertical;

    void Start()
    {
        transform.position = new Vector3(map.GetMapSize().x / 2, 20);
        moveHorizontal = Camera.main.transform.position.x;
        moveVertical = Camera.main.transform.position.z;
        distance = Camera.main.transform.position.y;
    }

    void Update()
    {
        Vector2 sizeOfMap = map.GetMapSize();

        if (Input.GetMouseButton(1))
        {
            xDeg += Input.GetAxis("Mouse X") * rotSpeed * 0.02f;
            yDeg -= Input.GetAxis("Mouse Y") * rotSpeed * 0.02f;

            ClampXAngle(xDeg);
            ClampYAngle(yDeg);

            Quaternion rotation = Quaternion.Euler(yDeg, xDeg, 0);
            transform.rotation = rotation;
        }

        if (Input.GetButton("Horizontal"))
        {
            float hMove = Input.GetAxis("Horizontal");
            if (transform.position.x < 0 - 5)
            {
                moveHorizontal = 0 - 5;
            }
            else if (transform.position.x > sizeOfMap.x + 5)
            {
                moveHorizontal = sizeOfMap.x + 5;
            }
            else
            {
                moveHorizontal += hMove * 0.5f;
            }
        }

        if (Input.GetButton("Vertical"))
        {
            float vMove = Input.GetAxis("Vertical");
            if (transform.position.z < 0 - 5)
            {
                moveVertical = 0 - 5;
            }
            else if(transform.position.z > sizeOfMap.y + 5)
            {
                moveVertical = sizeOfMap.y + 5;
            }
            else
            {
                moveVertical += vMove * 0.5f;
            }
        }


        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            if(distance < 4.0f)
            {
                distance = 4.0f;
            }
            else
            {
                if(distance > 20.0f)
                {
                    distance = 20.0f;
                }
                else
                {
                    distance -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
                }

            }
        }

        transform.position = new Vector3(moveHorizontal, distance, moveVertical);

    }

    void ClampXAngle(float angle)
    {
        if (angle < -360)
        {
            angle += 360;
        }
        if (angle > 360)
        {
            angle -= 360;
        }

        xDeg = Mathf.Clamp(angle, -40, 40);
    }

    void ClampYAngle(float angle)
    {
        if (angle < -360)
        {
            angle += 360;
        }
        if (angle > 360)
        {
            angle -= 360;
        }

        yDeg = Mathf.Clamp(angle, -70, 70);
    }
}