using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamGame
{
    /*
     * Class "Barbarian", extending class "Hero" and containing the following constants:
     * a. ATTACK_POINTS - integer
     * b. ARMOUR_POINTS - integer
     * c. MULTIPLY_DAMAGE_CHANCE - integer
     * d. MULTIPLY_DAMAGE_PERCENT - integer
     * e. BLOCK_ATTACK_CHANCE - integer
     */
    public class Illusionist : Hero
    {
        private const int ATTACK_POINTS = 300;
        private const int ARMOUR_POINTS = 200;
        private const int MULTIPLY_DAMAGE_CHANCE = 20;
        private const int MULTIPLY_DAMAGE_PERCENT = 200;
        private const int BLOCK_ATTACK_CHANCE = 25;

        public Illusionist(string nickname) : base(nickname, ATTACK_POINTS, ARMOUR_POINTS)
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
         * When defending, has a chance to completely block the attack and receive no damage.
         * 
         * Does the deffence with a chance of completely blocking the attack,
         * given the indicated chance for it to happen.
         */
        public override void DefendAgainst(int rawDamage)
        {
            DefenceCouldBlockAttack(rawDamage, BLOCK_ATTACK_CHANCE);
        }
    }
}
