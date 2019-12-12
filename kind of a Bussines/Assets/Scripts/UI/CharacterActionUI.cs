using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterActionUI : MonoBehaviour
{

    public GameObject CharacterUIaction;
    GameObject SelectedEntity;
    bool TargetHit;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.rigidbody.gameObject.CompareTag("Worker"))
                {

                    SelectedEntity = hit.rigidbody.gameObject;
                    TargetHit = true;

                }


            }


            if (TargetHit){

                CharacterUIaction.SetActive(true);
                




            }
                       
        }


    }
}
