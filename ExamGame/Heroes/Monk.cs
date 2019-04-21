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
     * c. BLOCK_ATTACK_CHANCE - integer
     */
    public class Monk : Hero
    {
        private const int ATTACK_POINTS = 350;
        private const int ARMOUR_POINTS = 200;
        private const int BLOCK_ATTACK_CHANCE = 30;

        public Monk(string nickname) : base(nickname, ATTACK_POINTS, ARMOUR_POINTS)
        {
        }

        /*
         * When attacking, does the default hero attack.
         */
        public override int Attack()
        {
            return DefaultAttack();
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
