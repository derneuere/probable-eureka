using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private PlayerController _controller;
    private Rigidbody2D _rigidbody;

    private float speed;
    private float weight;
    
    // Start is called before the first frame update
    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _controller = GetComponentInParent<PlayerController>();
    }

    private void Update()
    {
        weight = Filter.FIR(weight, _controller.input.magnitude * 3.0f);
        speed = Filter.FIR(speed, _controller.input.magnitude * 2.0f, 0.95f);
        _animator.SetLayerWeight(2, Mathf.Clamp01(weight));
        _animator.SetFloat("WobbleSpeed", speed);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _animator.SetTrigger("Pulse");
    }
}
