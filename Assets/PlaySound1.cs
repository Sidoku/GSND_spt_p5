using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayFallSound()
    {
        this.GetComponent<AudioSource>().Play();
    }
}