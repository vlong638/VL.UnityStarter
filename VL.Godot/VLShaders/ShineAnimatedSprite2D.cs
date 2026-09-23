using System;
using Godot;

namespace VL.Godot.VLShaders
{
    /// <summary>
    /// 给任意 AnimatedSprite2D 添加 Shine 扫光效果
    /// 用法：
    ///   1) 作为子节点挂到 AnimatedSprite2D 下（Target 留空自动找父节点）
    ///   2) 或代码 new ShineShader2D { Target = animSprite }
    /// </summary>
    [GlobalClass]
    public partial class ShineAnimatedSprite2D : Node2D
    {
        // ========== 目标 ==========
        [Export] public AnimatedSprite2D Target { get; set; }

        // ========== 原 Shader 的 4 个 uniform ==========
        [Export] public Color ShineColor { get; set; } = Colors.White;

        [Export(PropertyHint.Range, "0.5,5.0")]
        public float CycleInterval { get; set; } = 1.0f;

        [Export(PropertyHint.Range, "1.0,5.0")]
        public float ShineSpeed { get; set; } = 3.0f;

        [Export(PropertyHint.Range, "1.0,100.0")]
        public float ShineWidth { get; set; } = 3.0f;

        // ========== 2D 扩展 ==========
        [Export] public bool Enabled { get; set; } = true;

        [Export(PropertyHint.Range, "0,1")]
        public int ShineAxis { get; set; } = 0; // 0=水平 1=垂直

        // ========== 内部 ==========
        private ShaderMaterial _mat;
        private const string ShaderPath =
            "res://Assets/0915SideScrolling/Nodes/EnermyWithShine.gdshader";

        // 参数缓存，检测变化才写 uniform
        private Color _lastColor;
        private float _lastCycle, _lastSpeed, _lastWidth;
        private int _lastAxis;
        private bool _lastEnabled;
        private bool _firstApplied = false;

        // ========== 生命周期 ==========
        public override void _Ready()
        {
            // 自动找父节点
            if (Target == null)
                Target = GetParent() as AnimatedSprite2D;

            if (Target == null)
            {
                GD.PushError("ShineShader2D: 找不到 AnimatedSprite2D，请设置 Target 或把本节点作为其子节点");
                return;
            }

            AttachTo(Target);
        }

        public override void _Process(double delta)
        {
            //GD.Print($"_Process Enabled={Enabled}, _lastEnabled={_lastEnabled}, _firstApplied={_firstApplied}");
            // 参数有变化时自动刷新（不必手动调 Apply）
            if (!_firstApplied
                || ShineColor != _lastColor
                || CycleInterval != _lastCycle
                || ShineSpeed != _lastSpeed
                || ShineWidth != _lastWidth
                || ShineAxis != _lastAxis
                || Enabled != _lastEnabled)
            {
                Apply();
            }
        }

        // ========== 核心：挂材质 ==========
        /// <summary>
        /// 把 ShaderMaterial 挂到 AnimatedSprite2D 上
        /// </summary>
        public void AttachTo(AnimatedSprite2D sprite)
        {
            Target = sprite;

            var shader = GD.Load<Shader>(ShaderPath);
            if (shader == null)
            {
                GD.PushError($"Shader 未找到: {ShaderPath}");
                return;
            }

            // AnimatedSprite2D 和 Sprite2D 一样用 Material 属性
            _mat = new ShaderMaterial { Shader = shader };
            sprite.Material = _mat;

            Apply();
        }

        // ========== 写入 uniform ==========
        public void Apply()
        {
            if (_mat == null) return;
            GD.Print($"ShineAnimatedSprite2D.Apply Enabled={Enabled}");

            _mat.SetShaderParameter("shine_color", ShineColor);
            _mat.SetShaderParameter("cycle_interval", CycleInterval);
            _mat.SetShaderParameter("shine_speed", ShineSpeed);
            _mat.SetShaderParameter("shine_width", ShineWidth);
            _mat.SetShaderParameter("shine_axis", ShineAxis);
            _mat.SetShaderParameter("shine_enabled", Enabled);

            // 缓存
            _lastColor = ShineColor;
            _lastCycle = CycleInterval;
            _lastSpeed = ShineSpeed;
            _lastWidth = ShineWidth;
            _lastAxis = ShineAxis;
            _lastEnabled = Enabled;
            _firstApplied = true;
        }

        // ========== 便捷 API ==========
        public void SetEnabled(bool v) => Enabled = v;          // _Process 会自动 Apply
        public void SetColor(Color c) => ShineColor = c;
        public void SetSpeed(float s) => ShineSpeed = s;
        public void SetAxis(int a) => ShineAxis = a;

        private ulong _playToken = 0;

        public async void PlayOnce(float duration = 1.0f)
        {
            _playToken++;
            ulong myToken = _playToken;

            SetEnabled(true);
            Apply();

            await ToSignal(GetTree().CreateTimer(duration), SceneTreeTimer.SignalName.Timeout);

            // 只有最后一次触发的协程才关闭
            if (myToken == _playToken)
            {
                SetEnabled(false);
            }
        }

        /// <summary>切换扫描方向</summary>
        public void ToggleAxis() => ShineAxis = ShineAxis == 0 ? 1 : 0;

        /// <summary>移除效果（还原材质）</summary>
        public void Detach()
        {
            _playToken++;
            Enabled = false;

            if (Target != null)
            {
                Target.Material = null;
                // ❌ 删掉这行：Target.MaterialOverride = null;
            }

            _mat = null;
            _firstApplied = false;

            GD.Print($"Shine.Detach 完成, Target.Material={Target?.Material}");
        }
    }
}
