using UnityEngine;
using UnityEditor;
namespace Assets.Scenes.VLGamingStudy0328
{
    [CustomEditor(typeof(LookAtPoint))]
    [CanEditMultipleObjects]
    public class LookAtPointEditor : Editor
    {
        SerializedProperty lookAtPoint;

        void OnEnable()
        {
            lookAtPoint = serializedObject.FindProperty("lookAtPoint");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(lookAtPoint);
            if (lookAtPoint.vector3Value.y > (target as LookAtPoint).transform.position.y)
            {
                EditorGUILayout.LabelField("(Above this object)");
            }
            if (lookAtPoint.vector3Value.y < (target as LookAtPoint).transform.position.y)
            {
                EditorGUILayout.LabelField("(Below this object)");
            }


            serializedObject.ApplyModifiedProperties();
        }

        public void OnSceneGUI()
        {
            var t = (target as LookAtPoint);

            EditorGUI.BeginChangeCheck();
            Vector3 pos = Handles.PositionHandle(t.lookAtPoint, Quaternion.identity);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(target, "Move point");
                t.lookAtPoint = pos;
                t.Update();
            }
        }
    }
}