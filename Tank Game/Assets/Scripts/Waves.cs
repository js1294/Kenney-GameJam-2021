using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Waves : MonoBehaviour
{
    public List<GameObject> enemies;
    public List<Transform> spawns;
    private float time = 0f;
    public float periodWaves;
    private int wave = 1;
    private float initializationTime;
    public Text waveText;
    public Text winText;
    public AudioSource newWave;

    void Start()
    {
        initializationTime = Time.timeSinceLevelLoad;
    }

    void Update()
    {
        float timeSinceInitialization = Time.timeSinceLevelLoad - initializationTime;
        //time seconds have passed spawn more
        if (time <= timeSinceInitialization)
        {
            switch(wave)
            {
                case 1:
                    SpawnEnemy(0);
                    break;
                case 2:
                    SpawnEnemy(0);
                    SpawnEnemy(1);
                    break;
                case 3:
                    SpawnEnemy(0);
                    SpawnEnemy(0);
                    SpawnEnemy(0);
                    SpawnEnemy(0);
                    SpawnEnemy(0);
                    break;
                case 4:
                    SpawnEnemy(1);
                    SpawnEnemy(1);
                    SpawnEnemy(1);
                    SpawnEnemy(1);
                    SpawnEnemy(1);
                    break;
                case 5:
                    SpawnEnemy(0);
                    SpawnEnemy(0);
                    SpawnEnemy(1);
                    SpawnEnemy(1);
                    SpawnEnemy(1);
                    SpawnEnemy(1);
                    SpawnEnemy(1);
                    break;
                case 6:
                    SpawnEnemy(0);
                    SpawnEnemy(1);
                    SpawnEnemy(1);
                    SpawnEnemy(1);
                    SpawnEnemy(1);
                    SpawnEnemy(1);
                    SpawnEnemy(1);
                    SpawnEnemy(1);
                    SpawnEnemy(1);
                    SpawnEnemy(1);
                    break;
                case 7:
                    SpawnEnemy(2);
                    break;
                case 8:
                    SpawnEnemy(2);
                    SpawnEnemy(2);
                    break;
                case 9:
                    SpawnEnemy(0);
                    SpawnEnemy(0);
                    SpawnEnemy(1);
                    SpawnEnemy(1);
                    SpawnEnemy(2);
                    break;
                case 10:
                    SpawnEnemy(0);
                    SpawnEnemy(0);
                    SpawnEnemy(1);
                    SpawnEnemy(1);
                    SpawnEnemy(1);
                    SpawnEnemy(1);
                    SpawnEnemy(1);
                    SpawnEnemy(0);
                    SpawnEnemy(0);
                    SpawnEnemy(1);
                    SpawnEnemy(1);
                    SpawnEnemy(1);
                    SpawnEnemy(1);
                    SpawnEnemy(2);
                    break;
                case int n when (n > 10):
                    Time.timeScale = 0;
                    winText.text = "You Win!";
                    break;
            }
            wave++;
            newWave.Play();
            time += periodWaves;
            int correctedWave = wave-1;
            waveText.text = "Wave "+correctedWave.ToString();
        }
    }
    private void SpawnEnemy(int type)
    {
        int randPosition = Random.Range(0,spawns.Count);
        Instantiate(enemies[type],spawns[randPosition].position,spawns[randPosition].rotation);
    }
}
