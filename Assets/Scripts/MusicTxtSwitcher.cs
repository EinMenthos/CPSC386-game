using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class MusicTxtSwitcher : MonoBehaviour
{
    public TMP_Text musicText;
    public AudioSource backgroundMusic;    
    public AudioSource backgroundFX;    
    [SerializeField] private Slider s1;

    public int muteMusic;
    [SerializeField] private AudioMixer myMixer;

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
        backgroundFX.Play();
        if (muteMusic == 1)
        {
            Debug.Log("Music UnMuted");
            musicText.text = "On";
            s1.interactable = true;
            PlayerPrefs.SetInt("MusicMute",0);
            muteMusic = 0;
            if (PlayerPrefs.GetInt("MusicMute") == 1){
                myMixer.SetFloat("Music", -80.0f);
            } 
            else{
                float volume = PlayerPrefs.GetFloat("MusicLv");
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
            myMixer.SetFloat("Music", -80.0f);
        }
    }
}