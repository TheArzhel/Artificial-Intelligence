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
    Status DataOfSelectedGO;

    ResourcesUI panelResources;

    bool PanelIsActive;

    void Start()
    {
        panelResources=gameObject.GetComponent<ResourcesUI>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (TargetHit)
        {

            DataOfSelectedGO=SelectedEntity.GetComponent<Status>();
            TargetHit = false;
        }


        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {

          
              RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, RayLenght, layermask))
            {


                TargetHit = true;
                SelectedEntity=hit.collider.gameObject;
                CharacterUIaction.SetActive(true);
                PanelIsActive = true;


                //if the other panel is open then close
                panelResources.CloseMenu();


            }
              
        }

    }



    public void CloseActionMenu()
    {
       CharacterUIaction.SetActive(false);
        PanelIsActive = false;
    }

    public void WaitActionSend()
    {

        if (DataOfSelectedGO != null)
        {

            Debug.Log("Wait");
            DataOfSelectedGO.TodoAction = WorkerState.NONE;

        }


    }


    public void CloseBarActionSend()
    {

        if (DataOfSelectedGO != null)
        {

            Debug.Log("Close bar");
            DataOfSelectedGO.TodoAction = WorkerState.CLOSEBAR;

        }


    }

    public void HideAlcoholActionSend()
    {

        if (DataOfSelectedGO != null)
        {
            if (DataOfSelectedGO.TodoAction == WorkerState.NONE) {
                Debug.Log("Hide");
                DataOfSelectedGO.TodoAction = WorkerState.HIDEALCOHOL;
            }

        }



    }


    public void GoToKitchenSell()
    {

        if (DataOfSelectedGO != null)
        {
            if (DataOfSelectedGO.TodoAction == WorkerState.NONE)
            {
                Debug.Log("Go to Cash in at kitchen");
                DataOfSelectedGO.TodoAction = WorkerState.SELLKITCHEN;
            }
        }


    }


    public void GoToBarSell()
    {


        if (DataOfSelectedGO != null)
        {
            if (DataOfSelectedGO.TodoAction == WorkerState.NONE)
            {
                Debug.Log("Go to Cash in at bar");
                DataOfSelectedGO.TodoAction = WorkerState.SELLBAR;
            }
        }




    }

    public void GoToRestock()
    {

        if (DataOfSelectedGO != null)
        {

            if (DataOfSelectedGO.TodoAction == WorkerState.NONE)
            {
                Debug.Log("Go to Restock");
                DataOfSelectedGO.TodoAction = WorkerState.RESTOCK;
            }
        }

    }


}
