using System;
using UnityEngine;

public class FXController : MonoBehaviour
{
    public AudioSource backgroundFX;    
    

    // Start is called before the first frame update
    void Start()
    {
        // Mute/unmute background music based on initial mute state
        CheckFXPrefs();
        //SwitchGlobal();
    }
/*
    public void SwitchGlobal(){
        backgroundMusic.mute = GlobalVariables.muteConfig;
    }
    */
    public void CheckFXPrefs(){
        if(!PlayerPrefs.HasKey("FXLv")){
            Debug.Log("Creating PlayerPrefs.FXLv");
            PlayerPrefs.SetFloat("FXLv",75);
        }
        else{
            //Debug.Log(PlayerPrefs.GetInt("FXLv"));
            backgroundFX.volume = PlayerPrefs.GetFloat("FXLv")/100;
            
        }
        if(!PlayerPrefs.HasKey("FXMute")){
            Debug.Log("Creating PlayerPrefs.FXMute");
            PlayerPrefs.SetInt("FXMute",1);
        }
        else{
            if (PlayerPrefs.GetInt("FXMute") == 0) backgroundFX.mute = true;
            else backgroundFX.mute = false;
        }
    }
}
