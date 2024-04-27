using UnityEngine;
using UnityEngine.Audio;


public class SFXController : MonoBehaviour
{ 
    [SerializeField] private AudioMixer myMixer;

    void Start()
    {
        CheckSFXPrefs();
    }

    public void CheckSFXPrefs(){
        if (PlayerPrefs.GetInt("SFXMute") == 1){
            myMixer.SetFloat("SFX", -80.0f);
        } 
        else{
            float volume = PlayerPrefs.GetFloat("SFXLv");
            if (volume != 0)
                myMixer.SetFloat("SFX", Mathf.Log10(volume/20)*20);
            else
                myMixer.SetFloat("SFX", -80.0f);
        } 
    }
}