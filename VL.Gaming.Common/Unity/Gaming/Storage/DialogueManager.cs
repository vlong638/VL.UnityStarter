using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace VL.Gaming.Unity.Gaming.Storage
{
    public class DialogueManager : MonoBehaviour
    {
        [SerializeField]
        public Text textTitle;
        [SerializeField]
        public Text textContent;
        [SerializeField]
        public string dialogueSource; // 外部指定的Json文件路径
        private List<Dialogue> dialogues; // 存储对话数据的列表
        private int currentDialogueIndex = 0;
        [SerializeField]
        public GameObject DialogueBox;

        void Awake()
        {
            dialogueSource = "D:\\test.json";
            //造数据
            //List<Dialogue> testData = new List<Dialogue>();
            //testData.Add(new Dialogue("猎人", "终于找到你了"));
            //testData.Add(new Dialogue("大灰狼", "我只是个普普通通的老婆婆"));
            //testData.Add(new Dialogue("猎人", "别装了,你这只愚蠢的大灰狼"));
            //testData.Add(new Dialogue("大灰狼", "什么?什么大灰狼"));
            //testData.Add(new Dialogue("猎人", "你的狼尾巴都露出来了"));
            //testData.Add(new Dialogue("猎人", "受死吧!可恶的大灰狼"));
            //File.WriteAllText(dialogueSource, Newtonsoft.Json.JsonConvert.SerializeObject(testData));
        }

        void OnEnable()
        {
            Debug.LogWarning("DialogueManager OnEnable");
            LoadDialogueData();
            UpdateUI();
        }

        void Start()
        {
        }

        //生效间隔
        private float lastClickTime = 0f;
        private float clickInterval = 0.5f;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetMouseButtonDown(0))
            {
                if (Time.time - lastClickTime > clickInterval)
                {
                    currentDialogueIndex++;
                    if (currentDialogueIndex >= dialogues.Count)
                    {
                        currentDialogueIndex = 0;
                    }
                    UpdateUI();

                    lastClickTime = Time.time;
                }
            }
        }

        void LoadDialogueData()
        {
            // 从外部Json文件加载对话数据
            string json = File.ReadAllText(dialogueSource);
            dialogues = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Dialogue>>(json);
        }

        void UpdateUI()
        {
            if (dialogues.Count == 0)
            {
                DialogueBox.transform.Find("Panel").gameObject.SetActive(false);
                //DialogueBox.GetComponent<Canvas>().enabled = false;
                return;
            }
            var dialogue = dialogues[0];
            textTitle.text = dialogue.title;
            textContent.text = dialogue.content;
            dialogues.RemoveAt(0);
        }
    }

    [System.Serializable]
    public class Dialogue
    {
        public string title;
        public string content;

        public Dialogue(string title, string content)
        {
            this.title = title;
            this.content = content;
        }
    }
}
