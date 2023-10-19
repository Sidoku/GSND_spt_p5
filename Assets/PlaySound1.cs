using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound1 : MonoBehaviour
{
    public Collider BoxCollider;

    private void OnEnable()
    {
        BoxCollider.enabled = false;
    }

    void PlayFallSound()
    {
        BoxCollider.enabled = true;
        this.GetComponent<AudioSource>().Play();
    }
}
