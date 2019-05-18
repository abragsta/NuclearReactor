using NuclearReactor.Core.Enums;
using Xunit;

namespace NuclearReactor.Core.UnitTests
{
    public class NuclearReactorTest
    {
        private readonly NuclearReactor _nuclearReactor;

        public NuclearReactorTest()
        {
            _nuclearReactor = new NuclearReactor();
        }

        [Fact]
        public void SetState_NewState_StateIsUpdated()
        {
            _nuclearReactor.SetState(PressureContainerState.Open);

            Assert.Equal(PressureContainerState.Open, _nuclearReactor.PressureContainerState);
        }

        [Fact]
        public void UpdatePressure_PressureContainerStateIsClosed_PressureIsIncreasedBy3Percent()
        {
            var currentPressure = _nuclearReactor.Pressure;
            var expectedPressure = currentPressure + 0.03f;

            _nuclearReactor.SetState(PressureContainerState.Closed);
            _nuclearReactor.UpdatePressure();

            Assert.Equal(expectedPressure, _nuclearReactor.Pressure);
        }
    }
}