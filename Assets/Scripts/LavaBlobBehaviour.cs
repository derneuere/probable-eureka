using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBlobBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().speed = Random.Range(0.5f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
