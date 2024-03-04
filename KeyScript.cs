using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KeyScript : MonoBehaviour, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData eventData)
    {
        PlayAudioAndAnimationKey();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
            MyGlobalVariables._numberOctave = 0;
        else if (Input.GetKeyDown(KeyCode.Keypad1))
            MyGlobalVariables._numberOctave = 1;
        else if (Input.GetKeyDown(KeyCode.Keypad2))
            MyGlobalVariables._numberOctave = 2;
        else if (Input.GetKeyDown(KeyCode.Keypad3))
            MyGlobalVariables._numberOctave = 3;
        else if (Input.GetKeyDown(KeyCode.Keypad4))
            MyGlobalVariables._numberOctave = 4;
        else if (Input.GetKeyDown(KeyCode.Keypad5))
            MyGlobalVariables._numberOctave = 5;
        else if (Input.GetKeyDown(KeyCode.Keypad6))
            MyGlobalVariables._numberOctave = 6;
        else if (Input.GetKeyDown(KeyCode.Keypad7))
            MyGlobalVariables._numberOctave = 7;
        else if (Input.GetKeyDown(KeyCode.Keypad8))
            MyGlobalVariables._numberOctave = 8;
        else if(Input.GetKeyDown(KeyCode.Keypad9))
            MyGlobalVariables._numberOctave = 9;
        PlayingKeysByKeyboard();
    }

    public void PlayingKeysByKeyboard()
    {
        if(Input.GetKeyDown(KeyCode.C) && name == $"C{MyGlobalVariables._numberOctave}")
        {
            PlayAudioAndAnimationKey();
        }
        if(Input.GetKeyDown(KeyCode.F) && name == $"C{MyGlobalVariables._numberOctave}-1")
        {
            PlayAudioAndAnimationKey();
        }
        if(Input.GetKeyDown(KeyCode.V) && name == $"D{MyGlobalVariables._numberOctave}")
        {
            PlayAudioAndAnimationKey();
        }
        if(Input.GetKeyDown(KeyCode.G) && name == $"D{MyGlobalVariables._numberOctave}-1")
        {
            PlayAudioAndAnimationKey();
        }
        if(Input.GetKeyDown(KeyCode.B) && name == $"E{MyGlobalVariables._numberOctave}")
        {
            PlayAudioAndAnimationKey();
        }
        if(Input.GetKeyDown(KeyCode.N) && name == $"F{MyGlobalVariables._numberOctave}")
        {
            PlayAudioAndAnimationKey();
        }
        if(Input.GetKeyDown(KeyCode.J) && name == $"F{MyGlobalVariables._numberOctave}-1")
        {
            PlayAudioAndAnimationKey();
        }
        if(Input.GetKeyDown(KeyCode.M) && name == $"G{MyGlobalVariables._numberOctave}")
        {
            PlayAudioAndAnimationKey();
        }
        if(Input.GetKeyDown(KeyCode.K) && name == $"G{MyGlobalVariables._numberOctave}-1")
        {
            PlayAudioAndAnimationKey();
        }
        if(Input.GetKeyDown(KeyCode.Comma) && name == $"A{MyGlobalVariables._numberOctave}")
        {
            PlayAudioAndAnimationKey();
        }
        if(Input.GetKeyDown(KeyCode.L) && name == $"A{MyGlobalVariables._numberOctave}-1")
        {
            PlayAudioAndAnimationKey();
        }
        if(Input.GetKeyDown(KeyCode.Period) && name == $"B{MyGlobalVariables._numberOctave}")
        {
            PlayAudioAndAnimationKey();
        }
    }

    public void PlayAudioAndAnimationKey(){
        GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
        GetComponent<Animation>().Play();
        MyGlobalVariables._nameOfKey = name;
        MyGlobalVariables.countAllTimes++;
    }

}

