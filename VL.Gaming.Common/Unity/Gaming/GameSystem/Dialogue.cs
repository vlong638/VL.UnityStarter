using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace VL.Gaming.Unity.Gaming.GameSystem
{
    public class Dialogue
    {
        public long Id;
        public long ParentId;
        public DialogueContentType ContentType;
        public DialogueRequirementType RequirementType;
        public double RequirementValue;
        public DialoguePortraitLocation PortraitLocation;
        public string PortraitSource;
        public string Title;
        public string Content;
        public string BackgroundSource;
        public string SoundSource;
        [JsonIgnore]
        public Dialogue RootNode;
        [JsonIgnore]
        public List<Dialogue> Children = new List<Dialogue>();

        public Dialogue(long id, long parentId)
        {
            this.Id = id;
            this.ParentId = parentId;
        }
        [JsonConstructor]
        public Dialogue(long id, long parentId, DialogueContentType contentType, DialoguePortraitLocation portraitLocation, string portraitSource, string title, string content, DialogueRequirementType requirementType = DialogueRequirementType.None, double requirementValue = 0, string backgroundSource = "", string soundSource = "")
        {
            this.Id = id;
            this.ParentId = parentId;
            this.ContentType = contentType;
            this.PortraitLocation = portraitLocation;
            this.PortraitSource = portraitSource;
            this.Title = title;
            this.Content = content;
            this.RequirementType = requirementType;
            this.RequirementValue = requirementValue;
            this.BackgroundSource = backgroundSource;
            this.SoundSource = soundSource;
        }

        public void Insert(Dialogue node)
        {
            if (node.ParentId == this.Id)
            {
                this.Children.Add(node);
                return;
            }
            foreach (var child in this.Children)
            {
                child.Insert(node);
            }
        }
        public Dialogue GetNodeById(long id)
        {
            if (this.Id == id)
            {
                return this;
            }
            foreach (Dialogue child in this.Children)
            {
                Dialogue result = child.GetNodeById(id);
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }
        public int Count()
        {
            int count = 1;
            foreach (var child in Children)
            {
                count += child.Count();
            }
            return count;
        }
        public void TraverseDelegate(Action<Dialogue> action)
        {
            action(this);
            foreach (var child in Children)
            {
                child.TraverseDelegate(action);
            }
        }
    }
    public enum DialogueContentType
    {
        None,
        Dialogue,
        Option,
    }
    public enum DialoguePortraitLocation
    {
        None,
        Left,
        Right,
        Option,
        Main,
    }
    public enum DialogueRequirementType
    {
        None,
        StrengthAttribute,
        AgilityAttribute,
        ConstitutionAttribute,
        IntelligenceAttribute,
        WillpowerAttribute,
        CharismaAttribute,
        LeadershipAttribute,
    }
}
