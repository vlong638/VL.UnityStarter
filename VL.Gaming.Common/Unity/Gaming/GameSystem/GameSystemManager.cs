using UnityEngine;
using UnityEngine.SceneManagement;

namespace VL.Gaming.Unity.Gaming.GameSystem
{
    public class GameSystemManager : MonoBehaviour
    {
        public GameObject pauseMenu;

        void Start()
        {
            if (pauseMenu != null)
                pauseMenu.SetActive(false);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePauseMenu();
            }
            if (Input.GetKeyDown(KeyCode.F5))
            {
                SaveGameData();
            }
            if (Input.GetKeyDown(KeyCode.F8))
            {
                LoadGameData();
            }
        }

        public void LoadGameData()
        {
            GameDataManager.LoadGameData();
            ClosePauseMenu();
        }

        public void SaveGameData()
        {
            GameDataManager.SaveGameData();
            ClosePauseMenu();
        }

        #region Gaming

        private void ClosePauseMenu()
        {
            if (pauseMenu.activeSelf)
                TogglePauseMenu();
        }

        public void TogglePauseMenu()
        {
            if (pauseMenu == null)
                return;

            bool isPaused = !pauseMenu.activeSelf;
            pauseMenu.SetActive(isPaused);
            Time.timeScale = isPaused ? 0 : 1;
        }

        public void SwitchToStartMenu()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Scene_StartMenu");
        } 

        #endregion

        #region StartMenu

        public void StartGame()
        {
            SceneManager.LoadScene("Scene_GameInit");
        }
        public void QuitGame()
        {
            Application.Quit();
        }

        #endregion

    }
}
