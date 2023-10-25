namespace AddMinion
{
    public static class SqlQueries
    {
        public const string SELECT_TOWN = @"SELECT Id FROM Towns WHERE Name = @townName";
        public const string ADD_TOWN_TO_DB = @"INSERT INTO Towns (Name) VALUES (@townName)";
        public const string SELECT_VILLAIN = @"SELECT Id FROM Villains WHERE Name = @Name";
        public const string ADD_VILLAIN_TO_DB = @"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";
        public const string SELECT_MINION = @"SELECT Id FROM Minions WHERE Name = @Name";
        public const string ADD_MINION_TO_DB = @"INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";
        public const string ADD_MINIONID_VILLAINID_TO_MINIONSVILLAINS = @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)";
        public const string SELECTCOMPOSITE_PRIMARY_KEY_MINIONSVILLAINS = @"SELECT minionId, villainId FROM MinionsVillains WHERE minionId = @minionId AND villainId = @villainId";
        //public const string SELECT_VILLAIN_FROM_MINIONSVILLAINS = @"SELECT villainId FROM MinionsVillains WHERE villainID = @villainID";
    }
}
