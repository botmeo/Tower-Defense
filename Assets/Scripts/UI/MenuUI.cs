using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Select level");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
