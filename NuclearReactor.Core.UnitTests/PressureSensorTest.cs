using NSubstitute;
using NuclearReactor.Core.Contracts;
using Xunit;

namespace NuclearReactor.Core.UnitTests
{
    public class PressureSensorTest
    {
        [Fact]
        public void GetValue_Void_ReturnsPressureValue()
        {
            var pressureContainer = Substitute.For<IPressureContainer>();
            var pressureSensor = new PressureSensor(pressureContainer);

            var expectedValue = 0.6f;

            pressureContainer.Pressure.Returns(expectedValue);

            var actualValue = pressureSensor.GetValue();

            Assert.Equal(expectedValue, actualValue);
        }
    }
}