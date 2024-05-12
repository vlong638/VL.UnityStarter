using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VL.Gaming.Unity.Gaming.Ultis;

namespace VL.Gaming.Unity.Gaming.GameSystem
{
    public class GameInitManager : MonoBehaviour
    {
        Image image_curtain;
        public float changingSpeed; // 控制变化速率
        float minAlpha ; // 最小透明度
        float maxAlpha; // 最大透明度
        float currentAlpha;
        float direction; // 控制透明度变化方向
        bool isFading;
        int lootTimes;

        void Start()
        {
            GameObject.Find("Image_Curtain")?.SetActive(false);
        }

        void Update()
        {
            if (!isFading)
                return;
            currentAlpha += direction * changingSpeed * Time.deltaTime;
            if (currentAlpha > maxAlpha)
            {
                currentAlpha = maxAlpha;
                direction = -1.0f;

                lootTimes--;
                if (lootTimes == 0)
                {
                    isFading = false;
                    SceneManager.LoadSceneAsync("Scene_Loading");
                }
            }
            else if (currentAlpha < minAlpha)
            {
                currentAlpha = minAlpha;
                direction = 1.0f;
            }
            image_curtain.color = new Color(image_curtain.color.r, image_curtain.color.g, image_curtain.color.b, currentAlpha);
        }

        public void Continue()
        {
            Debug.Log("Continue");

            Toggle race = GameObject.Find("Prefab_Toggle_MainCategory_Race").GetComponent<Toggle>();
            Toggle profession = GameObject.Find("Prefab_Toggle_MainCategory_Profession").GetComponent<Toggle>();
            Toggle attributes = GameObject.Find("Prefab_Toggle_MainCategory_Attributes").GetComponent<Toggle>();
            Toggle mapSettings = GameObject.Find("Prefab_Toggle_MainCategory_MapSettings").GetComponent<Toggle>();
            if (race.isOn)
            {
                profession.isOn = true;
                return;
            }
            if (profession.isOn)
            {
                attributes.isOn = true;
                return;
            }
            if (attributes.isOn)
            {
                mapSettings.isOn = true;
                return;
            }
            if (mapSettings.isOn)
            {
                GameObject panel_Settings = GameObject.Find("Panel_Settings");
                panel_Settings.SetActive(false);
                GameObject panel_Ready = ResourceHelper.FindInactiveGameObjectByName("Panel_Ready");
                panel_Ready.SetActive(true);
                return;
            }
        }

        public void Return()
        {
            Debug.Log("Return");

            GameObject panel_Ready = GameObject.Find("Panel_Ready");
            panel_Ready.SetActive(false);
            GameObject panel_Settings = ResourceHelper.FindInactiveGameObjectByName("Panel_Settings");
            panel_Settings.SetActive(true);
        }
        public void Confirm()
        {
            Debug.Log("Confirm");
            var go_curtain = ResourceHelper.FindInactiveGameObjectByName("Image_Curtain");
            go_curtain.SetActive(true);
            image_curtain = go_curtain.GetComponent<Image>();
            isFading = true;
            changingSpeed = 1.0f; // 控制变化速率
            minAlpha = 0.0f; // 最小透明度
            maxAlpha = 1.0f; // 最大透明度
            currentAlpha = 0.0f;
            direction = 1.0f; // 控制透明度变化方向
            lootTimes = 3;
        }
    }
}
