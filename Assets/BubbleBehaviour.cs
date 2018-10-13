using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBehaviour : MonoBehaviour
{
    private Vector2 _size;

    private void Start()
    {
        _size = Vector2.one * Random.Range(0.7f, 1.3f);
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Filter.FIR3(transform.localScale, _size);
        if (transform.position.y > 15)
        {
            Destroy(gameObject);
        }
    }
}
