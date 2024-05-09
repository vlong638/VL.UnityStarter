﻿using UnityEngine;
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

        public void TogglePauseMenu()
        {
            if (pauseMenu == null)
                return;

            bool isPaused = !pauseMenu.activeSelf;
            pauseMenu.SetActive(isPaused);
            Time.timeScale = isPaused ? 0 : 1;
        }

        public void SwitchToGaming()
        {
            SceneManager.LoadScene("Scene_Gaming");
        }

        public void SwitchToStartMenu()
        {
            SceneManager.LoadScene("Scene_StartMenu");
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
