using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareBehaviour : MonoBehaviour
{
    public bool Dead;
    public PlayerController owner;
    
    public List<Sprite> healthLevels;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!Dead)
        {
            Dead = healthLevels.Count == 0;

            if (!Dead)
            {
                GetComponentInChildren<SpriteRenderer>().sprite = healthLevels.First();
                healthLevels.RemoveAt(0);                
            }
            else
            {
                GetComponentInChildren<SpriteRenderer>().sprite = null;                
            }

            Destroy(other.gameObject);

        }
        else
        {
            //Kaboom();
        }
    }
}
