using NuclearReactor.Core.Enums;

namespace NuclearReactor.Core.Contracts
{
    public interface IPressureContainer
    {
        void SetState(ValveState valveState);
    }
}
