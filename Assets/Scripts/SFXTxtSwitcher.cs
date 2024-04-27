using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Audio;

public class SFXTxtSwitcher : MonoBehaviour
{
    public TMP_Text SFXtext;
    public AudioSource backgroundSFX;    

    int muteSFX;
    [SerializeField] private AudioMixer myMixer;


    void Start()
    {
        muteSFX = PlayerPrefs.GetInt("SFXMute");

        if (muteSFX == 1){
            SFXtext.text = "Off";
            myMixer.SetFloat("SFX", -80.0f);
        }
    }
    
        public void SwitchSFX()
    {
        
        if (muteSFX == 1)
        {
            backgroundSFX.Play();
            Debug.Log("SFX UnMuted");
            //PlayerPrefs.SetInt("SFXMute", 1);
            SFXtext.text = "On";
            PlayerPrefs.SetInt("SFXMute",0);
            muteSFX = 0;
            //backgroundSFX.mute = false;
            if(!PlayerPrefs.HasKey("SFXMute")){
                Debug.Log("Creating PlayerPrefs.SFXMute");
                PlayerPrefs.SetInt("SFXMute",0);
            }
            else{
                if (PlayerPrefs.GetInt("SFXMute") == 1){
                    //backgroundSFX.mute = true;
                    myMixer.SetFloat("SFX", -80.0f);
                } 
                else{
                    //backgroundSFX.mute = false;
                    float volume = PlayerPrefs.GetFloat("SFXLv");
                    //Debug.Log("vol: " + volume);
                    if (volume != 0) myMixer.SetFloat("SFX", Mathf.Log10(volume/20)*20);
                    else myMixer.SetFloat("SFX", -80.0f);
                } 
            }
        } 
        else{
            Debug.Log("SFX Muted");
            SFXtext.text = "Off";
            PlayerPrefs.SetInt("SFXMute",1);
            muteSFX = 1;
            //backgroundSFX.mute = true;
            myMixer.SetFloat("SFX", -80.0f);
        }
    }
            public void SwitchSFX_Start()
    {
        // Toggle mute state
        //GlobalVariables.muteConfig = !GlobalVariables.muteConfig;

        if (muteSFX == 0)
        {
            SFXtext.text = "On";
            PlayerPrefs.SetInt("SFXMute",1);
            muteSFX = 1;
            backgroundSFX.mute = false;
        } 
        else{
            //PlayerPrefs.SetInt("SFXMute", 0);
            SFXtext.text = "Off";
            PlayerPrefs.SetInt("SFXMute",0);
            muteSFX = 0;
            backgroundSFX.mute = true;
        }
    }
}