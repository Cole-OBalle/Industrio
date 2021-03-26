using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    Vector3 cameraVelocity;

    public Transform Background;

    float backgroundX;
    float backgroundY;
    // Start is called before the first frame update
    void Start()
    {
        backgroundX = 0;
        backgroundY = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float xAdjust = 0, yAdjust = 0;
        if (transform.position.x > 0)
        {
            xAdjust = 0.5f;
        }
        else if (transform.position.x < 0)
        {
            xAdjust = -0.5f ;
        }

        if ((transform.position.y > 0))
        {
            yAdjust = 0.5f;
        }
        else if (transform.position.y < 0)
        {
            yAdjust = -0.5f;
        }

        Background.position = new Vector3(backgroundX, backgroundY, 8);
        backgroundX = (int)(transform.position.x/10.24 + xAdjust) * 10.24f;
        backgroundY = (int)(transform.position.y / 10.24 + yAdjust) * 10.24f ;

        cameraVelocity = new Vector3(Input.GetAxis("Horizontal") * 3.5f, Input.GetAxis("Vertical")* 3.5f, 0);

        transform.Translate(cameraVelocity * Time.deltaTime);
    }

    public Vector3 getCameraDisplacement()
    {
        float xDis = 0 + transform.position.x;
        float yDis = 0 + transform.position.y;
        return (new Vector3(xDis, yDis, 0));
    }
}
