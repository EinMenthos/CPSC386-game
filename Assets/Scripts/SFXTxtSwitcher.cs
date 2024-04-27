using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class SFXTxtSwitcher : MonoBehaviour
{
    public TMP_Text SFXtext;
    public AudioSource backgroundSFX;   
    [SerializeField] private Slider s1;
 

    int muteSFX;
    [SerializeField] private AudioMixer myMixer;


    void Start()
    {
        muteSFX = PlayerPrefs.GetInt("SFXMute");
        if (muteSFX == 1){
            SFXtext.text = "Off";
            s1.interactable = false;
            myMixer.SetFloat("SFX", -80.0f);
        }
    }
    
        public void SwitchSFX()
    {
        // Toggle mute state
        if (muteSFX == 1)
        {
            backgroundSFX.Play();
            Debug.Log("SFX UnMuted");
            SFXtext.text = "On";
            s1.interactable = true;
            PlayerPrefs.SetInt("SFXMute",0);
            muteSFX = 0;
            if (PlayerPrefs.GetInt("SFXMute") == 1){
                myMixer.SetFloat("SFX", -80.0f);
            } 
            else{
                float volume = PlayerPrefs.GetFloat("SFXLv");
                if (volume != 0) myMixer.SetFloat("SFX", Mathf.Log10(volume/20)*20);
                else myMixer.SetFloat("SFX", -80.0f);
            } 
            //}
        } 
        else{
            Debug.Log("SFX Muted");
            SFXtext.text = "Off";
            s1.interactable = false;
            PlayerPrefs.SetInt("SFXMute",1);
            muteSFX = 1;
            myMixer.SetFloat("SFX", -80.0f);
        }
    }
}