using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Audio;

public class MusicTxtSwitcher : MonoBehaviour
{
    public TMP_Text musicText;
    public AudioSource backgroundMusic;    
    public AudioSource backgroundFX;    
    [SerializeField] private Slider s1;


    public int muteMusic;
    [SerializeField] private AudioMixer myMixer;
    //private float volumeBeforeMute;


    void Start()
    {
        muteMusic = PlayerPrefs.GetInt("MusicMute");
        if (muteMusic == 1){
            musicText.text = "Off";
            s1.interactable = false;
            myMixer.SetFloat("Music", -80.0f);
        }
    }
    
    //when pressed button
    public void SwitchMusic()
    {
        // Toggle mute state
        //GlobalVariables.muteConfig = !GlobalVariables.muteConfig;
        backgroundFX.Play();
        if (muteMusic == 1)
        {
            Debug.Log("Music UnMuted");
            //PlayerPrefs.SetInt("MusicMute", 1);
            musicText.text = "On";
            s1.interactable = true;
            PlayerPrefs.SetInt("MusicMute",0);
            muteMusic = 0;
            //backgroundMusic.mute = false;
 /*           if(!PlayerPrefs.HasKey("MusicMute")){
                Debug.Log("Creating PlayerPrefs.MusicMute");
                PlayerPrefs.SetInt("MusicMute",0);
            }
            else{ */
                if (PlayerPrefs.GetInt("MusicMute") == 1){
                    //backgroundMusic.mute = true;
                    myMixer.SetFloat("Music", -80.0f);
                } 
                else{
                    //backgroundMusic.mute = false;
                    float volume = PlayerPrefs.GetFloat("MusicLv");
                    //Debug.Log("vol: " + volume);
                    if (volume != 0) myMixer.SetFloat("Music", Mathf.Log10(volume/20)*20);
                    else myMixer.SetFloat("Music", -80.0f);
                } 
            //}
        } 
        else{
            Debug.Log("Music Muted");
            musicText.text = "Off";
            s1.interactable = false;
            PlayerPrefs.SetInt("MusicMute",1);
            muteMusic = 1;
            //backgroundMusic.mute = true;
            myMixer.SetFloat("Music", -80.0f);
        }
    }

/*
    //changed by slider
    void SlideMusic()
    {
        // Toggle mute state
        //GlobalVariables.muteConfig = !GlobalVariables.muteConfig;
        if (muteMusic == 1)
        {
            backgroundFX.Play();
            Debug.Log("Music UnMuted");
            //PlayerPrefs.SetInt("MusicMute", 1);
            musicText.text = "On";
            PlayerPrefs.SetInt("MusicMute",0);
            muteMusic = 0;
  
                
        } 

    }
    */
}