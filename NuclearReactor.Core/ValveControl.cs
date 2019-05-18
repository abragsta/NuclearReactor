using NuclearReactor.Core.Contracts;

namespace NuclearReactor.Core
{
    public class ValveControl : IValveControl
    {
        private readonly IPressureContainer _pressureContainer;

        public ValveControl(IPressureContainer pressureContainer)
        {
            _pressureContainer = pressureContainer;
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
