using Godot;
using System;

namespace VL.Godot.VLShader;
public partial class SpriteParticleExplosion : Node2D
{
    public  static SpriteParticleExplosion StartExplosion(Vector2 offset, Texture2D sprite, Node parent)
    {
        var explosion = new SpriteParticleExplosion
        {
            // -------- 位置 --------
            Position = offset,

            // -------- 纹理 / 精灵表 --------
            Sprite = sprite,
            SpriteHframes = 1,
            SpriteVframes = 1,
            SpriteFrame = 0,

            // -------- 数量 & 随机 --------
            Amount = 200,
            RandomSeed = (uint)GD.Randi(),
            OneShot = true,

            // -------- 初速度 --------
            Spread = 180f,
            InitialLinearVelocityMin = 80f,
            InitialLinearVelocityMax = 220f,

            // -------- 径向 / 轨道速度 --------
            RadialVelocityMin = 0f,
            RadialVelocityMax = 60f,
            OrbitVelocityMin = -1.5f,
            OrbitVelocityMax = 1.5f,

            // -------- 加速度 --------
            LinearAccelMin = -200f,
            LinearAccelMax = -50f,      // 负值 → 减速
            RadialAccelMin = 0f,
            RadialAccelMax = 0f,
            TangentAccelMin = -120f,
            TangentAccelMax = 120f,

            // -------- 阻尼 --------
            DampingMin = 30f,
            DampingMax = 90f,

            // -------- 大小 --------
            ScaleMin = 0.5f,
            ScaleMax = 1.0f,

            // -------- 生命周期 --------
            BaseLifetime = 3.2f,
            LifetimeRandomness = 1.6f,
        };

        // 加到当前场景，并在生命周期结束后自动销毁
        parent.AddChild(explosion);
        explosion.Restart();
        return explosion;
    }

    // ============================ 导出参数 ============================

    [ExportGroup("Emission")]
    [Export] public int Amount { get; set; } = 100;
    [Export] public uint RandomSeed { get; set; } = 0;
    [Export] public bool Emitting { get; set; } = true;
    [Export] public bool OneShot { get; set; } = true;
    [Export] public Vector2 EmitterVelocity { get; set; } = Vector2.Zero;
    [Export] public float InheritEmitterVelocityRatio { get; set; } = 0f;

    [ExportGroup("Initial Velocity")]
    [Export] public float Spread { get; set; } = 180f;
    [Export] public float InitialLinearVelocityMin { get; set; } = 100f;
    [Export] public float InitialLinearVelocityMax { get; set; } = 100f;

    [ExportGroup("Dynamics")]
    [Export] public float OrbitVelocityMin { get; set; } = 0f;
    [Export] public float OrbitVelocityMax { get; set; } = 0f;
    [Export] public float RadialVelocityMin { get; set; } = 0f;
    [Export] public float RadialVelocityMax { get; set; } = 0f;

    [ExportGroup("Acceleration")]
    [Export] public float LinearAccelMin { get; set; } = 0f;
    [Export] public float LinearAccelMax { get; set; } = 0f;
    [Export] public float RadialAccelMin { get; set; } = 0f;
    [Export] public float RadialAccelMax { get; set; } = 0f;
    [Export] public float TangentAccelMin { get; set; } = 0f;
    [Export] public float TangentAccelMax { get; set; } = 0f;

    [ExportGroup("Damping & Scale")]
    [Export] public float DampingMin { get; set; } = 0f;
    [Export] public float DampingMax { get; set; } = 0f;
    [Export] public float ScaleMin { get; set; } = 1f;
    [Export] public float ScaleMax { get; set; } = 1f;

    [ExportGroup("Lifetime")]
    [Export] public float BaseLifetime { get; set; } = 1f;
    [Export] public float LifetimeRandomness { get; set; } = 0f;

    [ExportGroup("Emission Shape")]
    [Export] public Vector2 EmissionShapeOffset { get; set; } = Vector2.Zero;
    [Export] public Vector2 EmissionShapeScale { get; set; } = Vector2.One;
    [Export] public Vector2 EmissionBoxExtents { get; set; } = new Vector2(100, 100);

    [ExportGroup("Sprite")]
    [Export] public Texture2D Sprite { get; set; }
    [Export] public int SpriteFrame { get; set; } = 0;
    [Export] public int SpriteHframes { get; set; } = 1;
    [Export] public int SpriteVframes { get; set; } = 1;

    // ============================ 粒子结构 ============================

