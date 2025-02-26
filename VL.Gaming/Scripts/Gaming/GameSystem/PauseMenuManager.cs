using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VL.Gaming.Scripts.Gaming.Tools;
using VL.Gaming.Scripts.Utils;

namespace VL.Gaming.Scripts.Gaming.GameSystem
{
    public class PauseMenuManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject pauseMenuCanvas; // 拖拽绑定
        private bool isPaused = false;

        void Awake()
        {
            pauseMenuCanvas = VLResourceHelper.FindGameObjectByName("Canvas_PauseMenu");
        }

        void Start()
        {
            if (pauseMenuCanvas != null)
                pauseMenuCanvas.SetActive(false);

            //Continue
            var gameObject = VLResourceHelper.FindGameObjectByName(VLDictionaries.VLButtonsDic[VLButtons.Continue]);
            gameObject?.GetComponent<Button>()?.onClick.AddListener(() => Continue());
            //Save
            gameObject = VLResourceHelper.FindGameObjectByName(VLDictionaries.VLButtonsDic[VLButtons.Save]);
            gameObject?.GetComponent<Button>()?.onClick.AddListener(() => SaveGameData());
            //Load
            gameObject = VLResourceHelper.FindGameObjectByName(VLDictionaries.VLButtonsDic[VLButtons.Load]);
            gameObject?.GetComponent<Button>()?.onClick.AddListener(() => LoadGameData());
            //StartMenu
            gameObject = VLResourceHelper.FindGameObjectByName(VLDictionaries.VLButtonsDic[VLButtons.StartMenu]);
            gameObject?.GetComponent<Button>()?.onClick.AddListener(() => BackToStartMenu());
            //Quit
            gameObject = VLResourceHelper.FindGameObjectByName(VLDictionaries.VLButtonsDic[VLButtons.Quit]);
            gameObject?.GetComponent<Button>()?.onClick.AddListener(() => QuitGame());
        }

        private void Continue()
        {
            TogglePause();
        }
        public void LoadGameData()
        {
            GameDataManager.LoadGameData();
            TogglePause();
        }

        public void SaveGameData()
        {
            GameDataManager.SaveGameData();
            TogglePause();
        }
        public void BackToStartMenu()
        {
            TogglePause();
            SceneManager.LoadScene(VLDictionaries.VLScenesDic[VLScenes.StartMenu]);
        }
        public void QuitGame()
        {
            Application.Quit();
        }

        void Update()
        {
            // 检测 ESC 键按下
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePause();
            }
        }

        public void TogglePause()
        {
            isPaused = !isPaused;

            // 显示/隐藏暂停菜单
            pauseMenuCanvas.SetActive(isPaused);

            // 暂停/恢复游戏逻辑
            Time.timeScale = isPaused ? 0f : 1f;

            // 控制鼠标（如果是 3D 游戏）
            Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = isPaused;
        }
    }
}
