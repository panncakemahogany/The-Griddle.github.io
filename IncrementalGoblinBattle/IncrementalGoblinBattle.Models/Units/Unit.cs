using IncrementalGoblinBattle.BLL.DiceRoller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncrementalGoblinBattle.Models.Units
{
    public class Unit
    {
        private int hitpoints { get; set; }
        public bool IsAnimated { get; set; }
        public CreatureType Type { get; set; }

        public Unit(int hp)
        {
            hitpoints = hp;
            Type = CreatureType.Goblin;
        }

        public virtual int GetHitpoints()
        {
            return hitpoints;
        }

        public virtual void HasBeenDefeated()
        {
            IsAnimated = hitpoints > 0;
        }

        public virtual void TakeDamage(int damage)
        {
            hitpoints -= damage;

            HasBeenDefeated();
        }

        public virtual void MeleeAttack(Unit target)
        {
            int damage = Dice.Roll20();

            target.TakeDamage(damage);
        }
    }
}
