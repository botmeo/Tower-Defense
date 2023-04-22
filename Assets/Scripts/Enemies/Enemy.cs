using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    public float speed;
    [SerializeField] private float startHealth;
    private float health;
    [SerializeField] private int prize = 35;
    [SerializeField] private GameObject deathEffect;
    [SerializeField] private Image heathBar;
    private bool isDead = false;

    private void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }

    public void TakeDamage(float value)
    {
        health -= value;
        heathBar.fillAmount = health / startHealth;
        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void Slow(float value)
    {
        speed = startSpeed * (1f - value);
    }

    private void Die()
    {
        isDead = true;
        PlayerStats.money += prize;
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(effect, 5f);
        WaweSpawer.enemiesAlive--;
        Destroy(gameObject);
    }
}
