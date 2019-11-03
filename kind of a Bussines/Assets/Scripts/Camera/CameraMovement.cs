using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public float PanSpeed = 20f;
    public Vector2 PanLimit;

   
          // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;


        if (Input.GetKey("w"))
        {
            pos.z += PanSpeed * Time.deltaTime;


        }
        if (Input.GetKey("a"))
        {
            pos.x -= PanSpeed * Time.deltaTime;


        }
        if (Input.GetKey("d"))
        {
            pos.x += PanSpeed * Time.deltaTime;


        }
        if (Input.GetKey("s"))
        {
            pos.z -= PanSpeed * Time.deltaTime;


        }


        pos.x = Mathf.Clamp(pos.x,-PanLimit.x,PanLimit.x);
        pos.z = Mathf.Clamp(pos.z, -PanLimit.y, PanLimit.y);

        transform.position = pos;
        
    }
}
