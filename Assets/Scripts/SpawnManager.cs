using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float cactusSmallSpawn = -2.45f;
    private float cactusBigSpawn = -2.12f;
    private float pterodactylSpawnUpper = 3.0f;
    private float pterodactylSpawnLower = -2.0f;
    private float startTime = 3.0f;
    private float repeatTime = 3.0f;

    public GameObject[] obstacles;

    void Start()
    {
        InvokeRepeating("SpawnObstacles", startTime, repeatTime);
    }

    private void SpawnObstacles()
    {
        if (!GameManager.Instance.gameOver)
        {
            int lastIndex = obstacles.Length - 1;
            int index = Random.Range(0, obstacles.Length);

            if (index == lastIndex && GameManager.Instance.score > 200)
            {
                Instantiate(obstacles[lastIndex], new Vector2(transform.position.x,
                    Random.Range(pterodactylSpawnLower, pterodactylSpawnUpper)), Quaternion.identity);
            }
            else
            {
                int randomCactus = Random.Range(0, lastIndex);

                if (randomCactus == 0)
                    Instantiate(obstacles[randomCactus], new Vector2(transform.position.x, cactusSmallSpawn), Quaternion.identity);
                else
                    Instantiate(obstacles[randomCactus], new Vector2(transform.position.x, cactusBigSpawn), Quaternion.identity);
            }
        }
    }
}
