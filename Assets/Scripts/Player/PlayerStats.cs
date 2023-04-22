using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public int startMoney = 400;

    public static int lives;
    public int startLives = 20;

    public static int rounds;

    private void Start()
    {
        money = startMoney;
        lives = startLives;
        rounds = 0;
    }
}
