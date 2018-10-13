using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class PlayerScoreBehaviour : MonoBehaviour
{
    public SquareBehaviour[] squares;
    public TextMeshPro score;
    public int lives;
    
    private void Start()
    {
        foreach (var s in squares)
        {
            s.SquareDied.AddListener(OnChanged);
        }

        lives = squares.Length + 1;
        
        OnChanged();
    }

    private void OnChanged()
    {
        lives--;

        if (lives > 0)
        {
            StringBuilder s = new StringBuilder();

            for (var i = 0; i < lives; i++) s.Append("X");
            score.text = s.ToString();            
        }
        else
        {
            score.text = "Haha!\nYour floor\nis LAVA!";
        }
        
    }
}
