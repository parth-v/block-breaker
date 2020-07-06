using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 0f;

    [SerializeField] int pointsPerBlockDestroyed = 50;
    [SerializeField] int currentScore = 0;

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void UpdateScore()
    {
        currentScore += pointsPerBlockDestroyed;
    }
}
