using MilitaryElite.Models.Enums;

namespace MilitaryElite.Models.Contracts
{
    public interface IMission
    {
        string CodeName { get; }
        State State { get; }

        void CompleteMission();
    }
}