    private struct Particle
    {
        public bool Active;
        public Vector2 Position;
        public Vector2 Velocity;
        public Vector2 Scale;
        public Color Color;

        public float LifeElapsed;       // 对应 CUSTOM.y
        public float LifeMax;           // 对应 CUSTOM.w
        public float LifeRandomFactor;  // params.lifetime

        // 缓存生成时随机得到的动力学/物理参数
        public float InitialVelMul;
        public float RadialVel;
        public float OrbitVel;
        public float LinearAccel;
        public float RadialAccel;
        public float TangentAccel;
        public float Damping;

        public uint Seed;               // 继续驱动 process 阶段的随机
    }

    // ============================ 私有字段 ============================

    private Particle[] _particles;
    private bool _initialized;

    // ============================ 生命周期 ============================

    public override void _Ready()
    {
        if (Engine.IsEditorHint())
        {
            SetProcess(false);
            return;
        }
        Restart();
    }

    /// <summary>重新发射一次爆炸。</summary>
    public void Restart()
    {
        if (Sprite == null || Amount <= 0)
        {
            SetProcess(false);
            return;
        }

        _particles = new Particle[Amount];
        for (int i = 0; i < Amount; i++)
            _particles[i] = CreateParticle((uint)i);

        _initialized = true;
        SetProcess(true);
        QueueRedraw();
    }

    // ============================ 随机数（与 GLSL 保持一致） ============================

    private static float RandFromSeed(ref uint seed)
    {
        int s = unchecked((int)seed);
        if (s == 0) s = 305420679;

        int k = s / 127773;
        s = unchecked(16807 * (s - k * 127773) - 2836 * k);
        if (s < 0) s += 2147483647;

        seed = unchecked((uint)s);
        return (float)(seed % 65536u) / 65535.0f;
    }

    private static float RandFromSeedM1P1(ref uint seed)
        => RandFromSeed(ref seed) * 2.0f - 1.0f;

    private static uint Hash(uint x)
    {
        x = unchecked(((x >> 16) ^ x) * 73244475u);
        x = unchecked(((x >> 16) ^ x) * 73244475u);
        x = (x >> 16) ^ x;
        return x;
    }

    private static float Mix(float a, float b, float t) => a + (b - a) * t;

    // ============================ 生成辅助 ============================

    private Vector2 GetFrameSize()
    {
        if (Sprite == null) return Vector2.One * 16f;
        Vector2 texSize = Sprite.GetSize();
        return new Vector2(texSize.X / Mathf.Max(1, SpriteHframes),
                           texSize.Y / Mathf.Max(1, SpriteVframes));
    }

    private Vector2 CalculateInitialPosition(ref uint seed)
    {
        Vector2 frameSize = GetFrameSize();
        Vector2 rnd = new Vector2(RandFromSeed(ref seed), RandFromSeed(ref seed));
        // emission shape offset / scale / box extents（着色器里未被使用，这里保留接口）
        Vector2 local = (rnd - new Vector2(0.5f, 0.5f)) * frameSize;
        local = local * EmissionShapeScale + EmissionShapeOffset;
        return local;
    }

    private static Vector2 GetRandomDirectionFromSpread(ref uint seed, float spreadAngle)
    {
        const float deg2rad = Mathf.Pi / 180f;
        float spreadRad = spreadAngle * deg2rad;

        float angle1 = RandFromSeedM1P1(ref seed) * spreadRad;
        float angle2 = RandFromSeedM1P1(ref seed) * spreadRad;

        Vector3 dirXz = new Vector3(Mathf.Sin(angle1), 0f, Mathf.Cos(angle1));
        Vector3 dirYz = new Vector3(0f, Mathf.Sin(angle2), Mathf.Cos(angle2));
        dirYz.Z = dirYz.Z / Mathf.Max(0.0001f, Mathf.Sqrt(Mathf.Abs(dirYz.Z)));

        Vector3 spreadDir = new Vector3(dirXz.X * dirYz.Z, dirYz.Y, dirXz.Z * dirYz.Z);

        // 着色器里 direction_nrm 恒为 (0,0,1)
        Vector3 dirNrm = new Vector3(0f, 0f, 1f);
        Vector3 binormal = new Vector3(0f, 1f, 0f).Cross(dirNrm);
        if (binormal.Length() < 0.0001f)
            binormal = new Vector3(0f, 0f, 1f);
        binormal = binormal.Normalized();
        Vector3 normal = binormal.Cross(dirNrm);

        Vector3 result = binormal * spreadDir.X + normal * spreadDir.Y + dirNrm * spreadDir.Z;
        return new Vector2(result.X, result.Y);
    }

