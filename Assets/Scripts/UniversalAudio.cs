using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UniversalAudio : MonoBehaviour
{
 public void OnTriggerEnter(Collider other)
 {
  Debug.Log("Player entered trigger");
  if (other.gameObject.CompareTag("Player"))
  {
   Debug.Log("Audio is playing from " + this.gameObject.name);
   this.gameObject.GetComponent<AudioSource>().Play(0);
  }
 }
}
