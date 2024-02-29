using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class clockController : MonoBehaviour
{
    public TMP_Text clockText;
    private bool clockRunning = false;
    private float elapsedTime = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if any key is pressed
        if (Input.anyKeyDown && !clockRunning)
        {
            // Start the clock
            clockRunning = true;
        }

        // Update the clock if it's running
        if (clockRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateClockText();
        }
    }

        void UpdateClockText()
    {
        // Format the elapsed time as minutes and seconds
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        string timeText = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Update the clock text
        clockText.text = timeText;
    }
}
