using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class MusicTxtSwitcher : MonoBehaviour
{
    //this one will allow me to input data directly from Unity
    //public Button b1;
    public TMP_Text Musictext;


    public AudioSource backgroundMusic;    
    public AudioSource backgroundFX;    

    int muteMusic;

    void Start()
    {
        muteMusic = PlayerPrefs.GetInt("MusicMute");
        //Debug.Log(muteMusic);
        // Update button text based on initial mute state
        //UpdateButtonText(GlobalVariables.muteConfig);
        if (muteMusic == 0){
            Musictext.text = "Off";
        }

        //have to relink with actual music
        if (backgroundMusic == null){
            Debug.Log("Button: Creating link to original AudioSource Music Object");
            backgroundMusic = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioSource>();
        }
        /*
        //have to relink with actual music
        if (backgroundFX == null){
            Debug.Log("Button: Creating link to original AudioSource FX Object");
            backgroundMusic = GameObject.FindGameObjectWithTag("FX").GetComponent<AudioSource>();
        }
        */
    }
    
    public void SwitchSound()
    {
        // Toggle mute state
        //GlobalVariables.muteConfig = !GlobalVariables.muteConfig;
        backgroundFX.Play();
        if (muteMusic == 0)
        {
            //PlayerPrefs.SetInt("MusicMute", 1);
            Musictext.text = "On";
            PlayerPrefs.SetInt("MusicMute",1);
            muteMusic = 1;
            backgroundMusic.mute = false;
        } 
        else{
            //PlayerPrefs.SetInt("MusicMute", 0);
            Musictext.text = "Off";
            PlayerPrefs.SetInt("MusicMute",0);
            muteMusic = 0;
            backgroundMusic.mute = true;
        }
    }
}