using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBehaviour : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 15)
        {
            Destroy(gameObject);
        }
    }
}
