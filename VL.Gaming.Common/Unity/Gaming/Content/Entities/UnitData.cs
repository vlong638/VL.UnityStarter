﻿using System;
using System.Collections.Generic;
using VL.Gaming.Unity.Gaming.Content.Enums;

namespace VL.Gaming.Unity.Gaming.Content.Entities
{
    [Serializable]
    public class UnitData
    {
        public string Name { get; set; }
        public UnitType UnitType;
        public RaceType RaceType;
        public UnitAttributes UnitAttributes;
        public List<Equipment> Equipments;
        public ProfessionType ProfessionType;
        public List<ProfessionSkill> ProfessionSkills;

        public CombatAttributes CombatAttributes;
        public List<CombatSkill> CombatSkills;
    }
}
