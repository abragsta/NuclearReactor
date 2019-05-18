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

            Thread.Sleep(2100);

            Assert.Equal(ValveState.Open, valveControl.ValveState);
            _pressureContainer.Received().SetState(ValveState.Open);
        }

        [Fact]
        public void Close_ValveIsOpen_ValveIsClosing()
        {
            var valveControl = GetValveControl(ValveState.Open);

            valveControl.Close();

            Assert.Equal(ValveState.Closing, valveControl.ValveState);
        }

        [Fact]
        public void Close_ValveIsOpen_ValveIsClosedAfter2Seconds()
        {
            var valveControl = GetValveControl(ValveState.Open);

            valveControl.Close();

            Thread.Sleep(2100);

            Assert.Equal(ValveState.Closed, valveControl.ValveState);
            _pressureContainer.Received().SetState(ValveState.Closed);
        }

        private ValveControl GetValveControl(ValveState valveState)
        {
            return new ValveControl(_pressureContainer, valveState);
        }
    }
}