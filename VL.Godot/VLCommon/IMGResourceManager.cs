using Godot;
using System;
using System.Collections.Generic;

namespace VL.Godot.VLCommon;

/// <summary>
/// 图片资源管理器：批量预加载图片，支持随机获取。
/// </summary>
public partial class IMGResourceManager : Node
{
    // 路径 -> 纹理
    private Dictionary<string, Texture2D> _textures = new();

    // 已加载成功的路径列表，用于随机取用
    private List<string> _loadedPaths = new();

    // 随机数生成器
    private RandomNumberGenerator _rng = new();


    /// <summary>
    /// 批量预加载图片。重复路径会被跳过。
    /// </summary>
    /// <param name="paths">图片资源路径数组，如 "res://Assets/Images/red.png"</param>
    public void Load(params string[] paths)
    {
        if (paths == null || paths.Length == 0)
        {
            GD.PushWarning("IMGResourceManager.Load 收到空数组。");
            return;
        }

        foreach (var path in paths)
        {
            if (string.IsNullOrEmpty(path))
            {
                GD.PushWarning("IMGResourceManager.Load 跳过空路径。");
                continue;
            }

            if (_textures.ContainsKey(path))
                continue; // 已加载，跳过

            var tex = GD.Load<Texture2D>(path);
            if (tex == null)
            {
                GD.PushError($"IMGResourceManager 加载失败: {path}");
                continue;
            }

            _textures[path] = tex;
            _loadedPaths.Add(path);
        }
    }

    /// <summary>
    /// 随机获取一张已加载的图片。若尚未加载任何图片则返回 null。
    /// </summary>
    public Texture2D GetRandomOne()
    {
        if (_loadedPaths.Count == 0)
        {
            GD.PushWarning("IMGResourceManager.GetRandomOne：尚未加载任何图片。");
            return null;
        }

        int index = _rng.RandiRange(0, _loadedPaths.Count - 1);
        return _textures[_loadedPaths[index]];
    }
}