using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class SFXSlider : MonoBehaviour
{
    [SerializeField] private Slider s1;
    [SerializeField] private TMP_Text t1;
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] public AudioSource backgroundSFX;    
    //public TMP_Text SFXtext;



    // Start is called before the first frame update
    void Start()
    {
        CheckVolumePrefs();
    }


    public void CheckVolumePrefs(){
        if(!PlayerPrefs.HasKey("SFXLv")){
            Debug.Log("Creating PlayerPrefs.SFXLv");
            PlayerPrefs.SetFloat("SFXLv",50);
        }
        else{
            s1.value = PlayerPrefs.GetFloat("SFXLv");
        }

    }

    public void SetVolume(){
        t1.text = s1.value.ToString();
        PlayerPrefs.SetFloat("SFXLv", (int)s1.value);
        float volume = s1.value;
        if (volume != 0)
            myMixer.SetFloat("SFX", Mathf.Log10(volume/20)*20);
        else
            myMixer.SetFloat("SFX", -80.0f);
    }
}
