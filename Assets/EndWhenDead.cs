using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndWhenDead : MonoBehaviour
{
    public PlayerScoreBehaviour[] players;
    public VolcanoBehaviour volcano;
    
    // Update is called once per frame
    private void Update()
    {
        foreach (var player in players)
        {
            if (player.lives == 0)
            {
                volcano.enabled = false;
                
                Destroy(this);
            }
        }
    }
}
