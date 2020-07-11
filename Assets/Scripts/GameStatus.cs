﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 0f;

    [SerializeField] int pointsPerBlockDestroyed = 50;
    [SerializeField] int currentScore = 0;
    [SerializeField] Text scoreText;


    private void Start()
    {
        scoreText.text = currentScore.ToString();    
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void UpdateScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }
}
