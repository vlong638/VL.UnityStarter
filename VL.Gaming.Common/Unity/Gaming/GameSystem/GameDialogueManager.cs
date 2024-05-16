using System.Collections.Generic;
using UnityEngine;

namespace VL.Gaming.Unity.Gaming.GameSystem
{
    public class GameDialogueManager : MonoBehaviour
    {
        private static GameDialogueManager instance;
        public static GameDialogueManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameObject("DialogueManager").AddComponent<GameDialogueManager>();
                }
                return instance;
            }
        }

        static Dialogue Dialogues = new Dialogue(0, -1);

        static GameDialogueManager()
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
