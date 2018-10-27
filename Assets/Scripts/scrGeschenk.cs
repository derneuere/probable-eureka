using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrGeschenk : MonoBehaviour
{
  
    public AudioEvent destroysound;
    public GameObject view;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Players"))
        {


            destroysound.Play(GetComponent<AudioSource>());
         
            Destroy(view);
            Destroy(gameObject,3.0f);
            Destroy(this);



        } 
    }

}
