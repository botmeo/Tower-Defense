using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameIsOver = false;

    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject completeLevelUI;

    private void Start()
    {
        gameIsOver = false;
    }

    private void Update()
    {
        if (gameIsOver)
        {
            return;
        }

        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }

        if (PlayerStats.lives <= 0)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        gameIsOver = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        gameIsOver = true;
        completeLevelUI.SetActive(true);
    }

    public void Restart()
    {
        WaweSpawer.enemiesAlive = 0;
    }
}
