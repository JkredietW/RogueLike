using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace JK.Roguelike
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private GameDifficulty[] difficultyConfigs;

        [SerializeField] private Transform projectileParent;

        public Transform ProjectileParent => projectileParent;

        public GameDifficulty SelectedDifficulty { get; private set; }

        public GameObject SpawnedPlayer { get; private set; }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);

            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        public void LoadNewGame(int nextScene = 1, int difficulty = 0)
        {
            SelectedDifficulty = difficultyConfigs[difficulty];
            if (nextScene == 1)
            {
                SceneManager.LoadScene(nextScene);
            }
            else if (nextScene == 2)
            {
                SceneManager.LoadScene(nextScene, LoadSceneMode.Additive);
                StartCoroutine(SpawnInPlayer());
            }
        }

        public void UnloadScene() => SceneManager.UnloadSceneAsync(2);

        private void OnLevelWasLoaded(int level)
        {
            if (level == 1)
                GridGenerator.Instance.StartGeneration();
        }

        public IEnumerator SpawnInPlayer()
        {
            Scene playScene = SceneManager.GetSceneByBuildIndex(2);
            while (!playScene.isLoaded)
                yield return null;

            SpawnedPlayer = Instantiate(playerPrefab);
            //SpawnedPlayer.GetComponent<PlayerStats>().UpdateStats();
            Spawner.Instance.StartSpawning();
        }

        public void RemovePlayer()
        {
            RemoveProjectiles();
            Destroy(SpawnedPlayer);
        }

        public void ToggleLevelSelectUI(bool value = false)
        {
            GridGenerator.Instance.gameObject.SetActive(value);
        }

        public void RemoveProjectiles()
        {
            foreach (Transform projectile in projectileParent)
                Destroy(projectile.gameObject);
        }
    }
}