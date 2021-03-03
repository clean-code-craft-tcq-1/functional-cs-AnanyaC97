using System;
using System.Collections.Generic;
using System.Text;

namespace BatteryManagement
{
    public class BatteryFactor
    {
        public float minTemperatureLimit = 0;
        public float maxTemperatureLimit = 45;
        public float minStateOfCharge = 20;
        public float maxStateOfCharge = 80;
        public float minChargeRate = 0.5f;
        public float maxChargeRate = 0.8f;

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
        public bool CheckTemperature(float temperature)
        {
            bool TemperatureLimit = CheckBatteryCondition("Temperature", minTemperatureLimit, maxTemperatureLimit, temperature);
            return TemperatureLimit;
        }
        public bool CheckStateOfCharge(float stateOfCharge)
        {
            bool stateOfChargeLimit = CheckBatteryCondition("State of Charge", minStateOfCharge, maxStateOfCharge, stateOfCharge);
            return stateOfChargeLimit;
        }
        public bool CheckChargeRate(float chargeRate)
        {
            bool chargeRateLimit = CheckBatteryCondition("Charge Rate", minChargeRate, maxChargeRate, chargeRate);
            return chargeRateLimit;
        }
    }
}