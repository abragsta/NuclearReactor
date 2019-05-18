using NuclearReactor.Core.Contracts;
using NuclearReactor.Core.Enums;

namespace NuclearReactor.Core
{
    public class NuclearReactor : IPressureContainer
    {
        public float Pressure { get; private set; }
        public PressureContainerState PressureContainerState { get; private set; }

        public NuclearReactor()
        {
            Pressure = 0.5f;
            PressureContainerState = PressureContainerState.Closed;
        }

        public void SetState(PressureContainerState pressureContainerState)
        {
            PressureContainerState = pressureContainerState;
        }

        public void UpdatePressure()
        {
            if (PressureContainerState == PressureContainerState.Closed)
            {
                Pressure += 0.03f;
            }
        }
    }
}