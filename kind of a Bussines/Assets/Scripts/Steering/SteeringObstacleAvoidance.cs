using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringObstacleAvoidance : MonoBehaviour
{

    public float range = 2.0f;
    RaycastHit hit;
    public bool Rayhit;
    public int layerMask = 8;

    public float displacement=3.0f;
    public float Strenght = 3.0f;
    Vector3 normalSurf;
    Vector3 HitPoint;
    Vector3 newpos;


    Move move;
    SteeringSeek seek;
    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<Move>();
        seek = GetComponent<SteeringSeek>();
    }

    // Update is called once per frame
    void Update()
    {

        Rayhit = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range,layerMask);


        if (Rayhit)
        {
            normalSurf=hit.normal;
            normalSurf = normalSurf.normalized * displacement;
            HitPoint = hit.point;

            newpos =normalSurf+HitPoint;

            seek.Steer(newpos* Strenght);

        }

        DebugDrawRay();

    }



    void DebugDrawRay()
    {

        if (Rayhit)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            Debug.Log("Did Hit");
            Debug.DrawRay(HitPoint, newpos, Color.green);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * range, Color.white);
            Debug.Log("Did not Hit");
        }

    }
}
