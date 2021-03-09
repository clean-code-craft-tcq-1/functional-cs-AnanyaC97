using System;
using System.Collections.Generic;
using System.Text;

namespace BatteryManagement
{
    public class BatteryFactor
    {
        public bool CheckBatteryCondition(string BatteryState, float MinBatteryValue, float MaxBatteryValue, float BatteryValue)
        {
            if (BatteryValue < MinBatteryValue)
            {
                BatteryStatusDisplay.PrintMinimumLimit(BatteryState, MinBatteryValue, BatteryValue);
                return false;
            }
            else if (BatteryValue > MaxBatteryValue)
            {
                BatteryStatusDisplay.PrintMaximumLimit(BatteryState, MaxBatteryValue, BatteryValue);
                return false;
            }
            else
            {
                BatteryStatusDisplay.PrintValid(BatteryState, BatteryValue);
                return true;
            }
        }
    }
}
