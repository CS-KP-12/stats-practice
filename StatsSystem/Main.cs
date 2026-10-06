using System;

namespace StatsPractice
{
    public static class Program
    {
        public static void Main()
        {
            Stats stats = new Stats();

            stats.SetBaseValue(StatType.Strength, 10f);
            stats.SetBaseValue(StatType.MaxHealth, 100f);

            StatModifier strengthBonus = new StatModifier(StatType.Strength, 5f);
            StatModifier healthBonus = new StatModifier(StatType.MaxHealth, 20f);

            stats.AddModifier(strengthBonus);
            stats.AddModifier(healthBonus);

            float strength = stats.GetValue(StatType.Strength);
            float maxHealth = stats.GetValue(StatType.MaxHealth);

            AssertEqual(15f, strength, "Strength should include the modifier.");
            AssertEqual(120f, maxHealth, "Max health should include the modifier.");

            stats.RemoveModifier(strengthBonus);

            float strengthWithoutModifier = stats.GetValue(StatType.Strength);
            AssertEqual(10f, strengthWithoutModifier, "Removing a modifier should restore the base value.");

            float missingStatValue = stats.GetValue(StatType.Agility);
            AssertEqual(0f, missingStatValue, "An unset stat should return zero.");

            Console.WriteLine("Stats system test passed.");
            Console.WriteLine($"Strength: {strength}");
            Console.WriteLine($"Max health: {maxHealth}");
            Console.WriteLine($"Strength after removing modifier: {strengthWithoutModifier}");
        }

        private static void AssertEqual(float expected, float actual, string message)
        {
            if (expected != actual)
            {
                throw new InvalidOperationException($"{message} Expected: {expected}, Actual: {actual}");
            }
        }
    }
}
