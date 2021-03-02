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
        bool TemperatureLimit;
        if ( temperature < 0 )
            TemperatureLimit = PrintMinimumLimit("Temperature", 0, temperature);
        else if( temperature > 45)
            TemperatureLimit = PrintMaximumLimit("Temperature", 45, temperature);
        else
            TemperatureLimit = PrintValid("Temperature", temperature);
        return TemperatureLimit;
    }
    static bool CheckStateOfCharge(float stateOfCharge)
    {
        bool stateOfChargeLimit;
        if (stateOfCharge < 20)
            stateOfChargeLimit = PrintMinimumLimit("State of Charge", 20, stateOfCharge);
        else if (stateOfCharge > 80)
            stateOfChargeLimit = PrintMaximumLimit("State of Charge", 80, stateOfCharge);
        else
            stateOfChargeLimit = PrintValid("State of Charge", stateOfCharge);
        return stateOfChargeLimit;
    }
    static bool CheckChargeRate(float chargeRate)
    {
        bool chargeRateLimit;
        if (chargeRate > 0.8)
            chargeRateLimit = PrintMaximumLimit("Charge Rate", 0.8f, chargeRate);
        else
            chargeRateLimit = PrintValid("Charge Rate", chargeRate);
        return chargeRateLimit;
    }
    static bool PrintMaximumLimit(string batteryFactor, float MaxBatteryValue, float batteryValue)
    {
        Console.WriteLine("Battery Factor: {0} {1} is out of range and has exceeded its maximum limit {2} !", batteryFactor, batteryValue, MaxBatteryValue);
        return false;
    }
    static bool PrintMinimumLimit(string batteryFactor, float MinBatteryValue, float batteryValue)
    {
        Console.WriteLine("Battery Factor: {0} {1} is out of range and has failed its minimum limit {2} !", batteryFactor, batteryValue, MinBatteryValue);
        return false;
    }
    static bool PrintValid(string batteryFactor, float BatteryValue)
    {
        Console.WriteLine("Battery Factor: " + batteryFactor + " " + BatteryValue + " is in the specified limit !");
        return true;
    }
    static void ExpectTrue(bool expression)
    {
        if (!expression)
        {
            Console.WriteLine("Expected true, but got false");
            Environment.Exit(1);
        }
        Console.WriteLine();
    }
    static void ExpectFalse(bool expression)
    {
        if (expression)
        {
            Console.WriteLine("Expected false, but got true");
            Environment.Exit(1);
        }
        Console.WriteLine();
    }
    static int Main()
    {
        ExpectTrue(batteryIsOk(25, 70, 0.7f));
        ExpectFalse(batteryIsOk(50, 85, 0.0f));
        ExpectFalse(batteryIsOk(-50, 10, 0.9f));
        ExpectFalse(batteryIsOk(30, 100, 0.0f));
        Console.WriteLine("All ok");
        return 0;
    }
}
