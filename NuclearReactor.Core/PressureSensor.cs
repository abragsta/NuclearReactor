using NuclearReactor.Core.Contracts;

namespace NuclearReactor.Core
{
    public class PressureSensor : IPressureSensor
    {
        private readonly IPressureContainer _pressureContainer;

        public PressureSensor(IPressureContainer pressureContainer)
        {
            _pressureContainer = pressureContainer;
        }

        public float GetValue()
        {
            throw new System.NotImplementedException();
        }
    }
}
