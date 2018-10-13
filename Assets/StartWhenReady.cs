using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWhenReady : MonoBehaviour
{
    public PlayerControls pc;
    public VolcanoBehaviour volcano;
    
    // Update is called once per frame
    private void Update()
    {
        if (pc._unassignedPlayers.Count == 0)
        {
            volcano.enabled = true;
            GetComponent<AudioSource>().Play();
            Destroy(this);
        }
    }
}
