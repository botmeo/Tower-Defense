using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] private Text moneyText;

    private void Update()
    {
        moneyText.text = "MONEY: $" + PlayerStats.money.ToString();
    }
}
