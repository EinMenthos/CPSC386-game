
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class SoundTxtSwitcher : MonoBehaviour
{
    //this one will allow me to input data directly from Unity
    public Button b1;
    public TMP_Text b1text;
    public AudioSource backgroundMusic;    

    int muteGame;

    void Start()
    {
        muteGame = PlayerPrefs.GetInt("VolumeMute");
        //Debug.Log(muteGame);
        // Update button text based on initial mute state
        //UpdateButtonText(GlobalVariables.muteConfig);
        if (muteGame == 0){
            b1text.text = "Sound is Off";
        }
        //have to relink with actual music
        if (backgroundMusic == null){
            Debug.Log("Creating link to previous AudioSource Object");
            backgroundMusic = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioSource>();
        }
    }
    
    public void SwitchSound()
    {
        // Toggle mute state
        //GlobalVariables.muteConfig = !GlobalVariables.muteConfig;

        if (muteGame == 0)
        {
            //PlayerPrefs.SetInt("VolumeMute", 1);
            b1text.text = "Sound is On";
            PlayerPrefs.SetInt("VolumeMute",1);
            muteGame = 1;
            backgroundMusic.mute = false;
        }
            
        else{
            //PlayerPrefs.SetInt("VolumeMute", 0);
            b1text.text = "Sound is Off";
            PlayerPrefs.SetInt("VolumeMute",0);
            muteGame = 0;
            backgroundMusic.mute = true;
        }
    }
}