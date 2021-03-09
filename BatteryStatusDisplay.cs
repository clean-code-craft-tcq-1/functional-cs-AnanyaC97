using System;
using System.Collections.Generic;
using System.Text;

namespace BatteryManagement
{
    public class BatteryStatusDisplay
    {
        public static void PrintMaximumLimit(string BatteryState, float MaxBatteryValue, float BatteryValue)
        {
            Console.WriteLine("Battery Factor: {0} {1} is out of range and has exceeded its maximum limit {2} !", BatteryState, BatteryValue, MaxBatteryValue);
        }
        public static void PrintMinimumLimit(string BatteryState, float MinBatteryValue, float BatteryValue)
        {
            Console.WriteLine("Battery Factor: {0} {1} is out of range and has failed its minimum limit {2} !", BatteryState, BatteryValue, MinBatteryValue);
        }
        public static void PrintValid(string BatteryState, float BatteryValue)
        {
            Console.WriteLine("Battery Factor: " + BatteryState + " " + BatteryValue + " is in the specified limit !");
        }
        public static void ExpectTrue(bool expression)
        {
            if (!expression)
            {
                Console.WriteLine("Expected true, but got false");
                Environment.Exit(1);
            }
            Console.WriteLine();
        }
        public static void ExpectFalse(bool expression)
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
