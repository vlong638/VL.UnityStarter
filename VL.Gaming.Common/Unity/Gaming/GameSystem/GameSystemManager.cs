using UnityEngine;
using UnityEngine.SceneManagement;
using VL.Gaming.Unity.Gaming.DisplayManage;

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
            if (Input.GetKeyDown(KeyCode.C))
            {
                DialogueBoxManager.Instance.StartDialogue(1);
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

        /// <summary>
        /// 关闭暂停界面
        /// </summary>
        private void ClosePauseMenu()
        {
            if (pauseMenu.activeSelf)
                TogglePauseMenu();
        }
        /// <summary>
        /// 切换暂停界面
        /// </summary>
        public void TogglePauseMenu()
        {
            if (pauseMenu == null)
                return;

            bool isPaused = !pauseMenu.activeSelf;
            pauseMenu.SetActive(isPaused);
            Time.timeScale = isPaused ? 0 : 1;
        }
        /// <summary>
        /// 跳回开始界面
        /// </summary>
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
