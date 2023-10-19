using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FootstepAudioPlayer : MonoBehaviour
{
   public AudioSource AudioSource;

   private void Update()
   {
      if(Input.GetKey(KeyCode.W)|| (Input.GetKey(KeyCode.A))|| (Input.GetKey(KeyCode.S))|| (Input.GetKey(KeyCode.D)))
      {
         AudioSource.enabled = true;
      }
      else
      {
         AudioSource.enabled = false;
      }
   }
}
