using System;
using System.Collections.Generic;

namespace StatsPractice
{
    public class Stats
    {
        private readonly Dictionary<StatType, float> baseValues = new Dictionary<StatType, float>();

        private readonly Dictionary<StatType, List<StatModifier>> modifiers = new Dictionary<StatType, List<StatModifier>>();

        public float GetBaseValue(StatType statType)
        {
            if (baseValues.TryGetValue(statType, out float value))
            {
                return value;
            }

            return 0f;
        }

        public float GetValue(StatType statType)
        {
            float value = GetBaseValue(statType);

            if (!modifiers.TryGetValue(statType, out List<StatModifier> statModifiers))
            {
                return value;
            }

            foreach (StatModifier modifier in statModifiers)
            {
                value = modifier.ApplyTo(value);
            }

            return value;
        }

        public void SetBaseValue(StatType statType, float value)
        {
            baseValues[statType] = value;
        }

        public void AddModifier(StatModifier modifier)
        {
            if (!modifiers.TryGetValue(modifier.StatType, out List<StatModifier> statModifiers))
            {
                statModifiers = new List<StatModifier>();
                modifiers[modifier.StatType] = statModifiers;
            }

            statModifiers.Add(modifier);
        }

        public void RemoveModifier(StatModifier modifier)
        {
            if (modifiers.TryGetValue(modifier.StatType, out List<StatModifier> statModifiers))
            {
                statModifiers.Remove(modifier);
            }
        }

        public IReadOnlyList<StatModifier> GetModifiers(StatType statType)
        {
            if (!modifiers.TryGetValue(statType, out List<StatModifier> statModifiers))
            {
                return Array.Empty<StatModifier>();
            }

            return statModifiers.AsReadOnly();
        }
    }
}
