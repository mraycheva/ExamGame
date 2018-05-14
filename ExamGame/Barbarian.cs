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
     * e. MULTIPLY_DEFFENCE_CHANCE - integer
     * f. MULTIPLY_DEFFENCE_PERCENT - integer
     */
    public class Barbarian : Hero
    {
        private const int ATTACK_POINTS = 350;
        private const int ARMOUR_POINTS = 100;
        private const int MULTIPLY_DAMAGE_CHANCE = 2;
        private const int MULTIPLY_DAMAGE_PERCENT = 300;
        private const int MULTIPLY_DEFFENCE_CHANCE = 5;
        private const int MULTIPLY_DEFFENCE_PERCENT = 200;

        public Barbarian(string nickname) : base(nickname, ATTACK_POINTS, ARMOUR_POINTS)
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
         * When defending, has a chance to do a increased deffence.
         * 
         * Does the deffence with a chance of multiplied reduction of the raw damage,
         * given the indicated chance and percent of increasement.
         * 
         * Returns the raw damage as integer.
         */
        public override void DefendAgainst(int rawDamage)
        {
            IncreasedDefence(rawDamage, MULTIPLY_DEFFENCE_CHANCE, MULTIPLY_DEFFENCE_PERCENT);
        }
    }
}