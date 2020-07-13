using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    GameSession game;
    int Score = 0;
    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AddtoScore(int value)
    {
        Score += value;
    }

    public int getScore()
    {
        return Score;
    }

    public void resetGame()
    {
        Destroy(gameObject);
    }
}
