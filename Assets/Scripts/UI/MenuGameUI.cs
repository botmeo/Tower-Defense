using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameUI : MonoBehaviour
{
    public void Retry()
    {
        WaweSpawer.enemiesAlive = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Continue(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void SelectLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void Menu()
    {
        WaweSpawer.enemiesAlive = 0;
        SceneManager.LoadScene("Menu");
    }
}
