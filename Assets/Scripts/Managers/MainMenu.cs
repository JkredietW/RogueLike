using System.Collections.Generic;
using UnityEngine;

namespace JK.Roguelike.MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject[] allWindows;

        public void StartGame() => GameManager.Instance.LoadNewGame();

        public void QuitGame() => Application.Quit();

        public void OpenWindow(GameObject windowToOpen)
        {
            CloseAllWindows();
            windowToOpen.SetActive(true);
        }

        public void CloseAllWindows()
        {
            foreach (GameObject window in allWindows)
                window.SetActive(false);
        }
    }
}