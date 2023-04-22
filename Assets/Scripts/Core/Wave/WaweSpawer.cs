using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaweSpawer : MonoBehaviour
{
    public static int enemiesAlive = 0;
    public Wave[] waves;

    [SerializeField] private GameManager gameManager;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Text waveCountdownText;
    [SerializeField] private float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private int waveIndex = 0;

    private void Update()
    {
        if (enemiesAlive > 0)
        {
            return;
        }

        if (waveIndex == waves.Length && PlayerStats.lives > 0)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        if (waveIndex == waves.Length && PlayerStats.lives <= 0)
        {
            gameManager.EndGame();
            this.enabled = false;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = "NEXT WAVE: " + string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        // Not random
        /*PlayerStats.rounds++;
        Wave wave = waves[waveIndex];
        enemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveIndex++;*/

        // Random
        PlayerStats.rounds++;
        Wave wave = waves[waveIndex];
        enemiesAlive = wave.count;
        int totalEnemyCount = wave.count;

        // Loop until all enemies in the wave have been spawned
        while (totalEnemyCount > 0)
        {
            // Choose a random enemy type from the wave
            int enemyIndex = Random.Range(0, wave.enemy.Length);
            GameObject enemyPrefab = wave.enemy[enemyIndex];

            // If there are no more of this enemy type to spawn, skip it
            if (wave.count <= 0)
            {
                continue;
            }

            // Spawn the enemy and decrement the wave count
            SpawnEnemy(enemyPrefab);
            wave.count--;
            totalEnemyCount--;

            // Wait for the next enemy to spawn based on the wave's rate
            yield return new WaitForSeconds(1f / wave.rate);

            if (totalEnemyCount == 0)
            {
                wave.enemy[enemyIndex] = null;
            }
        };

        waveIndex++;
    }

    private void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
