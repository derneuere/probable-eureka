using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour
{
    public new Camera camera;    
    public ScreenShakeProfile screenShake;

    // Update is called once per frame
    private void Update()
    {
        screenShake.Apply(camera.transform);
    }
}
