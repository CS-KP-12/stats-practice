using UnityEngine;

namespace StatsPractice
{
    public class PlayerStats : MonoBehaviour
    {
        private float maxHealth = 100f;
        private float strength = 10f;
        private float agility = 10f;
        private float intelligence = 10f;
        private float vitality = 10f;

        public Stats Stats { get; private set; }

        public float CurrentHealth { get; private set; }

        private void Spawn()
        {
            Stats = new Stats();
            Stats.SetBaseValue(StatType.MaxHealth, maxHealth);
            Stats.SetBaseValue(StatType.Strength, strength);
            Stats.SetBaseValue(StatType.Agility, agility);

            CurrentHealth = Stats.GetValue(StatType.MaxHealth);
        }

        public void AddModifier(StatModifier modifier)
        {
            Stats.AddModifier(modifier);
        }

        public void RemoveModifier(StatModifier modifier)
        {
            Stats.RemoveModifier(modifier);
        }

        public void Heal(float amount)
        {
            CurrentHealth = Mathf.Min(Stats.GetValue(StatType.MaxHealth), CurrentHealth + amount);
        }

        public void Damage(float amount)
        {
            CurrentHealth = Mathf.Max(0f, CurrentHealth - amount);
        }
    }
}
