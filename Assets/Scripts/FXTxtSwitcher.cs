using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class FXTxtSwitcher : MonoBehaviour
{
    //this one will allow me to input data directly from Unity
    //public Button b1;
    public TMP_Text FXtext;

    //public Button bFX;


    public AudioSource backgroundFX;    

    int muteFX;

    void Start()
    {
        muteFX = PlayerPrefs.GetInt("FXMute");
        //Debug.Log(muteMusic);
        // Update button text based on initial mute state
        //UpdateButtonText(GlobalVariables.muteConfig);

        if (muteFX == 0){
            FXtext.text = "Off";
        }

        //have to relink with actual music
        if (backgroundFX == null){
            Debug.Log("Button: Creating link to original AudioSource FX Object");
            backgroundFX = GameObject.FindGameObjectWithTag("FX").GetComponent<AudioSource>();
        }
    }
    
        public void SwitchFX()
    {
        // Toggle mute state
        //GlobalVariables.muteConfig = !GlobalVariables.muteConfig;

        if (muteFX == 0)
        {
            //PlayerPrefs.SetInt("MusicMute", 1);
            FXtext.text = "On";
            PlayerPrefs.SetInt("FXMute",1);
            muteFX = 1;
            backgroundFX.mute = false;
        } 
        else{
            //PlayerPrefs.SetInt("MusicMute", 0);
            FXtext.text = "Off";
            PlayerPrefs.SetInt("FXMute",0);
            muteFX = 0;
            backgroundFX.mute = true;
        }
    }
}