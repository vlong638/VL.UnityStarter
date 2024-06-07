using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VL.Gaming.Unity.Gaming.Ultis;

namespace VL.Gaming.Unity.Gaming.GameSystem
{
    public class GameInitManager : MonoBehaviour
    {
        #region 显影控制
        Image image_curtain;
        public float changingSpeed; // 控制变化速率
        float minAlpha; // 最小透明度
        float maxAlpha; // 最大透明度
        float currentAlpha;
        float direction; // 控制透明度变化方向
        bool isFading;
        int lootTimes;
        #endregion

        GameObject Toggle_Race;
        GameObject Toggle_Profession;
        GameObject Toggle_Attributes;
        GameObject Toggle_MapSettings;
        GameObject Panel_SubCategory_Race;
        GameObject Panel_SubCategory_Profession;
        GameObject Panel_SubCategory_Attributes;
        GameObject Panel_SubCategory_MapSettings;
        GameObject Image_Curtain;
        GameObject Button_Back;
        GameObject Button_Continue;
        GameObject Button_Confirm;
        GameObject InputField_Name;

        void Start()
        {
            Toggle_Race = ResourceHelper.FindGameObjectByName("Toggle_Race");
            Toggle_Profession = ResourceHelper.FindGameObjectByName("Toggle_Profession");
            Toggle_Attributes = ResourceHelper.FindGameObjectByName("Toggle_Attributes");
            Toggle_MapSettings = ResourceHelper.FindGameObjectByName("Toggle_MapSettings");
            Panel_SubCategory_Race = ResourceHelper.FindGameObjectByName("Panel_SubCategory_Race");
            Panel_SubCategory_Profession = ResourceHelper.FindGameObjectByName("Panel_SubCategory_Profession");
            Panel_SubCategory_Attributes = ResourceHelper.FindGameObjectByName("Panel_SubCategory_Attributes");
            Panel_SubCategory_MapSettings = ResourceHelper.FindGameObjectByName("Panel_SubCategory_MapSettings");
            Toggle_Race.GetComponent<Toggle>().onValueChanged.AddListener(c =>
            {
                if (c)
                {
                    Panel_SubCategory_Race.SetActive(true);
                    Panel_SubCategory_Profession.SetActive(false);
                    Panel_SubCategory_Attributes.SetActive(false);
                    Panel_SubCategory_MapSettings.SetActive(false);
                };
            });
            Toggle_Profession.GetComponent<Toggle>().onValueChanged.AddListener(c =>
            {
                if (c)
                {
                    Panel_SubCategory_Race.SetActive(false);
                    Panel_SubCategory_Profession.SetActive(true);
                    Panel_SubCategory_Attributes.SetActive(false);
                    Panel_SubCategory_MapSettings.SetActive(false);
                };
            });
            Toggle_Attributes.GetComponent<Toggle>().onValueChanged.AddListener(c =>
            {
                if (c)
                {
                    Panel_SubCategory_Race.SetActive(false);
                    Panel_SubCategory_Profession.SetActive(false);
                    Panel_SubCategory_Attributes.SetActive(true);
                    Panel_SubCategory_MapSettings.SetActive(false);
                };
            });
            Toggle_MapSettings.GetComponent<Toggle>().onValueChanged.AddListener(c =>
            {
                if (c)
                {
                    Panel_SubCategory_Race.SetActive(false);
                    Panel_SubCategory_Profession.SetActive(false);
                    Panel_SubCategory_Attributes.SetActive(false);
                    Panel_SubCategory_MapSettings.SetActive(true);
                };
            });
            Toggle_Race.GetComponent<Toggle>().isOn = true;
            //Image_Curtain
            Image_Curtain = ResourceHelper.FindGameObjectByName("Image_Curtain");
            Image_Curtain?.SetActive(false);
            //Button_Continue
            Button_Continue = ResourceHelper.FindGameObjectByName("Button_Continue");
            Button_Continue.GetComponent<Button>().onClick.AddListener(() => { Continue(); });
            //Button_Confirm
            Button_Confirm = ResourceHelper.FindGameObjectByName("Button_Confirm");
            Button_Confirm.GetComponent<Button>().onClick.AddListener(() => { Confirm(); });
            Button_Confirm.GetComponent<Button>().interactable = false;
            //Button_Back
            Button_Back = ResourceHelper.FindGameObjectByName("Button_Back");
            Button_Back.GetComponent<Button>().onClick.AddListener(() => { Return(); });
            //InputField_Name
            InputField_Name = ResourceHelper.FindGameObjectByName("InputField_Name");
            InputField_Name.GetComponent<InputField>().onValueChanged.AddListener((s) =>
            {
                if (string.IsNullOrEmpty(s))
                    Button_Confirm.GetComponent<Button>().interactable = false;
                else
                    Button_Confirm.GetComponent<Button>().interactable = true;
            });
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
                    SceneManager.LoadSceneAsync("Scene_Gaming");
                }
            }
            else if (currentAlpha < minAlpha)
            {
                currentAlpha = minAlpha;
                direction = 1.0f;
            }
            image_curtain.color = new Color(image_curtain.color.r, image_curtain.color.g, image_curtain.color.b, currentAlpha);
        }

        void Continue()
        {
            Toggle race = Toggle_Race.GetComponent<Toggle>();
            Toggle profession = Toggle_Profession.GetComponent<Toggle>();
            Toggle attributes = Toggle_Attributes.GetComponent<Toggle>();
            Toggle mapSettings = Toggle_MapSettings.GetComponent<Toggle>();
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
                GameObject panel_Ready = ResourceHelper.FindGameObjectByName("Panel_Ready");
                panel_Ready.SetActive(true);
                return;
            }
        }

        public void Return()
        {
            GameObject panel_Ready = GameObject.Find("Panel_Ready");
            panel_Ready.SetActive(false);
            GameObject panel_Settings = ResourceHelper.FindGameObjectByName("Panel_Settings");
            panel_Settings.SetActive(true);
        }

        public void Confirm()
        {
            var go_curtain = ResourceHelper.FindGameObjectByName("Image_Curtain");
            go_curtain.SetActive(true);
            image_curtain = go_curtain.GetComponent<Image>();
            changingSpeed = 1.0f; // 控制变化速率
            minAlpha = 0.0f; // 最小透明度
            maxAlpha = 1.0f; // 最大透明度
            currentAlpha = 0.0f;
            direction = 1.0f; // 控制透明度变化方向
            lootTimes = 2;
            isFading = true;
        }
    }
}
