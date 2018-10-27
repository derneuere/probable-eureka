using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrGeschenk : MonoBehaviour
{
  
    public AudioEvent destroysound;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Players"))
        {

            destroysound.Play(GetComponent<AudioSource>());
            Destroy(gameObject,1.0f);
            Destroy(this);



        } 
    }
}
