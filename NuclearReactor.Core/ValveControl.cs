using System.Threading.Tasks;
using NuclearReactor.Core.Contracts;
using NuclearReactor.Core.Enums;

namespace NuclearReactor.Core
{
    public class ValveControl : IValveControl
    {
        private readonly IPressureContainer _pressureContainer;
        public ValveState ValveState { get; private set; }

        public ValveControl(IPressureContainer pressureContainer)
        {
            _pressureContainer = pressureContainer;
            this.ValveState = _pressureContainer.PressureContainerState == PressureContainerState.Open ? 
                ValveState.Open : ValveState.Closed;
        }

        public void Open()
        {
            if (ValveState == ValveState.Closed)
            {
                ValveState = ValveState.Opening;

                Task.Delay(2000).ContinueWith(t =>
                {
                    ValveState = ValveState.Open;
                    _pressureContainer.SetState(PressureContainerState.Open);
                });
            }
        }

        public void Close()
        {
            if (ValveState == ValveState.Open)
            {
                ValveState = ValveState.Closing;

                Task.Delay(2000).ContinueWith(t =>
                {
                    ValveState = ValveState.Closed;
                    _pressureContainer.SetState(PressureContainerState.Closed);
                });
            }
        }
    }
}