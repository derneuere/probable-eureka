using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float startDegree;
    public float looseDegree;
    public float degreeIncrement;

    public float livePoints;
    public DegreeUI degreeUI;
    public LifePoints lifePointsUI;
    public EndTextUI endTextUI;

    // Update is called once per frame
    void Update()
    {
        if (livePoints <= 0 || startDegree > looseDegree) {
            //To-Do: Loose
            Time.timeScale = 0;
            endTextUI.loose();
        }
        
        startDegree = startDegree + (Time.deltaTime * degreeIncrement);
        degreeUI.SetDegree(startDegree);
        lifePointsUI.SetLife(livePoints);
    }

    public void win() {

        Time.timeScale = 0;
        endTextUI.win();
        
    }

    bool winningCondition() {
        //To-Do
        return false;
    }
}
