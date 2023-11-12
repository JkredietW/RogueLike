using System.Collections.Generic;
using System;
using UnityEngine;
using Unity.VisualScripting;
using System.Linq;

namespace JK.Roguelike
{
    public class Spawner : MonoBehaviour
    {
        public static Spawner Instance { get; private set; }

        [SerializeField] private float minSpawnRange = 10;
        [SerializeField] private List<Wave> waves;

        private int enemiesAlive;
        private int currentWave;
        private int[] exlucedSpawnLocations = { -1, 0, 1 };

        private void Awake()
        {
            Instance = this;
        }

        public void StartSpawning()
        {
            if(currentWave > waves.Count - 1)
            {
                currentWave = 0;

                // Rewards?
                GameManager.Instance.RemovePlayer();
                GameManager.Instance.ToggleLevelSelectUI(true);
                GameManager.Instance.UnloadScene();
                return;
            }

            List<WavePart> parts = waves[currentWave++].part;
            for (int i = 0; i < parts.Count; i++)
            {
                SpawnEnemy(parts[i]);
            }

            currentWave++;
        }

        private void SpawnEnemy(WavePart part)
        {
            for (int i = 0; i < part.amount; i++)
            {
                Instantiate(part.enemy, GetRandomSpawnLocation(), Quaternion.identity);
                enemiesAlive++;
            }
        }

        private Vector2 GetRandomSpawnLocation()
        {
            List<Vector2> spawnLocations = new List<Vector2>();
            for (int x = -10; x < 11; x++)
            {
                for (int y = -10; y < 11; y++)
                {
                    if (!exlucedSpawnLocations.Contains(x) || !exlucedSpawnLocations.Contains(y))
                        spawnLocations.Add(new(x, y));
                }
            }

            return spawnLocations[UnityEngine.Random.Range(0, spawnLocations.Count - 1)];
        }

        public void EnemyDied()
        {
            enemiesAlive--;
            if (enemiesAlive == 0)
                StartSpawning();
        }
    }

    [Serializable]
    public class Wave
    {
        public List<WavePart> part;
    }

    [Serializable]
    public class WavePart
    {
        public GameObject enemy;
        public float amount;
    }
}