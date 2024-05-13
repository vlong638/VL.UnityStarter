using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VL.Gaming.Unity.Gaming.DisplayManage
{
    public class DialogueManager : MonoBehaviour
    {
        [SerializeField]
        public Text textTitle;
        [SerializeField]
        public Text textContent;
        [SerializeField]
        public GameObject dialogueBox;
        List<Dialogue> dialogues;
        int currentDialogueIndex = 0;

        float timer = 0f;
        public Image leftPortrait;
        string lastLeftSource;
        public Image rightPortrait;
        string lastRightSource;
        void Awake()
        {
            leftPortrait = GameObject.Find("Image_LeftPortrait").GetComponent<Image>();
            rightPortrait = GameObject.Find("Image_RightPortrait").GetComponent<Image>();
            textTitle = GameObject.Find("Text_Title").GetComponent<Text>();
            textContent = GameObject.Find("Text_Content").GetComponent<Text>();
            dialogueBox = GameObject.Find("Prefab_Canvas_Gaming_DialogBox");
        }

        void OnEnable()
        {
            Debug.LogWarning("DialogueManager OnEnable");
            LoadDialogueData();
            GoNext();
        }

        void Start()
        {
        }

        //生效间隔
        float lastClickTime = 0f;
        float clickInterval = 1f;
        bool isUpdatingUI = false;
        Dialogue currentDialogue;
        Dialogue lastDialogue;
        void Update()
        {
            if (!isUpdatingUI && (Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetMouseButtonDown(0)))
            {
                if (Time.time - lastClickTime > clickInterval)
                {
                    lastClickTime = Time.time;
                    GoNext();
                }
            }
        }
        private void GoNext()
        {
            Debug.Log("GoNext");
            if (dialogues.Count == 0)
            {
                dialogueBox.transform.Find("Panel").gameObject.SetActive(false);
                currentDialogueIndex = 0;
                return;
            }
            currentDialogue = dialogues[currentDialogueIndex];
            textTitle.text = currentDialogue.title;
            textContent.text = "";
            Texture2D texture;
            Sprite sprite;
            switch (currentDialogue.portraitLocation)
            {
                case PortraitLocation.Left:
                    if (lastLeftSource == currentDialogue.portraitSource)
                        break;
                    texture = Resources.Load<Texture2D>(currentDialogue.portraitSource);
                    sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                    leftPortrait.sprite = sprite;
                    leftPortrait.SetNativeSize();
                    break;
                case PortraitLocation.Right:
                    if (lastRightSource == currentDialogue.portraitSource)
                        break;
                    texture = Resources.Load<Texture2D>(currentDialogue.portraitSource);
                    sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                    rightPortrait.sprite = sprite;
                    rightPortrait.SetNativeSize();
                    break;
                default:
                    break;
            }
            dialogues.RemoveAt(0);
            fullText = currentDialogue.content;
            isUpdatingUI = true; ;
            isUpdatingUIText = true;
            isUpdatingUIImage = true;
            StartCoroutine(UpdatingText());
            StartCoroutine(UpdatingImage());
        }

        bool isUpdatingUIText;
        bool isUpdatingUIImage;

        private bool IsSameSpeaker()
        {
            bool isSame = currentDialogue != null && lastDialogue != null && currentDialogue.portraitLocation == lastDialogue.portraitLocation && currentDialogue.portraitSource == lastDialogue.portraitSource;
            return isSame;
        }

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

        private void FinishUpdating()
        {
            lastDialogue = currentDialogue;
            switch (currentDialogue.portraitLocation)
            {
                case PortraitLocation.Left:
                    lastLeftSource = currentDialogue.portraitSource;
                    break;
                case PortraitLocation.Right:
                    lastRightSource = currentDialogue.portraitSource;
                    break;
                default:
                    break;
            }
            isUpdatingUI = isUpdatingUIImage || isUpdatingUIText;
            Debug.Log($"isUpdatingUI:{isUpdatingUI}");
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
            switch (currentDialogue.portraitLocation)
            {
                case PortraitLocation.Left:
                    imageToShow = leftPortrait;
                    imageToFade = rightPortrait;
                    break;
                case PortraitLocation.Right:
                    imageToShow = rightPortrait;
                    imageToFade = leftPortrait;
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

        void LoadDialogueData()
        {
            string json = Resources.Load<TextAsset>("Dialogues/DialogueTest").text;
            dialogues = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Dialogue>>(json);
        }
    }

    public enum PortraitLocation
    {
        None,
        Left,
        Right,
    }

    [Serializable]
    public class Dialogue
    {
        public PortraitLocation portraitLocation;
        public string portraitSource;
        public string title;
        public string content;
    }
}
