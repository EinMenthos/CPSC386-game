using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class soundcontrol : MonoBehaviour
{
    //this one will allow me to input data directly from Unity
    public Button b1;
    public TMP_Text b1text;
    public AudioSource mainAudio;
    

    void Start(){
        b1text = b1.GetComponentInChildren<TextMeshProUGUI>();
        mainAudio = GetComponent<AudioSource>();
    }

    public void SwitchSound ()
    {
        if (b1text.text == "Sounds on"){
            b1text.text = "Sounds off";
        }
        else{
            b1text.text = "Sounds on";
            //mainAudio.Play();
        }

            mainAudio.mute = !mainAudio.mute;
        Debug.Log(b1text.text);
    }
}
