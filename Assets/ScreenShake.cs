using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{    
    [Header("Target Camera")]
    public Transform cam;

    [Header("Timing")]
    [Range(0.1f, 5.0f)]
    public float maxDuration = 1.0f;
    public bool useUnscaledTime;
    
    [Header("Degrees of Freedom")]
    [Tooltip("Maximum distance in Unity units. Set to 0, 0, 0 for pleasant 3D.")]
    public Vector3 translationUnits = new Vector3(1, 1, 0);
    [Tooltip("Maximum rotation in degrees. Combine with translation for awesome 2D.")]
    public Vector3 rotationDegrees = new Vector3(0, 0, 2);

    [Header("Smoothing Exponents")]
    [Tooltip("Higher means smaller trauma is softened.")]
    public Vector3 translationExponents = new Vector3(2, 2, 2);
    [Tooltip("Higher means smaller trauma is softened.")]
    public Vector3 rotationExponents = new Vector3(2, 2, 2);

    [Header("Frequencies")]
    [Tooltip("Higher means faster shakes.")]
    public Vector3 translationFrequencies = new Vector3(5, 5, 5);
    [Tooltip("Higher means faster shakes.")]
    public Vector3 rotationFrequencies = new Vector3(5, 5, 5);
    
    private static float _trauma;
    
    public static float trauma
    {
        set { _trauma = Mathf.Clamp01(_trauma + value); }
    }

    private static float Perlin(float x, float y)
    {
        //Normalized to [-1, 1]
        return Mathf.PerlinNoise(x, y) * 2.0f - 1.0f;
    }
    
    // Update is called once per frame
    private void Update()
    {
        var time = useUnscaledTime ? Time.unscaledTime: Time.time;

        var translation = new Vector3
        {
            x = translationUnits.x * Mathf.Pow(_trauma, translationExponents.x) *
                Perlin(time * translationFrequencies.x, 0),
            y = translationUnits.y * Mathf.Pow(_trauma, translationExponents.y) *
                Perlin(time * translationFrequencies.y, 5),
            z = translationUnits.z * Mathf.Pow(_trauma, translationExponents.z) *
                Perlin(time * translationFrequencies.z, 10)
        };

        var rotation = new Vector3
        {
            x = rotationDegrees.x * Mathf.Pow(_trauma, rotationExponents.x) *
                Perlin(time * rotationFrequencies.x, 0),
            y = rotationDegrees.y * Mathf.Pow(_trauma, rotationExponents.y) *
                Perlin(time * rotationFrequencies.y, 5),
            z = rotationDegrees.z * Mathf.Pow(_trauma, rotationExponents.z) *
                Perlin(time * rotationFrequencies.z, 10)
        };

        cam.transform.localPosition = translation;
        cam.transform.localRotation = Quaternion.Euler(rotation);
        
        //Trauma Decay
        _trauma = Mathf.Clamp01(_trauma - (useUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime) / maxDuration);
    }
}



[CustomEditor(typeof(ScreenShake), true)]
public class ScreenShakeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GUILayout.Label("Preview in Play Mode", EditorStyles.boldLabel);
        EditorGUI.BeginDisabledGroup(!Application.isPlaying);
        if (GUILayout.Button("Shake 100%"))
        {
            ScreenShake.trauma = 1.0f;
        }
        if (GUILayout.Button("Shake 50%"))
        {
            ScreenShake.trauma = 0.5f;
        }
        if (GUILayout.Button("Shake 25%"))
        {
            ScreenShake.trauma = 0.25f;
        }
        EditorGUI.EndDisabledGroup();
    }
    
}

/*
Written by Moritz Voss in 2018

This is free and unencumbered software released into the public domain.

Anyone is free to copy, modify, publish, use, compile, sell, or
distribute this software, either in source code form or as a compiled
binary, for any purpose, commercial or non-commercial, and by any
means.

In jurisdictions that recognize copyright laws, the author or authors
of this software dedicate any and all copyright interest in the
software to the public domain. We make this dedication for the benefit
of the public at large and to the detriment of our heirs and
successors. We intend this dedication to be an overt act of
relinquishment in perpetuity of all present and future rights to this
software under copyright law.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR
OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
OTHER DEALINGS IN THE SOFTWARE.

For more information, please refer to <http://unlicense.org>
*/