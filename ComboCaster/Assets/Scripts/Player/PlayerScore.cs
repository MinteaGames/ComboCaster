using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public int score;

    public Text scoreText;

    public static PlayerScore Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void AddScore(int enemyPoints)
    {
        score += enemyPoints * GetComponent<ComboManager>().playerCombo;
        scoreText.text = score.ToString();
    }
}
