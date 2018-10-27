using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrGeschenk : MonoBehaviour
{


   
    public AudioEvent destroysound;
    public GameObject view;
    public GameObject magicpoofGeschenk;
    private GameManager gameManager;
    // Start is called before the first frame update
    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Players"))
        {


            destroysound.Play(GetComponent<AudioSource>());

            GameObject temp = Instantiate(magicpoofGeschenk,transform,false);

            temp.gameObject.transform.localScale = new Vector3(5,5,5);

            gameManager.startDegree = gameManager.startDegree - 2;

            Destroy(view);

            Destroy(gameObject,3.0f);

            Destroy(this);

            ScreenShakeProfile.trauma = 1.0f;



        } 
    }

}
