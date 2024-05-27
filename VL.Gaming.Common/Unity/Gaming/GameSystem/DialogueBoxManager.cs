using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using VL.Gaming.Common;
using VL.Gaming.Unity.Gaming.Ultis;
using VL.Gaming.Unity.Tools;

namespace VL.Gaming.Unity.Gaming.GameSystem
{

    public class DialogueBoxManager : MonoBehaviour
    {
        private static DialogueBoxManager instance;
        public static DialogueBoxManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameObject("DialogueBoxManager").AddComponent<DialogueBoxManager>();
                }
                return instance;
            }
        }

        private static GameObject instance_Button;
        public static GameObject Instance_ChoiceButton
        {
            get
            {
                if (instance_Button == null)
                {
                    instance_Button = Resources.Load<GameObject>("Prefabs/Prefab_Buttton_Gaming_DialogBox_Choice");
                    ;
                }
                return instance_Button;
            }
        }

        public GameObject dialogueBox;
        public Image imageBackground;
        public Image imageLeftPortrait;
        public Image imageRightPortrait;
        public Text textTitle;
        public Text textContent;
        public GameObject panelChoiceButtons;

        string lastLeftSource;
        string lastRightSource;

        void Awake()
        {
        }

        void Start()
        {
        }

        //生效间隔
        float displayStartTime = 0f;
        float clickInterval = 1f;
        bool isUpdatingUI = false;
        bool isChoosing = false;
        Dialogue currentDialogue; 
        Dialogue lastDialogue;
        void Update()
        {
            if (!isUpdatingUI && !isChoosing && (Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetMouseButtonDown(0)))
            {
                if (Time.time - displayStartTime > clickInterval)
                {
                    DisplayDialogue();
                }
            }
        }

        public void StartDialogue(long id)
        {
            currentDialogue = DialogueDataManager.Instance.GetDialogueById(1);
            dialogueBox = ResourceHelper.FindGameObjectByName("Prefab_Canvas_Gaming_DialogBox");
            imageBackground = ResourceHelper.FindGameObjectByName("Image_Background").GetComponent<Image>();
            imageLeftPortrait = ResourceHelper.FindGameObjectByName("Image_LeftPortrait").GetComponent<Image>();
            imageRightPortrait = ResourceHelper.FindGameObjectByName("Image_RightPortrait").GetComponent<Image>();
            textTitle = ResourceHelper.FindGameObjectByName("Text_Title").GetComponent<Text>();
            textContent = ResourceHelper.FindGameObjectByName("Text_Content").GetComponent<Text>();
            panelChoiceButtons = ResourceHelper.FindGameObjectByName("Panel_ChoiceButtons");
            if (currentDialogue != null)
                dialogueBox.gameObject.SetActive(true);
            displayStartTime = Time.time;
            DisplayDialogue();
        }

        void DisplayDialogue()
        {
            if (currentDialogue == null)
            {
                dialogueBox.gameObject.SetActive(false);
                return;
            }

            displayStartTime = Time.time;
            switch (currentDialogue.ContentType)
            {
                case DialogueContentType.None:
                    break;
                case DialogueContentType.Dialogue:
                    textTitle.text = currentDialogue.Title;
                    textContent.text = "";
                    Texture2D texture;
                    Sprite sprite;
                    switch (currentDialogue.PortraitLocation)
                    {
                        case DialoguePortraitLocation.Left:
                            if (lastLeftSource == currentDialogue.PortraitSource)
                                break;
                            texture = Resources.Load<Texture2D>(currentDialogue.PortraitSource);
                            sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                            imageLeftPortrait.sprite = sprite;
                            imageLeftPortrait.SetNativeSize();
                            break;
                        case DialoguePortraitLocation.Right:
                            if (lastRightSource == currentDialogue.PortraitSource)
                                break;
                            texture = Resources.Load<Texture2D>(currentDialogue.PortraitSource);
                            sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                            imageRightPortrait.sprite = sprite;
                            imageRightPortrait.SetNativeSize();
                            break;
                        default:
                            break;
                    }
                    fullText = currentDialogue.Content;
                    isUpdatingUI = true; ;
                    isUpdatingUIText = true;
                    isUpdatingUIImage = true;
                    StartCoroutine(UpdatingText());
                    StartCoroutine(UpdatingImage());
                    break;
                case DialogueContentType.Option:
                    var buttonDatas = lastDialogue.Children;
                    int index = 0;
                    foreach (var buttonData in buttonDatas)
                    {
                        GameObject instantiatedPrefab = Instantiate(Instance_ChoiceButton, Vector3.zero, Quaternion.identity);
                        instantiatedPrefab.SetParent(panelChoiceButtons);
                        instantiatedPrefab.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 100 + index * -100);
                        var button = instantiatedPrefab.GetComponent<Button>();
                        button.onClick.AddListener(() => OnChoosing(buttonData.Id));
                        var text = button.GetComponentInChildren<Text>().text = buttonData.Content;
                        index++;
                    }
                    panelChoiceButtons.SetActive(true);
                    isChoosing = true;
                    break;
                default:
                    break;
            }
        }

        void OnChoosing(long parameter)
        {
            VLDebug.DelegateDebug(() => { Debug.Log($"OnChoosing:{parameter}"); });
            //更新历史记录
            currentDialogue = lastDialogue.Children.First(c => c.Id == parameter).Children.FirstOrDefault();
            lastDialogue = currentDialogue == null ? null : lastDialogue.Children.First(c => c.Id == currentDialogue.ParentId);
            //清理UI
            foreach (Transform button in panelChoiceButtons.transform)
            {
                Destroy(button.gameObject);
            }
            panelChoiceButtons.SetActive(false);
            //下一步
            isChoosing = false;
            DisplayDialogue();
        }

        bool IsSameSpeaker()
        {
            bool isSame = currentDialogue != null && lastDialogue != null && currentDialogue.PortraitLocation == lastDialogue.PortraitLocation && currentDialogue.PortraitSource == lastDialogue.PortraitSource;
            return isSame;
        }

        bool isUpdatingUIText;
        bool isUpdatingUIImage;

        //吐字型展示
        public float updatingTextDelay = 0.1f;
        string fullText;
        IEnumerator UpdatingText()
        {
            for (int i = 0; i < fullText.Length; i++)
            {
                var currentText = fullText.Substring(i, 1);
                textContent.text += currentText;
                yield return new WaitForSeconds(updatingTextDelay);
            }
            isUpdatingUIText = false;
            FinishUpdating();
        }

        public Vector3 moveDirection = new Vector3(100, 0, 0);
        public float moveTime = 1.0f;
        public float fadeTime = 1.0f;
        public float fadeTransparent = 0.5f;
        public float scaleFactorScaleUp = 1.25f; // 初始缩放比例
        public float scaleFactorScaleDown = 0.8f; // 初始缩放比例
        IEnumerator UpdatingImage()
        {
            Image imageToShow = null;
            Image imageToFade = null;
            switch (currentDialogue.PortraitLocation)
            {
                case DialoguePortraitLocation.Left:
                    imageToShow = imageLeftPortrait;
                    imageToFade = imageRightPortrait;
                    break;
                case DialoguePortraitLocation.Right:
                    imageToShow = imageRightPortrait;
                    imageToFade = imageLeftPortrait;
                    break;
                default:
                    break;
            }
            bool isSame = IsSameSpeaker();
            float elapsedTime = 0.0f;
            Color startFadeColor = imageToFade.color;
            Color endFadeColor = isSame ? startFadeColor : new Color(startFadeColor.r, startFadeColor.g, startFadeColor.b, fadeTransparent);
            Color startShowColor = imageToShow.color;
            Color endShowColor = isSame ? startShowColor : new Color(startShowColor.r, startShowColor.g, startShowColor.b, 1);
            Vector3 startShowScale = imageToShow.transform.localScale;
            Vector3 endShowScale = isSame ? startShowScale : imageToShow.transform.localScale * scaleFactorScaleUp;
            Vector3 startFadeScale = imageToFade.transform.localScale;
            Vector3 endFadeScale = isSame ? startFadeScale : imageToFade.transform.localScale * scaleFactorScaleDown;
            while (elapsedTime < moveTime)
            {
                imageToShow.color = Color.Lerp(startShowColor, endShowColor, elapsedTime / fadeTime);
                imageToShow.transform.localScale = Vector3.Lerp(startShowScale, endShowScale, elapsedTime / moveTime);
                imageToFade.color = Color.Lerp(startFadeColor, endFadeColor, elapsedTime / fadeTime);
                imageToFade.transform.localScale = Vector3.Lerp(startFadeScale, endFadeScale, elapsedTime / moveTime);

                elapsedTime += Time.deltaTime;
                yield return null;
            }
            isUpdatingUIImage = false;
            FinishUpdating();
        }

        void FinishUpdating()
        {
            isUpdatingUI = isUpdatingUIImage || isUpdatingUIText;
            if (!isUpdatingUI)
            {
                switch (currentDialogue.PortraitLocation)
                {
                    case DialoguePortraitLocation.Left:
                        lastLeftSource = currentDialogue.PortraitSource;
                        break;
                    case DialoguePortraitLocation.Right:
                        lastRightSource = currentDialogue.PortraitSource;
                        break;
                    default:
                        break;
                }
                lastDialogue = currentDialogue;
                currentDialogue = currentDialogue.Children.FirstOrDefault();
            }
        }
    }
}
