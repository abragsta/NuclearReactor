using System.Threading;
using NSubstitute;
using NuclearReactor.Core.Contracts;
using NuclearReactor.Core.Enums;
using Xunit;

namespace NuclearReactor.Core.UnitTests
{
    public class ValveControlTest
    {
        private readonly IPressureContainer _pressureContainer;

        public ValveControlTest()
        {
            _pressureContainer = Substitute.For<IPressureContainer>();
        }

        [Fact]
        public void Open_ValveIsClosed_ValveIsOpening()
        {
            var valveControl = GetValveControl(ValveState.Closed);

            valveControl.Open();

            Assert.Equal(ValveState.Opening, valveControl.ValveState);
        }

        [Fact]
        public void Open_ValveIsClosed_ValveIsOpenAfter2Seconds()
        {
            var valveControl = GetValveControl(ValveState.Closed);

            valveControl.Open();

            Thread.Sleep(2000);

            Assert.Equal(ValveState.Open, valveControl.ValveState);
        }

        private ValveControl GetValveControl(ValveState valveState)
        {
            return new ValveControl(_pressureContainer, valveState);
        }
    }
}