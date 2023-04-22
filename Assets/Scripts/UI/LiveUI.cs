using UnityEngine;
using UnityEngine.UI;

public class LiveUI : MonoBehaviour
{
    [SerializeField] private Text livesText;

    private void Update()
    {
        livesText.text = PlayerStats.lives.ToString() + " LIVES";
    }
}
