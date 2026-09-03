using System.Collections.Generic;

namespace OtherworldHero0831;

public sealed class QuestManager
{
    public string CurrentName(GameState state) => state.QuestId switch { 1 => "初识", 2 => "工具", 3 => "武器", _ => "劳有所得" };
    public IReadOnlyList<string> LinesFor(GameState state) => state.QuestId switch
    {
        1 => new[] { "可怜的人族，老奥尔菲看见你晕倒在这里了。", "主角：…", "主角：（内心活动：大胡子老头，好矮，但看起来十分壮硕。）", "你是从哪里来的？", "主角：蓝星", "没听过的地方，也不奇怪。", "你看起来很虚弱，来尝尝奥尔菲的菌菇汤。" },
        2 => new[] { "地面上并不是很安全。", "你可以四处走走。", "棕胡子可以分享给你一些果腹的面包菌。", "不过需要你付出相应的劳动来换取。", "主角：可我一无所有。", "你可以帮奥尔菲采集木材。" },
        3 => new[] { "小伙子，别急着走。", "无尽森林外围虽然不是很危险，但也经常有野兽出没。", "这把铁剑给你防身。", "瞧你这身子骨，应该不至于被几只灰狼吃了吧。" },
        _ => new[] { "劳有所得：采集资源并守护据点，奥尔菲会继续给予你报酬。" }
    };
    public string Reward(GameState state) => state.QuestId switch { 1 => "菌菇汤、饥饿引导提示钥匙、任务2令牌", 2 => "铁斧、工具引导提示钥匙、任务3令牌", 3 => "铁剑、装备引导提示钥匙、任务4令牌", _ => "菌菇汤 ×2" };
    public string Guide(GameState state) => state.QuestId switch { 1 => "你饿了，饥饿值会随着时间掉落，为 0 会饿死。", 2 => "试试将刚获得的工具装备起来吧。", _ => "按 I 打开物品栏，试试将刚获得的武器装备起来吧。" };
    public void Complete(GameState state)
    {
        state.CompletedQuests.Add($"任务{state.QuestId}");
        if (state.QuestId == 1) state.Inventory.Add("菌菇汤");
        if (state.QuestId == 2) state.Inventory.Add("铁斧");
        if (state.QuestId == 3) state.Inventory.Add("铁剑");
        state.QuestId = System.Math.Min(4, state.QuestId + 1);
    }
}
