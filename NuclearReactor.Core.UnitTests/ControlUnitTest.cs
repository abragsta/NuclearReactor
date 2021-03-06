﻿using NSubstitute;
using NuclearReactor.Core.Contracts;
using Xunit;

namespace NuclearReactor.Core.UnitTests
{
    public class ControlUnitTest
    {
        private readonly ControlUnit _controlUnit;
        private readonly IPressureSensor _pressureSensor;
        private readonly IValveControl _valveControl;

        public ControlUnitTest()
        {
            _pressureSensor = Substitute.For<IPressureSensor>();
            _valveControl = Substitute.For<IValveControl>();
            _controlUnit = new ControlUnit(_valveControl, _pressureSensor);
        }

        [Fact]
        public void InitiateControl_PressureIsAbove75_ValveIsOpened()
        {
            _pressureSensor.GetValue().Returns(0.76f);

            _controlUnit.InitiateControl();

            _valveControl.Received().Open();
        }

        [Fact]
        public void InitiateControl_PressureIsBelow50_ValveIsClosed()
        {
            _pressureSensor.GetValue().Returns(0.49f);

            _controlUnit.InitiateControl();

            _valveControl.Received().Close();
        }

        [Fact]
        public void InitiateControl_PressureIsOptimal_NoActionIsExecuted()
        {
            _pressureSensor.GetValue().Returns(0.65f);

            _controlUnit.InitiateControl();

            _valveControl.DidNotReceive().Close();
            _valveControl.DidNotReceive().Open();
        }
    }
}
