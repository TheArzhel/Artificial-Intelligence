using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class FeedBack : MonoBehaviour
{


    public GameObject SpritePref;

    // Start is called before the first frame update
    void Start()
    {
        if (SpritePref != null)
            ShowPopUp();

    }

    void ShowPopUp()
    {

        Instantiate(SpritePref,transform.position,Quaternion.identity,transform);

    }
}
