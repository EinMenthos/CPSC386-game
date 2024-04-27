using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour
{
    [SerializeField] private Slider s1;
    [SerializeField] private TMP_Text t1;
    [SerializeField] private AudioMixer myMixer;
    //[SerializeField] private MusicTxtSwitcher mts;
    //public TMP_Text buttonText;


    // Start is called before the first frame update
    void Start()
    {
        CheckVolumePrefs();
        //if(mts == null)  Debug.Log("miss");
        //else Debug.Log("Gotcha");
    }


    public void CheckVolumePrefs(){
        if(!PlayerPrefs.HasKey("MusicLv")){
            Debug.Log("Creating PlayerPrefs.MusicLv");
            PlayerPrefs.SetFloat("MusicLv",50);
        }
        else{
            s1.value = PlayerPrefs.GetFloat("MusicLv");
        }

    }

//https://www.youtube.com/watch?v=G-JUp8AMEx0
//how to use audio mixer
    public void SetVolume(){
        t1.text = s1.value.ToString();
        PlayerPrefs.SetFloat("MusicLv", (int)s1.value);
        float volume = s1.value;
        if (volume != 0)
            myMixer.SetFloat("Music", Mathf.Log10(volume/20)*20);
        else
            myMixer.SetFloat("Music", -80.0f);
        
    }

}
