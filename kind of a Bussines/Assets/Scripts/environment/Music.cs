using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource src;

    // Start is called before the first frame update
    void Start()
    {

        src.clip = clip;
        src.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!src.isPlaying)
        {
            src.Play();
        }
    }




}
