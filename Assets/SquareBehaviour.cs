using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareBehaviour : MonoBehaviour
{
    public bool Dead;

    public Sprite[] corpses;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!Dead)
        {
            Dead = true;
            GetComponentInChildren<SpriteRenderer>().sprite = corpses.Pick();

            Destroy(other.gameObject);
        }
        else
        {
            //Kaboom();
        }
    }
}
