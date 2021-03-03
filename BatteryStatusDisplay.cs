using System;
using System.Collections.Generic;
using System.Text;

namespace BatteryManagement
{
    public class BatteryStatusDisplay
    {
        public bool PrintMaximumLimit(string batteryFactor, float MaxBatteryValue, float batteryValue)
        {
            Console.WriteLine("Battery Factor: {0} {1} is out of range and has exceeded its maximum limit {2} !", batteryFactor, batteryValue, MaxBatteryValue);
            return false;
        }
        public bool PrintMinimumLimit(string batteryFactor, float MinBatteryValue, float batteryValue)
        {
            Console.WriteLine("Battery Factor: {0} {1} is out of range and has failed its minimum limit {2} !", batteryFactor, batteryValue, MinBatteryValue);
            return false;
        }
        public bool PrintValid(string batteryFactor, float BatteryValue)
        {
            Console.WriteLine("Battery Factor: " + batteryFactor + " " + BatteryValue + " is in the specified limit !");
            return true;
        }
        public void ExpectTrue(bool expression)
        {
            if (!expression)
            {
                Console.WriteLine("Expected true, but got false");
                Environment.Exit(1);
            }
            Console.WriteLine();
        }
        public void ExpectFalse(bool expression)
        {
            if (expression)
            {
                Console.WriteLine("Expected false, but got true");
                Environment.Exit(1);
            }
            Console.WriteLine();
        }
    }
}