using NuclearReactor.Core.Contracts;
using NuclearReactor.Core.Enums;

namespace NuclearReactor.Core
{
    public class NuclearReactor : IPressureContainer
    {
        public float Pressure { get; set; }

        public NuclearReactor()
        {
            Pressure = 0.5f;
        }

        public void SetState(ValveState valveState)
        {
            throw new System.NotImplementedException();
        }

        public void UpdatePressure()
        {
            throw new System.NotImplementedException();
        }

        public float GetPressureValue()
        {
            throw new System.NotImplementedException();
        }
    }
}