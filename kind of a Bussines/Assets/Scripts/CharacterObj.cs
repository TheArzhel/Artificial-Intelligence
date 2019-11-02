using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterObj : MonoBehaviour
{
    public NavMeshPath path;
    //private float elapsed = 0.0f;
    Move move;
    public float min_Distance = 0.1f;
    public float slow_Distance = 0.5f;
    private int iterator = 0;
    // Start is called before the first frame update
    SteeringSeek seek;
    void Start()
    {
        move = GetComponent<Move>();
        seek = GetComponent<SteeringSeek>();
        path = new NavMeshPath();
      //  elapsed = 0.0f;
        NavMesh.CalculatePath(transform.position, move.target.transform.position, NavMesh.AllAreas, path);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, move.target.transform.position) > min_Distance)
        {
            Vector3 mesh = path.corners[iterator];

            if (Vector3.Distance(transform.position, mesh) > slow_Distance)
            {
                seek.Steer(mesh);

            }
            else if (Vector3.Distance(transform.position, mesh) <= slow_Distance)
            {
                iterator++;
                mesh = path.corners[iterator];
            }
            if (Vector3.Distance(transform.position, mesh) <= min_Distance)
            {
                iterator = 0;

            }
        }
        else
        {
           
        }
    }

}
