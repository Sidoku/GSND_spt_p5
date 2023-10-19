using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class Level1Mode : LevelSingleton<Level1Mode>
{
    public AudioClip PhoneClip;
    public PlayerInput Input;
    public DialogueLine[] StartDialogs;
    public DialogueLine[] TurnOffElecDialogs;
    public PlayableDirector Director;

    private void Start()
    {
        UIMgr.Instance.EnterMovieMode();
        Director.stopped -= OnDirectorStopp;
        Director.stopped += OnDirectorStopp;
        Input.enabled = false;
    }

    private void OnDirectorStopp(PlayableDirector dir)
    {
        Director.stopped -= OnDirectorStopp;
        StartCoroutine(OnDirectorFinished());
    }

    public IEnumerator OnDirectorFinished()
    {
        yield return new WaitForSeconds(1);
        AudioMgr.Instance.PlayOneShot2DSE(PhoneClip);
        yield return new WaitForSeconds(3);
        AudioMgr.Instance.Stop2DSE();

        UIMgr.Instance.DialogC.OnFinishDialog -= OnDialogFinish;
        UIMgr.Instance.DialogC.OnFinishDialog += OnDialogFinish;
        UIMgr.Instance.DialogC.StartDialogue(StartDialogs, DialogType.Telephone);
    }

    public void OnDialogFinish()
    {
        UIMgr.Instance.DialogC.OnFinishDialog -= OnDialogFinish;
        StartCoroutine(FirstCou());
    }

    private IEnumerator FirstCou()
    {
        yield return new WaitForSeconds(2);
        AudioMgr.Instance.PlayOneShot2DSE(AudioMgr.Instance.SE_TurnOffElectric);
        UIMgr.Instance.BG.FadeIn(0, Color.black);
        yield return new WaitForSeconds(2);
        UIMgr.Instance.DialogC.OnFinishDialog -= OnTurnOffElecDialogFinished;
        UIMgr.Instance.DialogC.OnFinishDialog += OnTurnOffElecDialogFinished;
        UIMgr.Instance.DialogC.StartDialogue(TurnOffElecDialogs, DialogType.Telephone);
    }

    public void OnTurnOffElecDialogFinished()
    {
        UIMgr.Instance.DialogC.OnFinishDialog -= OnTurnOffElecDialogFinished;
        SceneManager.LoadScene(1);
        UIMgr.Instance.LeaveMovieMode();
        UIMgr.Instance.BG.FadeOut(2);
    }
}
