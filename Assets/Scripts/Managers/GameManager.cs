using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace JK.Roguelike
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [SerializeField] private GameObject playerPrefab;

        public GameObject SpawnedPlayer { get; private set; }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);

            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        public void LoadNewGame(int nextScene = 1)
        {
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
            Spawner.Instance.StartSpawning();
        }

        public void RemovePlayer()
        {
            Destroy(SpawnedPlayer);
        }

        public void ToggleLevelSelectUI(bool value = false)
        {
            GridGenerator.Instance.gameObject.SetActive(value);
        }
    }
}