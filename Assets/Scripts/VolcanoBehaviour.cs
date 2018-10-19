using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class VolcanoBehaviour : MonoBehaviour
{
    public GameObject[] LavaPrefabs;

    public Transform Emitter;

    public float MinTime = 1.0f;
    public float MaxTime = 5.0f;

    public float Force = 2.0f;
    public float Spread = 1.0f;

    private float _time = 0;


    private void Start()
    {
        _time = 5.0f;
    }
    
    // Update is called once per frame
    private void Update()
    {
        _time -= Time.deltaTime;
        if (!(_time <= 0)) return;

        ScreenShake.trauma= 0.5f;
        
        _time = Random.Range(MinTime, MaxTime);

        Vector2 off = Vector2.up + Vector2.right * Random.Range(-Spread, Spread);
        var pos = (Vector2) Emitter.position + off;
        off.x = -off.x;
        off.y = Math.Abs(off.y);

        var go = Instantiate(LavaPrefabs.Pick(), pos, Quaternion.identity);

        var rb = go.GetComponent<Rigidbody2D>();
        rb.AddForce(Force * off, ForceMode2D.Impulse);
        rb.AddTorque(Random.Range(-Spread, Spread), ForceMode2D.Impulse);
    }
}
