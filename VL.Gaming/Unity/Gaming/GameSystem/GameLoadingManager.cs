﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VL.Gaming.Unity.Gaming.Tools;

namespace VL.Gaming.Unity.Gaming.GameSystem
{
    internal class GameLoadingManager : MonoBehaviour
    {
        [SerializeField]
        public string targetSceneName= "Scene_Gaming";
        public Slider progressBar;
        public Text progressText;

        void Awake()
        {
            progressBar = VLResourceHelper.FindGameObjectByName("Slider_ProgressBar").GetComponent<Slider>();
            progressText = VLResourceHelper.FindGameObjectByName("Text_ProgressBar").GetComponent<Text>();
        }

        void Start()
        {
            Debug.Log("GameLoadingManager Start()");
            StartCoroutine(Wait3());

            //StartCoroutine(LoadAsyncOperation());
        }

        IEnumerator Wait3()
        {
            progressBar.value = 0.33f;
            progressText.text = "Loading:33%";
            yield return new WaitForSecondsRealtime(1);

            progressBar.value = 0.66f;
            progressText.text = "Loading:66%";
            yield return new WaitForSecondsRealtime(1);

            progressBar.value = 0.99f;
            progressText.text = "Loading:99";
            yield return new WaitForSecondsRealtime(1);

            SceneManager.LoadSceneAsync(targetSceneName);
        }

        IEnumerator LoadAsyncOperation()
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(targetSceneName);
            asyncLoad.allowSceneActivation = false;
            float totalTime = 3f; // 总共持续时间为3秒
            float currentTime = 0f;
            float startProgress = 0f;
            float endProgress = 0.9f;
            while (currentTime < totalTime)
            {
                float progress = Mathf.Lerp(startProgress, endProgress, currentTime / totalTime); // 使用插值函数实现匀速增加
                progressBar.value = progress;
                progressText.text = "Loading: " + (progress * 100f).ToString("F0") + "%";

                if (asyncLoad.progress >= 0.9f)
                {
                    asyncLoad.allowSceneActivation = true;
                }

                currentTime += Time.deltaTime;
                yield return null;
            }


            // 确保加载完整
            progressBar.value = 1f;
            progressText.text = "Loading: 100%";
            asyncLoad.allowSceneActivation = true;
        }
    }
}
