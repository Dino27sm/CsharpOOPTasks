namespace _07.MilitaryElite
{
    using _07.MilitaryElite.Interfaces;
    using _07.MilitaryElite.Enumerators;

    public class Mission : IMission
    {
        public Mission(string codeName, MissionStateEnum missionStateEnum)
        {
            this.CodeName = codeName;
            this.MissionStateEnum = missionStateEnum;
        }
        public string CodeName { get; set; }
        public MissionStateEnum MissionStateEnum { get; set; }

        public void CompleteMission(string missionName)
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.MissionStateEnum}";
        }
    }
}
