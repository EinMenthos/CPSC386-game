using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FXSlider : MonoBehaviour
{
    [SerializeField] private Slider s1;
    [SerializeField] private TMP_Text t1;
    [SerializeField] public AudioSource backgroundFX;    

    // Start is called before the first frame update
    void Start()
    {
        //have to relink with actual music
        if (backgroundFX == null){
            Debug.Log("Slider: Creating link to original AudioSource FX Object");
            backgroundFX = GameObject.FindGameObjectWithTag("FX").GetComponent<AudioSource>();
        }
        CheckVolumePrefs();
    }


    public void CheckVolumePrefs(){
        if(!PlayerPrefs.HasKey("FXLv")){
            Debug.Log("Creating PlayerPrefs.FXLv");
            PlayerPrefs.SetFloat("FXLv",50);
        }
        else{
            //Debug.Log(PlayerPrefs.GetInt("MusicFX"));
            s1.value = PlayerPrefs.GetFloat("FXLv");
        }

    }

    public void SetVolume(){
        //Debug.Log(s1.value);
        t1.text = s1.value.ToString();
        PlayerPrefs.SetFloat("FXLv", (int)s1.value);
        backgroundFX.volume = PlayerPrefs.GetFloat("FXLv")/100;
    }
}
