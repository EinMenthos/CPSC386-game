using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    [SerializeField] private Animator endingAnimator;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("animating...");
        endingAnimator.Play("storyUp",0,0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
