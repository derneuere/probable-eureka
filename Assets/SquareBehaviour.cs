using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareBehaviour : MonoBehaviour
{
    public bool Dead;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!Dead)
        {
            Dead = true;
            GetComponentInChildren<SpriteRenderer>().sprite = null;
            Destroy(other.gameObject);
        }
    }
}
