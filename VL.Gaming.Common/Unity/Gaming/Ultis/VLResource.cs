using UnityEditor;
using UnityEngine;

namespace VL.Gaming.Unity.Gaming.Ultis
{
    public class VLResource
    {
        public static Sprite Sprite_Rectangle { get { return Resources.Load<Sprite>("Sprites/Rectangle"); } }
        public static Sprite Sprite_Circle { get { return Resources.Load<Sprite>("Sprites/Circle"); } }
        public static Sprite Sprite_Background { get { return AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/Background.psd"); } }
        public static Sprite Sprite_UIMask { get { return AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UIMask.psd"); } }
        public static Sprite Sprite_UISprite { get { return AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UISprite.psd"); } }
        public static Sprite Sprite_Player { get { return Resources.Load<Sprite>("Sprites/DialogueTest_小红帽"); } }
        public static Sprite Sprite_Enermy { get { return Resources.Load<Sprite>("Sprites/DialogueTest_大灰狼"); } }
        public static Sprite Sprite_VS { get { return Resources.Load<Sprite>("Sprites/DialogueBoxBackground"); } }
        public static Sprite Sprite_HourGlass { get { return Resources.Load<Sprite>("Sprites/hourglass"); } }
        public static Sprite Sprite_PlayerTurn { get { return Resources.Load<Sprite>("Sprites/DialogueTest_小红帽"); } }
        public static Sprite Sprite_EnermyTurn { get { return Resources.Load<Sprite>("Sprites/DialogueTest_大灰狼"); } }

        public static GameObject Prefab_Chess { get { return Resources.Load<GameObject>("Prefabs/Prefab_Chess"); ; } }
        public static GameObject Prefab_ChessPlaceHolder { get { return Resources.Load<GameObject>("Prefabs/Prefab_ChessPlaceHolder"); } }

        public static RuntimeAnimatorController Controller_Rotate { get { return Resources.Load<RuntimeAnimatorController>("Animations/Rotate"); } }

    }
}
