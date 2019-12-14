using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public enum PopUp_Type { Inspect, Detected,Money, Food, Alcohol,Angry,Waiting}

public class DisplayPopUps : MonoBehaviour
{



    public Vector3 offset = new Vector3(0,2,0);
    public Vector3 SpriteScale = new Vector3(5, 5, 5);
    public float DestroyTimePopUp = 3.0f;

    [SerializeField]
    public PopUp_Type current;

    [SerializeField]
    private SpriteAtlas PopAtlas;

    private SpriteRenderer myrender;


    GameObject mainCam;
    // Start is called before the first frame update
    void Start()
    {

       
        transform.localScale = SpriteScale;
        myrender = GetComponent<SpriteRenderer>();
        ShowSprite();
        Destroy(gameObject, DestroyTimePopUp);
        mainCam = GameObject.Find("Main Camera");
    }

  


    void ShowSprite()
    {

        myrender.sprite = PopAtlas.GetSprite(current.ToString());

    }
}
