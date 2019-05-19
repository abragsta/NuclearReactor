using NuclearReactor.Core.Contracts;

namespace NuclearReactor.Core
{
    public class ControlUnit : IControlUnit
    {
        private readonly IValveControl _valveControl;
        private readonly IPressureSensor _pressureSensor;

        private const float UpperLimit = 0.75f;
        private const float LowerLimit = 0.50f;

        public ControlUnit(IValveControl valveControl, IPressureSensor pressureSensor)
        {
            _valveControl = valveControl;
            _pressureSensor = pressureSensor;
        }

        public void InitiateControl()
        {
            var sensorValue = _pressureSensor.GetValue();

            if (sensorValue > UpperLimit)
            {
                _valveControl.Open();
            }

            if (sensorValue < LowerLimit)
            {
                _valveControl.Close();
            }
        }
    }
}