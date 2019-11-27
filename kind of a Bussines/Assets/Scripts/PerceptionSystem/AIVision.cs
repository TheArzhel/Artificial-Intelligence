using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIVision : MonoBehaviour
{

    public Camera frustum;
    public LayerMask ray_mask;
    public LayerMask mask;

    private List<GameObject> detected;
    private List<GameObject> detected_now;
    private Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        //initilize values
        detected = new List<GameObject>();
        detected_now = new List<GameObject>();
        ray = new Ray();

    }

    // Update is called once per frame
    void Update()
    {

        //Filling Collider array with colliders entering or inside the defined sphere
        Collider[] colliders = Physics.OverlapSphere(transform.position, frustum.farClipPlane, mask);
        //Filling Planes array with planes form frustum (6 planes) 
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(frustum);

        //clear detected now list to ensure no GO is when searching cols
        detected_now.Clear();

        foreach(Collider cols in colliders) {

            //Check if  colliders is equal his gameObject col and check if col is inside frustum
            if (cols.gameObject !=gameObject && GeometryUtility.TestPlanesAABB(planes,cols.bounds))
            {

                RaycastHit HitRay;

                //set aux pos for assigning direction
                ray.origin=transform.position;
                ray.direction = (cols.transform.position-transform.position);
                //set defenitive origin
                ray.origin = ray.GetPoint(frustum.nearClipPlane);


                //assign ray direction to HitRay
                if (Physics.Raycast(ray, out HitRay, frustum.farClipPlane, ray_mask))
                {

                    //if ray hits added to the list detected now with a determined tag
                    if (HitRay.collider.gameObject.CompareTag("VisualEmissor"))
                    {

                        detected_now.Add(cols.gameObject);

                    }


                }


            }
        }

        foreach (GameObject go in detected_now)
        {
            //if the game object wasn't already detected
            if (detected.Contains(go) == false)
            {

                //create new event ans send it the the manager

                PerceptionEvent p_event = new PerceptionEvent();
                p_event.GO = go;
                p_event.Type = PerceptionEvent.types.NEW;
                p_event.Sense = PerceptionEvent.sense.VISION;

                //call EventPercieved
                SendMessage("EventPercieved",p_event);


            }

        }

        foreach (GameObject go in detected)
        {
            //if the game object was already detected
            if (detected_now.Contains(go) == false)
            {

                //create new event ans send it the the manager

                PerceptionEvent p_event = new PerceptionEvent();
                p_event.GO = go;
                p_event.Type = PerceptionEvent.types.LOST;
                p_event.Sense = PerceptionEvent.sense.VISION;

                //call EventPercieved
                SendMessage("EventPercieved", p_event);


            }

        }

        
        detected.Clear();
        detected.AddRange(detected_now);






    }
}
