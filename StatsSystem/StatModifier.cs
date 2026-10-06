using System;

namespace StatsPractice
{
    public class StatModifier
    {
        public StatType StatType { get; set; }
        public float Amount { get; set; }

        public StatModifier(StatType statType, float amount)
        {
            StatType = statType;
            Amount = amount;
        }

        public float ApplyTo(float baseValue)
        {
            return baseValue + Amount;
        }
    }
}
