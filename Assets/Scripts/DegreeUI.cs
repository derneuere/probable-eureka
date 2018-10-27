using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DegreeUI : MonoBehaviour
{
    public TMP_Text text;

    public void SetDegree(float degree)
    {
        text.SetText("Degree: " + System.Math.Round(degree, 2) + " °");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
