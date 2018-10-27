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

    // Update is called once per frame
    void Update()
    {
        if (livePoints <= 0 || startDegree > looseDegree) {
            //To-Do: Loose
        }
        if (winningCondition()) {
             //To-Do: Win
        }
        startDegree = startDegree + (Time.deltaTime * degreeIncrement);
        degreeUI.SetDegree(startDegree);
        lifePointsUI.SetLife(livePoints);
    }

    bool winningCondition() {
        //To-Do
        return false;
    }
}
