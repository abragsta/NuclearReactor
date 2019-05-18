using NuclearReactor.Core.Contracts;

namespace NuclearReactor.Core
{
    public class ControlUnit : IControlUnit
    {
        private readonly IValveControl _valveControl;
        private readonly IPressureSensor _pressureSensor;

        public ControlUnit(IValveControl valveControl, IPressureSensor pressureSensor)
        {
            _valveControl = valveControl;
            _pressureSensor = pressureSensor;
        }

        public void InitiateControl()
        {
            throw new System.NotImplementedException();
        }
    }
}
