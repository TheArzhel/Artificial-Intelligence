using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterActionUI : MonoBehaviour
{

    public GameObject CharacterUIaction;
    GameObject SelectedEntity;


    bool TargetHit;

    float RayLenght = 100f;
    public LayerMask layermask;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {



        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {

          
              RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, RayLenght, layermask))
            {


                CharacterUIaction.SetActive(true);



            }


            
                       
        }


    }
}
