using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SquareBehaviour : MonoBehaviour
{
    public bool Dead;
    
    public List<Sprite> healthLevels;

    public UnityEvent SquareDied;

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
                SquareDied.Invoke();
                GetComponentInChildren<SpriteRenderer>().sprite = null;                
            }

            Destroy(other.gameObject);
            
            other.GetComponent<BubbleSpawner>().Explode();
            ScreenShake.magnitude = 1.0f;
        }
        else
        {
            //Kaboom();
        }
    }
}
