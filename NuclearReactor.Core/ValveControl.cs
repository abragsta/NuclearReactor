using NuclearReactor.Core.Contracts;
using NuclearReactor.Core.Enums;

namespace NuclearReactor.Core
{
    public class ValveControl : IValveControl
    {
        private readonly IPressureContainer _pressureContainer;
        private readonly ValveState valveState;

        public ValveControl(IPressureContainer pressureContainer, ValveState valveState)
        {
            _pressureContainer = pressureContainer;
            this.valveState = valveState;
        }

        public void Open()
        {
            throw new System.NotImplementedException();
        }

        public void Close()
        {
            throw new System.NotImplementedException();
        }
    }
}
