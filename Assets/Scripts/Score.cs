using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private int ScoreValue { get; set; }

    public void ResetScore()
    {
        ScoreValue = 0;
    }

    public void IncrementScore()
    {
        ScoreValue++;
    }
} 
