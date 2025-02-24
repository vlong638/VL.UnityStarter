using System;
using UnityEngine;

namespace VL.Gaming.Scripts.Common.Entities
{
    /// <summary>
    /// {set;get;}属性不支持Inspector中可见
    /// 如需要可见,需设置hp特性[SerializeField]
    /// </summary>
    [CreateAssetMenu(menuName = "DataMenu/UnitData")]
    public class UnitData : ScriptableObject
    {
        [SerializeField]
        private int hp;
        public int HP
        {
            get { return hp; }
            set
            {
                hp = value;
                OnHPChanged?.Invoke();
            }
        }
        public event Action OnHPChanged;

        public string Name;
    }
}
