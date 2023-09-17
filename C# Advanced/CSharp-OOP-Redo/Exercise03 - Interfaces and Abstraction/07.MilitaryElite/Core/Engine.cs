namespace MilitaryElite.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using IO.Contracts;
    using Models;
    using Models.Enums;
    using Models.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly ICollection<ISoldier> allSoldiers;

        private Engine()
        {
            allSoldiers = new HashSet<ISoldier>();
        }

        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }
        public void Run()
        {
            string input = string.Empty;

            while ((input = reader.ReadLine()) != "End")
            {
                ISoldier soldier = null;

                string[] soldierInfo = input.Split(' ');
                string soldierType = soldierInfo[0];
                int id = int.Parse(soldierInfo[1]);
                string firstName = soldierInfo[2];
                string lastName = soldierInfo[3];

                if (soldierType != "Spy")
                {
                    decimal salary = decimal.Parse(soldierInfo[4]);

                    if (soldierType == "Private")
                    {
                        soldier = new Private(id, firstName, lastName, salary);
                        
                    }
                    else if (soldierType == "LieutenantGeneral")
                    {
                        ICollection<IPrivate> privates = FindPrivates(soldierInfo);

                        soldier = new LieutenantGeneral(id, firstName, lastName, salary, privates);
                        
                    }
                    else if (soldierType == "Engineer")
                    {
                        string corpsText = soldierInfo[5];
                        bool isValidCorp = Enum.TryParse(corpsText, false, out Corps corps);

                        if (!isValidCorp)
                        {
                            continue;
                        }

                        ICollection<IRepair> repairs = FindRepairs(soldierInfo);
                        soldier = new Engineer(id, firstName, lastName, salary, corps, repairs);

                    }
                    else if (soldierType == "Commando")
                    {
                        string corpsText = soldierInfo[5];
                        bool isValidCorp = Enum.TryParse(corpsText, false, out Corps corps);

                        if (!isValidCorp)
                        {
                            continue;
                        }

                        ICollection<IMission> missions = FindMissions(soldierInfo);

                        soldier = new Commando(id, firstName, lastName, salary, corps, missions);

                    }

                    allSoldiers.Add(soldier);

                    continue;
                }

                int codeNumber = int.Parse(soldierInfo[4]);
                soldier = new Spy(id, firstName, lastName, codeNumber);

                allSoldiers.Add(soldier);
            }

            foreach (ISoldier soldier in allSoldiers)
            {
                writer.WriteLine(soldier.ToString());
            }
        }

        private ICollection<IPrivate> FindPrivates(string[] soldierInfo)
        {
            int[] privateIds = soldierInfo.Skip(5).Select(int.Parse).ToArray();
            ICollection<IPrivate> privates = new HashSet<IPrivate>();

            foreach (int id in privateIds)
            {
                IPrivate currPrivate = (IPrivate)allSoldiers.FirstOrDefault(s => s.Id == id);

                privates.Add(currPrivate);
            }

            return privates;
        }

        private ICollection<IRepair> FindRepairs(string[] soldierInfo)
        {
            string[] repairsInfo = soldierInfo.Skip(6).ToArray();
            ICollection<IRepair> repairs = new HashSet<IRepair>();

            for (int i = 0; i < repairsInfo.Length; i += 2)
            {
                string repairPart = repairsInfo[i];
                int repairTime = int.Parse(repairsInfo[i + 1]);

                IRepair repair = new Repair(repairPart, repairTime);
                repairs.Add(repair);
            }

            return repairs;
        }

        private ICollection<IMission> FindMissions(string[] soldierInfo)
        {
            string[] missionsInfo = soldierInfo.Skip(6).ToArray();
            ICollection<IMission> missions = new HashSet<IMission>();

            for (int i = 0; i < missionsInfo.Length; i += 2)
            {
                string codeName = missionsInfo[i];
                string stateText = missionsInfo[i + 1];

                bool isValidState = Enum.TryParse(stateText, false, out State state);

                if (!isValidState)
                {
                    continue;
                }

                IMission mission = new Mission(codeName, state);
                missions.Add(mission);
            }

            return missions;
        }
    }
}
