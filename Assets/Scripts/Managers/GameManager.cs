using UnityEngine;
using UnityEngine.SceneManagement;

namespace JK.Roguelike
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }


        private void Awake()
        {
            DontDestroyOnLoad(gameObject);

            if(Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        public void LoadNewGame() => SceneManager.LoadScene(1);

        private void OnLevelWasLoaded(int level)
        {
            if (level == 1)
                GridGenerator.Instance.StartGeneration();
        }
    }
}