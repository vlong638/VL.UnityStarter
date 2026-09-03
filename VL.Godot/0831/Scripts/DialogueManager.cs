using System.Collections.Generic;

namespace OtherworldHero0831;

/// <summary>Reusable dialogue session provider; UI can render any returned session.</summary>
public sealed class DialogueManager
{
    public DialogueSession StartNpcQuest(string speaker, GameState state, QuestManager quests) => new(speaker, quests.CurrentName(state), quests.LinesFor(state), quests.Reward(state));
}

public sealed record DialogueSession(string Speaker, string QuestName, IReadOnlyList<string> Lines, string Reward);
