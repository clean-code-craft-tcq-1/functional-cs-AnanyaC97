using System;
using System.Diagnostics;

namespace BatteryManagement
{
    public class BatteryCheckerFactors
    {
        public static float minTemperatureLimit = 0;
        public static float maxTemperatureLimit = 45;
        public static float minStateOfCharge = 20;
        public static float maxStateOfCharge = 80;
        public static float minChargeRate = 0.5f;
        public static float maxChargeRate = 0.8f;

        public static bool batteryIsOk(float temperature, float stateOfCharge, float chargeRate)
        {
            BatteryFactor batteryFactor = new BatteryFactor();

            bool optimumTemperatureLimit = batteryFactor.CheckBatteryCondition("Temperature", minTemperatureLimit, maxTemperatureLimit, temperature);
            bool optimumStateOfCharge = batteryFactor.CheckBatteryCondition("State of Charge", minStateOfCharge, maxStateOfCharge, stateOfCharge);
            bool optimumChargeRate = batteryFactor.CheckBatteryCondition("Charge Rate", minChargeRate, maxChargeRate, chargeRate);

            return (optimumTemperatureLimit && optimumStateOfCharge && optimumChargeRate);
        }
        
        public static int Main()
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
