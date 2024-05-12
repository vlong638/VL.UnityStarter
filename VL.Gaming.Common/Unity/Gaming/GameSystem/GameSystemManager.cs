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
        }

        #region Gaming

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
