using System;
using System.Diagnostics;

namespace BatteryManagement
{
    class BatteryCheckerFactors
    {
        public static bool batteryIsOk(float temperature, float stateOfCharge, float chargeRate)
        {
            BatteryFactor batteryFactor = new BatteryFactor();

            bool optimumTemperatureLimit = batteryFactor.CheckTemperature(temperature);
            bool optimumStateOfCharge = batteryFactor.CheckStateOfCharge(stateOfCharge);
            bool optimumChargeRate = batteryFactor.CheckChargeRate(chargeRate);

            return (optimumTemperatureLimit && optimumStateOfCharge && optimumChargeRate);
        }

        private static int Main()
        {
            BatteryStatusDisplay batteryStatusDisplay = new BatteryStatusDisplay();

            batteryStatusDisplay.ExpectTrue(batteryIsOk(25, 70, 0.7f));
            batteryStatusDisplay.ExpectFalse(batteryIsOk(50, 85, 0.0f));
            batteryStatusDisplay.ExpectFalse(batteryIsOk(-50, 10, 0.9f));
            batteryStatusDisplay.ExpectFalse(batteryIsOk(30, 100, 0.0f));

            Console.WriteLine("All ok");
            return 0;
        }
    }
}