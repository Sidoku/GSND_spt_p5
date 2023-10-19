using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using UnityEngine.Rendering;

public class Level2Mode : MonoBehaviour
{
    public PlayerInput Input;
    public Volume JumpScareVolume;
    public AudioClip ScareClip;

    public void PlayJumpScare()
    {
        Input.enabled = false;
        AudioMgr.Instance.PlayOneShot2DSE(ScareClip);
        JumpScareVolume.weight = 1;
        UIMgr.Instance.ScareImgObj.SetActive(true);
        StartCoroutine(ExitGameCou());
    }

    public IEnumerator ExitGameCou()
    {
        yield return new WaitForSeconds(5);
        GameManager.Instance.QuitGame();
    }
}
