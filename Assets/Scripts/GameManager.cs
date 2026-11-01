using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject winPanel;
    public GameObject restartPanel;

    [Header("Win Texts")]
    public GameObject p1WinsText;
    public GameObject p2WinsText;

    [Header("Players")]
    public PlayerHealth player1;
    public PlayerHealth player2;

    public bool gameEnded = false;

    void Start()
    {
        Time.timeScale = 1f;

        winPanel.SetActive(false);
        restartPanel.SetActive(false);

        p1WinsText.SetActive(false);
        p2WinsText.SetActive(false);
    }

    public void PlayerDied(PlayerHealth deadPlayer)
    {
        if (gameEnded) return;

        gameEnded = true;

        winPanel.SetActive(true);
        restartPanel.SetActive(true);

        if (deadPlayer == player1)
        {
            p2WinsText.SetActive(true);
        }
        else
        {
            p1WinsText.SetActive(true);
        }

        Time.timeScale = 0f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}