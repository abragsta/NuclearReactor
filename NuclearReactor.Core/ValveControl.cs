using NuclearReactor.Core.Contracts;
using NuclearReactor.Core.Enums;

namespace NuclearReactor.Core
{
    public class ValveControl : IValveControl
    {
        private readonly IPressureContainer _pressureContainer;
        public ValveState ValveState { get; }

        public ValveControl(IPressureContainer pressureContainer, ValveState valveState)
        {
            _pressureContainer = pressureContainer;
            this.ValveState = valveState;
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
