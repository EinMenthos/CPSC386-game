using System;
using UnityEngine;

public class SoundController : MonoBehaviour
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
        if(!PlayerPrefs.HasKey("VolumeLv")){
            Debug.Log("Creating PlayerPrefs.VolumeLv");
            PlayerPrefs.SetFloat("VolumeLv",100);
        }
        else{
            //Debug.Log(PlayerPrefs.GetInt("VolumeLv"));
            backgroundMusic.volume = PlayerPrefs.GetFloat("VolumeLv")/100;
            
        }
        if(!PlayerPrefs.HasKey("VolumeMute")){
            Debug.Log("Creating PlayerPrefs.VolumeMute");
            PlayerPrefs.SetInt("VolumeMute",0);
        }
        else{
            if (PlayerPrefs.GetInt("VolumeMute") == 0) backgroundMusic.mute = true;
            else backgroundMusic.mute = false;
        }
    }
}
