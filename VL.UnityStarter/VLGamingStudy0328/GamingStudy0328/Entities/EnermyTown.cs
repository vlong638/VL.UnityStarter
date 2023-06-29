using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scenes.VLGamingStudy0328
{
    public class EnermyTown : Entrance, ICloneableObject<EnermyTown>
    {
        public EnermyTownType EnermyTownType;
        public EnermyTown(GameObject imageGO, EnermyTownType enermyTownType, List<CreatureSeed> creatureSeeds) : base(imageGO, EntranceType.Town)
        {
            EnermyTownType = enermyTownType;
            CreatureSeeds = creatureSeeds;
        }

        public List<CreatureSeed> CreatureSeeds = new List<CreatureSeed>();
        public List<Creature> Armies = new List<Creature>();

        internal void GenerateEnermy(GameBoard gameBoard)
        {
            if (Armies.Count >= 3)
                return;

            foreach (var creatureSeeds in CreatureSeeds)
            {
                if (creatureSeeds.SeedRandom.GetNext() == 1)
                {
                    var creature = creatureSeeds.Creature.Clone();
                    creature.CreatureType = CreatureType.Enermy;
                    var creatureModel = VLDictionaries.CodeCreatureMathModels[creature.Name];
                    creatureModel.Decorate(creature);
                    creature.X = X;
                    creature.Y = Y;
                    creature.SpriteGO.transform.parent = gameBoard.CreaturesGO.transform;
                    creature.SpriteGO.transform.position = gameBoard.GetPosition(creature.X, creature.Y);
                    Armies.Add(creature);
                    gameBoard.Enermies.Add(creature);
                    gameBoard.Floors[X, Y].Creatures.Add(creature);
                    gameBoard.DisplayText($"{creature.Name}出现了");
                    return;
                }
            }
        }

        public EnermyTown Clone()
        {
            return new EnermyTown(Object.Instantiate(SpriteGO), EnermyTownType, CreatureSeeds);
        }
    }
}
