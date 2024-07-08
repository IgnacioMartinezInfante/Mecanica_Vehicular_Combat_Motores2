using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Contador_Enemigos : MonoBehaviour
{
    private int enemyKillCount = 0;
    public int enemiesToWin = 3;

    public TextMeshProUGUI killCountText;
    public GameObject victoryCanvas;

    void Start()
    {
        victoryCanvas.SetActive(false);
        UpdateKillCountText();
    }

    public void IncrementEnemyKillCount()
    {
        enemyKillCount++;
        UpdateKillCountText();

        if (enemyKillCount >= enemiesToWin)
        {
            GameWon();
        }
    }

    void UpdateKillCountText()
    {
        killCountText.text = "Enemies " + enemyKillCount + "/20";
    }

    void GameWon()
    {
        victoryCanvas.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("You won the game!");
        // Aquí puedes implementar la lógica para finalizar el juego, como mostrar una pantalla de victori
    }
}