    /// <summary>按精灵表采样给定局部位置的颜色。</summary>
    private Color SampleSpriteColor(Vector2 localPos)
    {
        if (Sprite == null) return Colors.White;
        Vector2 frameSize = GetFrameSize();
        if (frameSize.X <= 0 || frameSize.Y <= 0) return Colors.White;

        Vector2 frameUv = localPos / frameSize + new Vector2(0.5f, 0.5f);
        int frameX = SpriteFrame % Mathf.Max(1, SpriteHframes);
        int frameY = SpriteFrame / Mathf.Max(1, SpriteHframes);
        Vector2 sheetUv = (new Vector2(frameX, frameY) + frameUv) /
                          new Vector2(SpriteHframes, SpriteVframes);

        Image img = Sprite.GetImage();
        if (img == null) return Colors.White;
        int px = Mathf.Clamp((int)(sheetUv.X * img.GetWidth()), 0, img.GetWidth() - 1);
        int py = Mathf.Clamp((int)(sheetUv.Y * img.GetHeight()), 0, img.GetHeight() - 1);
        return img.GetPixel(px, py);
    }

    // ============================ 粒子创建 ============================

    private Particle CreateParticle(uint number)
    {
        // 与着色器 start() 的哈希 & 调用顺序一致
        uint seed = Hash(number + 1u + RandomSeed);

        // --- Display ---
        float s0 = RandFromSeed(ref seed);
        Vector2 scale = Vector2.One * Mix(ScaleMin, ScaleMax, s0);
        scale = new Vector2(
            Mathf.Sign(scale.X) * Mathf.Max(Mathf.Abs(scale.X), 0.001f),
            Mathf.Sign(scale.Y) * Mathf.Max(Mathf.Abs(scale.Y), 0.001f));
        float lifetime = 1.0f - LifetimeRandomness * RandFromSeed(ref seed);

        // --- Dynamics ---
        float initVelMul = Mix(InitialLinearVelocityMin, InitialLinearVelocityMax, RandFromSeed(ref seed));
        float radialVel = Mix(RadialVelocityMin, RadialVelocityMax, RandFromSeed(ref seed));
        float orbitVel = Mix(OrbitVelocityMin, OrbitVelocityMax, RandFromSeed(ref seed));

        // --- Physical ---
        float linearAccel = Mix(LinearAccelMin, LinearAccelMax, RandFromSeed(ref seed));
        float radialAccel = Mix(RadialAccelMin, RadialAccelMax, RandFromSeed(ref seed));
        float tangentAccel = Mix(TangentAccelMin, TangentAccelMax, RandFromSeed(ref seed));
        float damping = Mix(DampingMin, DampingMax, RandFromSeed(ref seed));

        // --- Position (local) ---
        Vector2 localPos = CalculateInitialPosition(ref seed);

        // --- Velocity (local) ---
        Vector2 localVel = GetRandomDirectionFromSpread(ref seed, Spread) * initVelMul;

        var p = new Particle
        {
            Active = true,
            Position = localPos,
            Velocity = localVel
                       + EmitterVelocity * InheritEmitterVelocityRatio,
            Scale = scale,
            LifeElapsed = 0f,
            LifeRandomFactor = lifetime,
            LifeMax = lifetime,
            InitialVelMul = initVelMul,
            RadialVel = radialVel,
            OrbitVel = orbitVel,
            LinearAccel = linearAccel,
            RadialAccel = radialAccel,
            TangentAccel = tangentAccel,
            Damping = damping,
            Seed = seed,
        };

        // 从精灵像素取色；透明度为 0 直接禁用
        p.Color = SampleSpriteColor(localPos);
        if (p.Color.A <= 0f) p.Active = false;

        return p;
    }

    // ============================ 每帧更新 ============================

