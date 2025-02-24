using TMPro;
using UnityEngine;

namespace VL.Gaming.Scripts.Common.Entities
{
    internal class UnitDataController : MonoBehaviour
    {
        public UnitData Data;
        public GameObject HPTextGO;

        void Start()
        {
            if (Data != null)
            {
                Data.OnHPChanged += UpdateHpText;
                Data.HP = Data.HP;
            }
        }

        private float timer = 0f;
        void Update()
        {
            float deltaTime = Time.deltaTime;
            timer += deltaTime;
            if (timer >= 1f)
            {
                Data.HP++;
                timer = 0f;
                Debug.Log("当前Data.HP的值为: " + Data.HP);
            }
        }

        private void UpdateHpText()
        {
            if (HPTextGO != null)
            {
                HPTextGO.GetComponent<TextMeshProUGUI>().text = Data.HP.ToString();
            }
        }

        void OnDestroy()
        {
            if (Data != null)
            {
                Data.OnHPChanged -= UpdateHpText;
            }
        }
    }
}
