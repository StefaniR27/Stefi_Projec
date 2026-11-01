using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenOptions()
    {
        Debug.Log("Options opened");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game closed");
    }
}