    public override void _Process(double delta)
    {
        if (!_initialized || _particles == null) return;

        float dt = (float)delta;
        if (dt <= 0f) return;

        bool anyActive = false;

        for (int i = 0; i < _particles.Length; i++)
        {
            ref Particle p = ref _particles[i];
            if (!p.Active) continue;

            // ---- 生命进度 ----
            p.LifeElapsed += dt / BaseLifetime;
            if (p.LifeElapsed > p.LifeMax)
            {
                p.Active = false;
                continue;
            }
            float lifetimePercent = p.LifeElapsed / Mathf.Max(0.0001f, p.LifeRandomFactor);

            // ---- 受控位移（轨道 + 径向） ----
            Vector2 controlledDisplacement = Vector2.Zero;
            controlledDisplacement += ProcessOrbitDisplacement(ref p, dt);
            controlledDisplacement += ProcessRadialDisplacement(ref p, dt);

            // ---- 物理力 ----
            Vector2 diff = p.Position;

            Vector2 force = Vector2.Zero;

            if (p.Velocity.Length() > 0f)
                force += p.Velocity.Normalized() * p.LinearAccel;

            if (diff.Length() > 0f)
                force += diff.Normalized() * p.RadialAccel;

            // 切向：diff.yx * (-1, 1) => (-diff.y, diff.x)
            Vector2 tangentDir = new Vector2(-diff.Y, diff.X);
            if (tangentDir.Length() > 0f)
                force += tangentDir.Normalized() * p.TangentAccel;

            p.Velocity += force * dt;

            // ---- 阻尼 ----
            if (p.Damping > 0f)
            {
                float v = p.Velocity.Length();
                v -= p.Damping * dt;
                if (v < 0f)
                    p.Velocity = Vector2.Zero;
                else
                    p.Velocity = p.Velocity.Normalized() * v;
            }

            // ---- 位移 ----
            Vector2 finalVelocity = controlledDisplacement + p.Velocity;
            p.Position += finalVelocity * dt;

            // ---- 淡出 ----
            if (p.Color.A > 0f)
            {
                float a = p.Color.A - dt / BaseLifetime;
                p.Color = new Color(p.Color.R, p.Color.G, p.Color.B, Mathf.Max(0f, a));
            }

            anyActive = true;
        }

        QueueRedraw();

        if (!anyActive && (!Emitting || OneShot))
            SetProcess(false);
    }

    // ============================ 位移子过程 ============================

    private Vector2 ProcessOrbitDisplacement(ref Particle p, float dt)
    {
        if (Mathf.Abs(p.OrbitVel) < 0.01f || dt < 0.001f) return Vector2.Zero;

        Vector2 diff = p.Position;

        float ang = p.OrbitVel * Mathf.Pi * 2f * dt;
        float c = Mathf.Cos(ang);
        float s = Mathf.Sin(ang);

        // GLSL: mat2(vec2(c,-s), vec2(s,c)) 列主序 => [c s; -s c]
        Vector2 rotated = new Vector2(
            c * diff.X + s * diff.Y,
            -s * diff.X + c * diff.Y);

        Vector2 displacement = rotated - diff;
        return displacement / dt;
    }

    private Vector2 ProcessRadialDisplacement(ref Particle p, float dt)
    {
        if (dt < 0.001f) return Vector2.Zero;

        Vector2 diff = p.Position;   // 相对中心

        Vector2 radialDisplacement;
        if (diff.Length() > 0.01f)
            radialDisplacement = diff.Normalized() * p.RadialVel;
        else
            radialDisplacement = GetRandomDirectionFromSpread(ref p.Seed, 360f) * p.RadialVel;

        if (p.RadialVel < 0f && radialDisplacement.Length() > 0.01f)
        {
            float maxLen = Mathf.Min(Mathf.Abs(p.RadialVel), diff.Length() / dt);
            radialDisplacement = radialDisplacement.Normalized() * maxLen;
        }

        return radialDisplacement;
    }

    // ============================ 绘制 ============================

    public override void _Draw()
    {
        if (Sprite == null || _particles == null) return;

        Vector2 texSize = Sprite.GetSize();
        Vector2 frameSize = new Vector2(texSize.X / Mathf.Max(1, SpriteHframes),
                                        texSize.Y / Mathf.Max(1, SpriteVframes));

        int frameX = SpriteFrame % Mathf.Max(1, SpriteHframes);
        int frameY = SpriteFrame / Mathf.Max(1, SpriteHframes);

        Rect2 srcRect = new Rect2(frameX * frameSize.X, frameY * frameSize.Y,
                                  frameSize.X, frameSize.Y);
        Rect2 dstRect = new Rect2(-frameSize * 0.5f, frameSize);

        for (int i = 0; i < _particles.Length; i++)
        {
            ref Particle p = ref _particles[i];
            if (!p.Active || p.Color.A <= 0f) continue;

            DrawSetTransform(p.Position, 0f, p.Scale);
            DrawTextureRectRegion(Sprite, dstRect, srcRect, modulate: p.Color);
        }
    }
}