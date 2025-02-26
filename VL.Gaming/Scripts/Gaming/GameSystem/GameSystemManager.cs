using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VL.Gaming.Scripts.Gaming.Tools;
using VL.Gaming.Scripts.Tools;
using VL.Gaming.Scripts.Utils;

namespace VL.Gaming.Scripts.Gaming.GameSystem
{
    public class GameSystemManager : MonoBehaviour
    {
        public GameObject pauseMenu;

        void Awake()
        {
            pauseMenu = VLResourceHelper.FindGameObjectByName("Canvas_PauseMenu");
        }

        void Start()
        {
            if (pauseMenu != null)
                pauseMenu.SetActive(false);

            //StartGame
            var gameObject = VLResourceHelper.FindGameObjectByName(VLDictionaries.VLButtonsDic[VLButtons.StartGame]);
            gameObject?.GetComponent<Button>()?.onClick.AddListener(() => StartGame());
            //Save
            gameObject = VLResourceHelper.FindGameObjectByName(VLDictionaries.VLButtonsDic[VLButtons.Save]);
            gameObject?.GetComponent<Button>()?.onClick.AddListener(() => SaveGameData());
            //Load
            gameObject = VLResourceHelper.FindGameObjectByName(VLDictionaries.VLButtonsDic[VLButtons.Load]);
            gameObject?.GetComponent<Button>()?.onClick.AddListener(() => LoadGameData());
            //Config
            //Quit
            gameObject = VLResourceHelper.FindGameObjectByName(VLDictionaries.VLButtonsDic[VLButtons.Quit]);
            gameObject?.GetComponent<Button>()?.onClick.AddListener(() => QuitGame());
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePauseMenu();
            }
            //if (Input.GetKeyDown(KeyCode.F5))
            //{
            //    SaveGameData();
            //}
            //if (Input.GetKeyDown(KeyCode.F8))
            //{
            //    LoadGameData();
            //}
            if (Input.GetKeyDown(KeyCode.C))
            {
                DialogueBoxManager.Instance.StartDialogue(1);
            }
        }

        #region Gaming

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
            SceneManager.LoadScene("Scene_StartGame");
        }
        public void QuitGame()
        {
            Application.Quit();
        }

        #endregion

    }
}
