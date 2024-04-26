using System;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource backgroundMusic;    
    

    // Start is called before the first frame update
    void Start()
    {
        // Mute/unmute background music based on initial mute state
        CheckVolumePrefs();
        //SwitchGlobal();
    }
/*
    public void SwitchGlobal(){
        backgroundMusic.mute = GlobalVariables.muteConfig;
    }
    */
    public void CheckVolumePrefs(){
        if(!PlayerPrefs.HasKey("MusicLv")){
            Debug.Log("Creating PlayerPrefs.MusicLv");
            PlayerPrefs.SetFloat("MusicLv",50);
        }
        else{
            //Debug.Log(PlayerPrefs.GetInt("MusicLv"));
            backgroundMusic.volume = PlayerPrefs.GetFloat("MusicLv")/100;
            
        }
        if(!PlayerPrefs.HasKey("MusicMute")){
            Debug.Log("Creating PlayerPrefs.MusicMute");
            PlayerPrefs.SetInt("MusicMute",1);
        }
        else{
            if (PlayerPrefs.GetInt("MusicMute") == 0) backgroundMusic.mute = true;
            else backgroundMusic.mute = false;
        }
    }
}
