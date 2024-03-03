
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoundTxtSwitcher : MonoBehaviour
{
    //this one will allow me to input data directly from Unity
    public Button b1;
    public TMP_Text b1text;
    //public AudioSource backgroundMusic;    

    void Start()
    {
        // Update button text based on initial mute state
        UpdateButtonText(GlobalVariables.muteConfig);
    }

    public void SwitchSound()
    {
        // Toggle mute state
        GlobalVariables.muteConfig = !GlobalVariables.muteConfig;

        // Update button text based on new mute state
        UpdateButtonText(GlobalVariables.muteConfig);
    }

    void UpdateButtonText(bool soundOn)
    {
        b1text.text = soundOn ? "Sounds Off" : "Sounds On";
    }
}