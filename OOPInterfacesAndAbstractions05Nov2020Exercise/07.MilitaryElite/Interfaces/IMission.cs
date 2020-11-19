namespace _07.MilitaryElite.Interfaces
{
    using _07.MilitaryElite.Enumerators;

    public interface IMission
    {
        public string CodeName { get; set; }
        public MissionStateEnum MissionStateEnum { get; set; }

        public void CompleteMission(string missionName);
    }
}
