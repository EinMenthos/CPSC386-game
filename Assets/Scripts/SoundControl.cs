using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoundControl : MonoBehaviour
{
    //this one will allow me to input data directly from Unity
    public Button b1;
    public TMP_Text b1text;

    void Start(){
        b1text = b1.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SwitchSound ()
    {
        Debug.Log(b1text.text);
        if (b1text.text == "Sounds on"){
            b1text.text = "Sounds off";
        }
        else{
            b1text.text = "Sounds on";
        }
    }
}
