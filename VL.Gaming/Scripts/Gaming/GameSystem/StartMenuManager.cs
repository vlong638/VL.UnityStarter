using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VL.Gaming.Scripts.Gaming.Tools;
using VL.Gaming.Scripts.Utils;

namespace VL.Gaming.Scripts.Gaming.GameSystem
{
    public class GameSystemManager : MonoBehaviour
    {
        void Awake()
        {
        }

        void Start()
        {
            //StartGame
            var gameObject = VLResourceHelper.FindGameObjectByName(VLDictionaries.VLButtonsDic[VLButtons.StartGame]);
            gameObject?.GetComponent<Button>()?.onClick.AddListener(() => StartGame());
            //Config
            //Quit
            gameObject = VLResourceHelper.FindGameObjectByName(VLDictionaries.VLButtonsDic[VLButtons.Quit]);
            gameObject?.GetComponent<Button>()?.onClick.AddListener(() => QuitGame());
        }

        void Update()
        {
        }

        public void StartGame()
        {
            SceneManager.LoadScene("Scene_StartGame");
        }
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
