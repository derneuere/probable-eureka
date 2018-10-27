using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FassCollision : MonoBehaviour
{

    public AudioEvent destroysound;
    public GameObject view;
    public GameObject magicpoofGeschenk;

    private GameManager gameManager;
    // Start is called before the first frame update
    public void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Players"))
        {


            destroysound.Play(GetComponent<AudioSource>());
            GameObject temp = Instantiate(magicpoofGeschenk, transform, false);
            temp.gameObject.transform.localScale = new Vector3(5, 5, 5);
            gameManager.livePoints = gameManager.livePoints - 1;
            Destroy(view,0.0f);
            Destroy(gameObject, 2.0f);
            Destroy(this);
            ScreenShakeProfile.trauma = 1.0f;



        }
    }

}

