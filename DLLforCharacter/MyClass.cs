﻿using System;
using System.Collections.Generic;

namespace CharacterClass
{
    [Serializable]
    public class PlayerInfo
    {
        public string UserName { get; set; }
        public bool FileCreated { get; set; }
        public Hero H1 { get; set; }
        public Hero H2 { get; set; }
        public Hero H3 { get; set; }
        public Hero H4 { get; set; }
        public Hero SelectedHero { get; set; }

        [Serializable]
        public class Hero
        {
            public string Name { get; set; }
            public string Gender { get; set; }
            public int Level { get; set; }
            public int XP { get; set; }
            public float Health { get; set; }
            public String Area { get; set; }
            public float xPosition { get; set; }
            public float yPosition { get; set; }
            public float zPosition { get; set; }
            public float Rotation { get; set; }
        }
        public List<Card> AllCards { get; set; }
        public Card CurrentCard { get; set; }
        [Serializable]
        public class Card
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public int Damage { get; set; }
        }

        public PlayerInfo()
        {

        }

        public PlayerInfo(string name)
        {
            UserName = name;
        }
    }
    public class CardInfo
    {
        public List<PlayerInfo.Card> AllCards { get; set; }
        public PlayerInfo.Card CurrentCard { get; set; }
    }
}

