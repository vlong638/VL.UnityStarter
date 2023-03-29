using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class SliceSpritesEditor : EditorWindow
{
    [MenuItem("Tools/SliceSprites")]
    static void SliceSprites()
    {
        string folderPath = AssetDatabase.GetAssetPath(Selection.activeObject);
        if (!AssetDatabase.IsValidFolder(folderPath))
        {
            EditorUtility.DisplayDialog("Error", "Please select a valid folder.", "OK");
            return;
        }
        // �ݹ�����ļ����е������ļ�
        var files = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories)
            .Where(file => file.ToLower().EndsWith(".png") || file.ToLower().EndsWith(".jpg") || file.ToLower().EndsWith(".jpeg") || file.ToLower().EndsWith(".bmp"))
            .ToList();
        if (files.Count == 0)
        {
            EditorUtility.DisplayDialog("Error", "No image files found in the selected folder.", "OK");
            return;
        }
        var count = 0;
        foreach (var file in files)
        {
            // ��ȡѡ��������
            var texture = AssetDatabase.LoadAssetAtPath<Texture2D>(file);
            if (texture == null)
                continue;

            // ��Sprite Mode����ΪMultiple
            TextureImporter importer = AssetImporter.GetAtPath(AssetDatabase.GetAssetPath(texture)) as TextureImporter;
            if (importer != null)
            {
                importer.textureType = TextureImporterType.Sprite;
                importer.spriteImportMode = SpriteImportMode.Multiple;
                importer.spritePixelsPerUnit = 100;
            }

            // ���þ����и���Ϣ
            var textureWidth = texture.width;
            var textureHeight = texture.height;
            var spriteWidth = 16;
            var spriteHeight = 16;
            var padding = 0;
            var spacing = 0;
            importer.spriteBorder = new Vector4(0, 0, 0, 0);
            importer.spritePivot = new Vector2(0.5f, 0.5f);

            // ���и���Ϣ���õ�SpriteUtility����
            List<SpriteMetaData> metaDataList = new List<SpriteMetaData>();
            for (var y = padding; y <= textureHeight - spriteHeight - padding; y += spriteHeight + spacing)
            {
                for (var x = padding; x <= textureWidth - spriteWidth - padding; x += spriteWidth + spacing)
                {
                    SpriteMetaData metaData = new SpriteMetaData();
                    metaData.rect = new Rect(x, y, spriteWidth, spriteHeight);
                    metaData.name = $"{texture.name}_{metaDataList.Count}";
                    metaDataList.Add(metaData);
                }
            }
            importer.spritesheet = metaDataList.ToArray();
            AssetDatabase.ImportAsset(importer.assetPath, ImportAssetOptions.ForceUpdate);
            count++;
        }
        // �����Ƭ
        EditorUtility.DisplayDialog("Success", $"Sprites sliced successfully.{count} files in total.", "OK");
    }
}