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
    }
}