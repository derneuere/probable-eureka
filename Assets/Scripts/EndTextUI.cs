using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndTextUI : MonoBehaviour
{
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        text.SetText("");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void win() {
        text.SetText("GEWONNEN");
    }

    public void loose()
    {
        text.SetText("VERLOREN");
    }
}
