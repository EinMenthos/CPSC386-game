using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barBottom : MonoBehaviour
{
    public GameObject barT;
    public GameObject barB;

    // Update is called once per frame
    void Update()
    {
        barB.transform.position = new Vector2 (barT.transform.position.x, barB.transform.position.y);
    }
}
