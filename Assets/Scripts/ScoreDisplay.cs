using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    GameSession gameSession;
    TextMeshProUGUI scoretext;

    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        scoretext = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        scoretext.text = gameSession.getScore().ToString();
    }
}
