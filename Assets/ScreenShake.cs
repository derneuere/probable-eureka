using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public Transform cam;

    public float amplitude = 1.0f;
    
    public static float magnitude;
    
    // Update is called once per frame
    void Update()
    {
        cam.transform.localPosition = Random.insideUnitCircle * magnitude * amplitude;
        magnitude = Filter.FIR(magnitude, 0);
    }
}
