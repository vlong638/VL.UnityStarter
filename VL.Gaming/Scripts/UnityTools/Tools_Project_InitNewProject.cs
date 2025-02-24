using UnityEditor;
using VL.Gaming.Scripts.Tools;

namespace VL.Gaming.Scripts.UnityTools
{
    internal class Tools_Project_InitNewProject
    {
        [MenuItem("Tools/Project/InitNewProject")]
        public static void InitNewProject()
        {
            VLIOHelper.CreateDirectory("Resources");
            VLIOHelper.CreateDirectory("Resources/Animations");
            VLIOHelper.CreateDirectory("Resources/Dialogues");
            VLIOHelper.CreateDirectory("Resources/Prefabs");
            VLIOHelper.CreateDirectory("Resources/Sprites");
            VLIOHelper.CreateDirectory("Resources/fbx");
            VLIOHelper.CreateDirectory("Resources/fbx/AnimatorControllers");
            VLIOHelper.CreateDirectory("Resources/fbx/Models");
            VLIOHelper.CreateDirectory("Resources/fbx/Motions");
            VLIOHelper.CreateDirectory("Resources/fbx/Textures");
            VLIOHelper.CreateDirectory("Scripts");
        }
    }
}
