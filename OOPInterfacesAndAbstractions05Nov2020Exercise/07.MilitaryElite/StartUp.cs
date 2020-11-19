using _07.MilitaryElite.Interfaces;
using _07.MilitaryElite.Enumerators;
using System;
using System.Collections.Generic;


namespace _07.MilitaryElite
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<ISoldier> allSoldiers = new List<ISoldier>();
            string readInput = "";
            while ((readInput = Console.ReadLine()) != "End")
            {
                string[] commandPart = readInput.Split(" ");
                string objectType = commandPart[0];
                int id = int.Parse(commandPart[1]);
                string firstName = commandPart[2];
                string lastName = commandPart[3];

                ISoldier aSoldier = null;
                if (objectType == "Private")
                {
                    decimal salary = decimal.Parse(commandPart[4]);
                    aSoldier = new Private(id, firstName, lastName, salary);
                }
                else if (objectType == "LieutenantGeneral")
                {
                    List<IPrivate> generalPrivates = new List<IPrivate>();
                    decimal salary = decimal.Parse(commandPart[4]);
                    for (int i = 5; i < commandPart.Length; i++)
                    {
                        int privateId = int.Parse(commandPart[i]);
                        IPrivate getPrivate = (allSoldiers.Find(x => x.Id == privateId) as Private);
                        generalPrivates.Add(getPrivate);
                    }
                    aSoldier = new LieutenantGeneral(id, firstName, lastName, salary, generalPrivates);
                }
                else if (objectType == "Commando")
                {
                    decimal salary = decimal.Parse(commandPart[4]);
                    if (commandPart.Length > 5)
                    {
                        if (!Enum.TryParse(commandPart[5], out CorpsEnumerator result))
                            continue;
                        List<IMission> missionsList = new List<IMission>();
                        if (commandPart.Length > 6)
                        {
                            for (int i = 6; i < commandPart.Length; i += 2)
                            {
                                string missionCode = commandPart[i];
                                if (Enum.TryParse(commandPart[i + 1], out MissionStateEnum mission))
                                {
                                    IMission aMission = new Mission(missionCode, mission);
                                    missionsList.Add(aMission);
                                }
                            }
                        }
                        aSoldier = new Commando(id, firstName, lastName, salary, result, missionsList);
                    }
                }
                else if (objectType == "Engineer")
                {
                    decimal salary = decimal.Parse(commandPart[4]);
                    if (commandPart.Length > 5)
                    {
                        if (!Enum.TryParse(commandPart[5], out CorpsEnumerator result))
                            continue;
                        List<IRepair> partsList = new List<IRepair>();
                        if (commandPart.Length > 6)
                        {
                            for (int i = 6; i < commandPart.Length; i += 2)
                            {
                                string partName = commandPart[i];
                                int workedHours = int.Parse(commandPart[i + 1]);
                                IRepair aRepairPart = new Repair(partName, workedHours);
                                partsList.Add(aRepairPart);
                            }
                        }
                        aSoldier = new Engineer(id, firstName, lastName, salary, result, partsList);
                    }
                }
                else if (objectType == "Spy")
                {
                    int codeNum = int.Parse(commandPart[4]);
                    aSoldier = new Spy(id, firstName, lastName, codeNum);
                }
                if (aSoldier != null)
                    allSoldiers.Add(aSoldier);
            }
            foreach (var item in allSoldiers)
                Console.WriteLine(item.ToString());
        }
    }
}
