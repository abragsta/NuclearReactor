using System.Threading.Tasks;
using NuclearReactor.Core.Contracts;
using NuclearReactor.Core.Enums;

namespace NuclearReactor.Core
{
    public class ValveControl : IValveControl
    {
        private readonly IPressureContainer _pressureContainer;
        public ValveState ValveState { get; private set; }

        public ValveControl(IPressureContainer pressureContainer, ValveState valveState)
        {
            _pressureContainer = pressureContainer;
            this.ValveState = valveState;
        }

        public void Open()
        {
            if (ValveState == ValveState.Closed)
            {
                ValveState = ValveState.Opening;

                Task.Delay(2000).ContinueWith(t =>
                {
                    ValveState = ValveState.Open;
                    _pressureContainer.SetState(ValveState.Open);
                });
            }
        }

        public void Close()
        {
            throw new System.NotImplementedException();
        }
    }
}
