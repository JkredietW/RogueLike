using System.Collections.Generic;
using System;
using UnityEngine;
using Unity.VisualScripting;

namespace JK.Roguelike
{
    public class Spawner : MonoBehaviour
    {
        public static Spawner Instance { get; private set; }

        [SerializeField] private float minSpawnRange = 10;
        [SerializeField] private List<Wave> waves;

        private int enemiesAlive;
        private int currentWave;

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
            // fix not spawning on player

            return new Vector2(UnityEngine.Random.Range(-10,10), UnityEngine.Random.Range(-10, 10));
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