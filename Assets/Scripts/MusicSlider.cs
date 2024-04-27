using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour
{
    [SerializeField] private Slider s1;
    [SerializeField] private TMP_Text t1;
    [SerializeField] public AudioSource backgroundMusic;    

    // Start is called before the first frame update
    void Start()
    {
        //have to relink with actual music
        if (backgroundMusic == null){
            Debug.Log("Slider: Creating link to original AudioSource Music Object");
            backgroundMusic = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioSource>();
        }
        CheckVolumePrefs();
    }


    public void CheckVolumePrefs(){
        if(!PlayerPrefs.HasKey("MusicLv")){
            Debug.Log("Creating PlayerPrefs.MusicLv");
            PlayerPrefs.SetFloat("MusicLv",50);
        }
        else{
            //Debug.Log(PlayerPrefs.GetInt("MusicLv"));
            s1.value = PlayerPrefs.GetFloat("MusicLv");
        }

    }

    public void SetVolume(){
        Debug.Log(s1.value);
        t1.text = s1.value.ToString();
        PlayerPrefs.SetFloat("MusicLv", (int)s1.value);
        backgroundMusic.volume = PlayerPrefs.GetFloat("MusicLv")/100;
    }
}
