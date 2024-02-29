using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundController : MonoBehaviour
{
    public AudioSource backgroundMusic;    

    // Start is called before the first frame update
    void Start()
    {
        // Mute/unmute background music based on initial mute state
        SwitchGlobal();
    }

    public void SwitchGlobal(){
        backgroundMusic.mute = globalVariables.muteConfig;
    }
}
