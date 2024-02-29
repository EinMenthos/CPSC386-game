
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class soundTxtSwitcher : MonoBehaviour
{
    //this one will allow me to input data directly from Unity
    public Button b1;
    public TMP_Text b1text;
    //public AudioSource backgroundMusic;    

    void Start()
    {
        // Update button text based on initial mute state
        UpdateButtonText(globalVariables.muteConfig);
    }

    public void SwitchSound()
    {
        // Toggle mute state
        globalVariables.muteConfig = !globalVariables.muteConfig;

        // Update button text based on new mute state
        UpdateButtonText(globalVariables.muteConfig);
    }

    void UpdateButtonText(bool soundOn)
    {
        b1text.text = soundOn ? "Sounds Off" : "Sounds On";
    }
}