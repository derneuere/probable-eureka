using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifePoints : MonoBehaviour
{
    public Image[] lives;

    public void SetLife(float leben)
    {
        int i = 0;
        foreach(Image l in lives){
            if(i < leben){
                l.enabled = true;
            }
            else{
                l.enabled = false;
            }
            i++;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
