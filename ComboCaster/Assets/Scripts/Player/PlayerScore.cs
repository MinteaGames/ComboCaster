using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int score;

    public static PlayerScore Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void AddScore(int enemyPoints)
    {
        score += enemyPoints * GetComponent<ComboManager>().playerCombo;
    }
}
