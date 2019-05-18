using NuclearReactor.Core.Enums;

namespace NuclearReactor.Core.Contracts
{
    public interface IPressureContainer
    {
        void SetState(PressureContainerState pressureContainerState);
        void UpdatePressure();
        float Pressure { get; }
        PressureContainerState PressureContainerState { get; }
    }
}