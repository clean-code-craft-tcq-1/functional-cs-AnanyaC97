using System;
using System.Diagnostics;

public class BatteryCheckerFactors
{
    static bool batteryIsOk(float temperature, float stateOfCharge, float chargeRate)
    {
        bool optimumTemperatureLimit = CheckTemperature(temperature);
        bool optimumStateOfCharge = CheckStateOfCharge(stateOfCharge);
        bool optimumChargeRate = CheckChargeRate(chargeRate);

        return (optimumTemperatureLimit && optimumStateOfCharge && optimumChargeRate);
    }
    static bool CheckTemperature(float temperature)
    {
        if (temperature < 0 || temperature > 45)
        {
            Console.WriteLine("Temperature is out of range!");
            return false;
        }
        return true;
    }
    static bool CheckStateOfCharge(float stateOfCharge)
    {
        if (stateOfCharge < 20 || stateOfCharge > 80)
        {
            Console.WriteLine("State of Charge is out of range!");
            return false;
        }
        return true;
    }
    static bool CheckChargeRate(float chargeRate)
    {
        if (chargeRate > 0.8)
        {
            Console.WriteLine("Charge Rate is out of range!");
            return false;
        }
        return true;
    }
    static void ExpectTrue(bool expression)
    {
        if (!expression)
        {
            Console.WriteLine("Expected true, but got false");
            Environment.Exit(1);
        }
    }
    static void ExpectFalse(bool expression)
    {
        if (expression)
        {
            Console.WriteLine("Expected false, but got true");
            Environment.Exit(1);
        }
    }
    static int Main()
    {
        ExpectTrue(batteryIsOk(25, 70, 0.7f));
        ExpectFalse(batteryIsOk(50, 85, 0.0f));
        Console.WriteLine("All ok");
        return 0;
    }
}
