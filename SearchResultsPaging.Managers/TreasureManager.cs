using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SearchResultsPaging.Types;

namespace SearchResultsPaging.Managers
{
    public static class TreasureManager
    {
        #region Names

        private static string[] treasureFirstName = new string[10]
        {
            "Glittering",
            "Sparkling",
            "Golden",
            "Dark",
            "Evil",
            "Poisonous",
            "Magic",
            "Silver",
            "Radiant",
            "Valiant"
        };

        private static string[] treasureLastName = new string[10]
        {
            "Helm",
            "Glove",
            "Box",
            "Disc",
            "Rod",
            "Coin",
            "Goblet",
            "Sword",
            "Arrow",
            "Key"
        };

        #endregion

        public static Treasure CreateRandom()
        {
            Treasure treasure = new Treasure();

            treasure.Name = HelperManager.CreateRandomName(treasureFirstName, treasureLastName);
            treasure.Value = HelperManager.Random.Next(1, 500);

            return treasure;
        }
    }
}
