using System;
using System.Collections.Generic;
using System.Text;

namespace BatteryManagement
{
    public class BatteryFactor
    {

        BatteryStatusDisplay BatteryStatusDisplay = new BatteryStatusDisplay();
        public bool CheckBatteryCondition(string BatteryFactor, float minBatteryValue, float maxBatteryValue, float BatteryValue)
        {
            bool BatteryStatus;
            if (BatteryValue < minBatteryValue)
            {
                BatteryStatus = BatteryStatusDisplay.PrintMinimumLimit(BatteryFactor, minBatteryValue, BatteryValue);
            }
            else if (BatteryValue > maxBatteryValue)
            {
                BatteryStatus = BatteryStatusDisplay.PrintMaximumLimit(BatteryFactor, maxBatteryValue, BatteryValue);
            }
            else
            {
                BatteryStatus = BatteryStatusDisplay.PrintValid(BatteryFactor, BatteryValue);
            }
            return BatteryStatus;
        }
    }
}
