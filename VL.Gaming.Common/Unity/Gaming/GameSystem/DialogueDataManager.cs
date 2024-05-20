using System.Collections.Generic;
using UnityEngine;

namespace VL.Gaming.Unity.Gaming.GameSystem
{
    public class DialogueDataManager : MonoBehaviour
    {
        private static DialogueDataManager instance;
        public static DialogueDataManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameObject("DialogueDataManager").AddComponent<DialogueDataManager>();
                }
                return instance;
            }
        }

        static Dialogue Dialogues = new Dialogue(0, -1);

        static DialogueDataManager()
        {
            string json = Resources.Load<TextAsset>("Dialogues/DialogueTest").text;
            var dialogues = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Dialogue>>(json);
            foreach (var dialogue in dialogues)
            {
                Dialogues.Insert(dialogue);
            }
        }

        public Dialogue GetDialogueById(long id)
        {
            return Dialogues.GetNodeById(id);
        }
    }
}
