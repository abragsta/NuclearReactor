using NuclearReactor.Core.Contracts;
using NuclearReactor.Core.Enums;

namespace NuclearReactor.Core
{
    public class NuclearReactor : IPressureContainer
    {
        public float Pressure { get; private set; }
        public ValveState ValveState { get; private set; }

        public NuclearReactor()
        {
            Pressure = 0.5f;
            ValveState = ValveState.Closed;
        }

        public void SetState(ValveState valveState)
        {
            throw new System.NotImplementedException();
        }

        public void UpdatePressure()
        {
            throw new System.NotImplementedException();
        }
    }
}