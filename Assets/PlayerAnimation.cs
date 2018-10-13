using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private PlayerController _controller;
    private AreaEffector2D _effector;

    private float speed;
    private float weight;

    private float magnitude;
    private float variation;
    
    // Start is called before the first frame update
    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _effector = GetComponentInChildren<AreaEffector2D>();
        _controller = GetComponentInParent<PlayerController>();

        magnitude = _effector.forceMagnitude;
        variation = _effector.forceVariation;
    }

    private void Update()
    {
        _effector.forceMagnitude = Filter.FIR(_effector.forceMagnitude, magnitude * _controller.input.magnitude);
        _effector.forceVariation = Filter.FIR(_effector.forceVariation, variation * _controller.input.magnitude, 0.99f);
        
        weight = Filter.FIR(weight, _controller.input.magnitude * 3.0f);
        speed = Filter.FIR(speed, _controller.input.magnitude * 2.0f, 0.95f);
        _animator.SetLayerWeight(2, Mathf.Clamp01(weight));
        _animator.SetFloat("WobbleSpeed", speed);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Blob") || other.gameObject.CompareTag("Player"))  _animator.SetTrigger("Pulse");
    }
}
