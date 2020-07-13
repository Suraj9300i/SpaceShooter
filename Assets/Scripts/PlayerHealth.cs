using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    Player player;
    TextMeshProUGUI healthtext;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        healthtext = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        healthtext.text = player.getPlayerHealth().ToString();
    }
}
