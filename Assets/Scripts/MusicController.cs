using UnityEngine;
using UnityEngine.Audio;


public class MusicController : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;

    void Start()
    {
        if(!PlayerPrefs.HasKey("SFXLv")){
            Debug.Log("Creating PlayerPrefs.SFXLv");
            PlayerPrefs.SetFloat("SFXLv",50);
        }
        if(!PlayerPrefs.HasKey("SFXMute")){
            Debug.Log("Creating PlayerPrefs.SFXMute");
            PlayerPrefs.SetInt("SFXMute",0);
        }
        if(!PlayerPrefs.HasKey("MusicLv")){
            Debug.Log("Creating PlayerPrefs.MusicLv");
            PlayerPrefs.SetFloat("MusicLv",50);
        }
        if(!PlayerPrefs.HasKey("MusicMute")){
            Debug.Log("Creating PlayerPrefs.MusicMute");
            PlayerPrefs.SetInt("MusicMute",0);
        }
        CheckVolumePrefs();
    }

    public void CheckVolumePrefs(){
        if (PlayerPrefs.GetInt("MusicMute") == 1){
            myMixer.SetFloat("Music", -80.0f);
        } 
        else{
            float volume = PlayerPrefs.GetFloat("MusicLv");
            if (volume != 0)
                myMixer.SetFloat("Music", Mathf.Log10(volume/20)*20);
            else
                myMixer.SetFloat("Music", -80.0f);
        } 
    }
}
