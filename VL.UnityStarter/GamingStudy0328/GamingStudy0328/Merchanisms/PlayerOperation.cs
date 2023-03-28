using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scenes.GamingStudy0328
{
    public class PlayerOperation
    {
        public bool IsMyTurn { get; internal set; }
        public bool IsOperated = false;

        private bool isAttackingSetup;
        private bool isMovingSetup;
        private bool isMoving;
        private bool isCollecttingSetup;

        public bool IsAttackingSetup
        {
            get => isAttackingSetup; set
            {
                if (value) IsOperated = true;
                isAttackingSetup = value;
            }
        }
        public bool IsMovingSetup
        {
            get => isMovingSetup;
            set
            {
                if (value) IsOperated = true;
                isMovingSetup = value;
            }
        }
        public bool IsMoving
        {
            get => isMoving;
            set
            {
                if (value) IsOperated = true;
                isMoving = value;
            }
        }
        public bool IsCollecttingSetup
        {
            get => isCollecttingSetup;
            set
            {
                if (value) IsOperated = true;
                isCollecttingSetup = value;
            }
        }

        public bool IsAttempMoving { get; internal set; }
        public bool IsAttempMovingBack { get; internal set; }
    }
}
