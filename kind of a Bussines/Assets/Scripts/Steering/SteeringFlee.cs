using UnityEngine;
using System.Collections;

public class SteeringFlee : MonoBehaviour
{

    Move move;

    // Use this for initialization
    void Start()
    {
        move = GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
       Flee(move.target.transform.position);
    }

    public void Flee(Vector3 target)
    {
     

        Vector3 Steering_linear;
        Steering_linear = (transform.position - target);
        Steering_linear = Steering_linear.normalized * move.max_acceleration;
        move.AccelerateMovement(Steering_linear);

    }
}
