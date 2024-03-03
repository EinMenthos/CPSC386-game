using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource backgroundMusic;    

    // Start is called before the first frame update
    void Start()
    {
        // Mute/unmute background music based on initial mute state
        SwitchGlobal();
    }

    public void SwitchGlobal(){
        backgroundMusic.mute = GlobalVariables.muteConfig;
    }
}
