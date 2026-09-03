using System.Collections.Generic;



public sealed class PlayerState
{
	public int Health = 100;
	public float Hunger = 30;
	public float Temperature = 20;
	public Dictionary<string, int> Resources = new() { ["wood"] = 0, ["stone"] = 0, ["berry"] = 0, ["mushroom_soup"] = 1 };
}
public sealed class ItemDefinition { public string Id = ""; public string DisplayName = ""; public string IconColor = "#ffff00"; }
public sealed class Recipe { public string Id = ""; public Dictionary<string, int> Cost = new(); public string Output = ""; }
