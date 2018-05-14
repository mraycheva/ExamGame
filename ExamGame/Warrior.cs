using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamGame
{
    /*
     * Class "Warrior", extending class "Hero" and containing the following constants:
     * a. ATTACK_POINTS - integer
     * b. ARMOUR_POINTS - integer
     */
    public class Warrior : Hero
    {
        private const int ATTACK_POINTS = 250;
        private const int ARMOUR_POINTS = 250;

        public Warrior(string nickname) : base(nickname, ATTACK_POINTS, ARMOUR_POINTS)
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
         * When defending, does the default hero deffence.
         */
        public override void DefendAgainst(int rawDamage)
        {
            DefaultDefence(rawDamage);
        }
    }
}