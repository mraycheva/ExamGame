using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamGame
{
    /*
     * Class "Assassin", extending class "Hero" and containing the following constants:
     * a. ATTACK_POINTS - integer
     * b. ARMOUR_POINTS - integer
     * c. MULTIPLY_DAMAGE_CHANCE - integer
     * d. MULTIPLY_DAMAGE_PERCENT - integer
     */
    public class Assassin : Hero
    {
        private const int ATTACK_POINTS = 400;
        private const int ARMOUR_POINTS = 300;
        private const int MULTIPLY_DAMAGE_CHANCE = 30;
        private const int MULTIPLY_DAMAGE_PERCENT = 300;

        public Assassin(string nickname) : base(nickname, ATTACK_POINTS, ARMOUR_POINTS)
        {
        }

        /*
         * When attacking, has a chance to do multiplied damage.
         * 
         * Does the attack with a chance of multiplied damage,
         * given the indicated chance and amount of increasement.
         * 
         * Returns the raw damage as integer.
         */
        public override int Attack()
        {
            return IncreasedAttack(MULTIPLY_DAMAGE_CHANCE, MULTIPLY_DAMAGE_PERCENT);
        }

        /*
         * When defending, does the default hero deffence.
         */
        public override void DefendAgainst(int rawDamage)
        {
            DefaultDefence(rawDamage);
        }
    }
}
