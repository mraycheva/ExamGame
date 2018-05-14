using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamGame
{
    /*
     * Class "Hero", containing the following constants:
     * a. MIN_ATTACK - integer
     * b. MAX_ATTACK - integer
     * c. MIN_DEFENCE - integer
     * d. MAX_DEFENCE - integer
     * 
     * Also, the following properties:
     * a. HealthPoints - integer
     * b. AttackPoints - integer
     * c. ArmourPoints - integer
     * d. Nickname - text
     * 
     * And the following events:
     * a. HeroIsDead
     * b. AttackBeginning
     * c. AttackEnd
     * d. DefenceBeginning
     * e. DefenceEnd
     */
    abstract public class Hero
    {
        private const int MIN_ATTACK = 80;
        private const int MAX_ATTACK = 120;
        private const int MIN_DEFENCE = 80;
        private const int MAX_DEFENCE = 120;

        public int HealthPoints { get; set; }
        public int AttackPoints { get; }
        public int ArmourPoints { get; }
        public string Nickname { get; set; }

        public event EventHandler<AttackBeginningArgs> AttackBeginning;
        public event EventHandler<AttackEndArgs> AttackEnd;
        public event EventHandler<DefenceBeginningArgs> DefenceBeginning;
        public event EventHandler<DefenceEndArgs> DefenceEnd;
        public event EventHandler<HeroIsDeadArgs> HeroIsDead;

        public Hero(string nickname, int attackPoints, int armourPoints)
        {
            HealthPoints = 20000;
            AttackPoints = attackPoints;
            ArmourPoints = armourPoints;
            Nickname = nickname;
        }

        /* 
         * Raises the event "AttackBeginning", if an subscription for it exists.
         */
        private void MakesAttack(int rawDamage)
        {
            if (AttackBeginning != null)
            {
                new EventHandler<AttackBeginningArgs>(AttackBeginning)
                    (this, new AttackBeginningArgs
                    {
                        RawDamage = rawDamage,
                        Attacker = this
                    });
            }
        }

        /* 
         * Raises the event "AttackEnd", if an subscription for it exists.
         */
        private void EndsAttack(int rawDamage)
        {
            if (AttackEnd != null)
            {
                new EventHandler<AttackEndArgs>(AttackEnd)
                    (this, new AttackEndArgs
                    {
                        Attacker = this
                    });
            }
        }

        /* 
         * Raises the event "DefenceBeginnig", if an subscription for it exists.
         */
        private void DoesDefence(int actualDamage)
        {
            if (DefenceBeginning != null)
            {
                new EventHandler<DefenceBeginningArgs>(DefenceBeginning)
                    (this, new DefenceBeginningArgs
                    {
                        ActualDamage = actualDamage,
                        Defender = this
                    });
            }
        }

        /* 
         * Raises the event "DefenceEnd", if an subscription for it exists.
         */
        private void EndsDefence(int actualDamage)
        {
            if (DefenceEnd != null)
            {
                new EventHandler<DefenceEndArgs>(DefenceEnd)
                    (this, new DefenceEndArgs
                    {
                        ActualDamage = actualDamage,
                        Defender = this,
                        HealthPoints = HealthPoints
                    });
            }
        }

        /* 
         * Raises the event "HeroIsDead", if an subscription for it exists.
         */
        private void Dies()
        {
            if (HeroIsDead != null)
            {
                new EventHandler<HeroIsDeadArgs>(HeroIsDead)
                    (this, new HeroIsDeadArgs
                    {
                        DeadHero = this
                    });
            }
        }

        /*
         * When attacking, all heroes do a percentage of their attack points as raw damage.
         * 
         * Calculates the raw damage as a percent of the attack points.
         * 
         * Raises the "MakeAttack" event.
         * 
         * Returns the raw damage as integer.
         */
        private int Attack(int percent)
        {
            int rawDamage = percent * AttackPoints / 100;

            MakesAttack(rawDamage);

            return rawDamage;
        }

        /*
         * When defending, all heroes take damage, reduced with a percentage of their armour points.
         * The actual damage received reduces their health points. 
         * When the health points become zero or less, the hero is dead.
         * 
         * Calculates the reduced damage as the given reducing percent of the armour points.
         * Calculates the actual damage as dividing the reduced damage from the raw damage.
         * 
         * Updates the health points after the actual damage
         * as diving the actual damage points from the health points.
         * 
         * If the health points become a negative number, they are made zero.
         * 
         * Raises the "DoesDefence" event.
         * 
         * Checks whether the hero's health points are zero.
         * If yes, raises the "HeroDies" event.
         * 
         * Returns the actual damage as integer.
         */
        private int Defence(int rawDamage, int reducingPercent)
        {
            int reducedDamage = reducingPercent * ArmourPoints / 100;
            int actualDamage = rawDamage - reducedDamage;

            HealthPoints -= actualDamage;

            if (HealthPoints < 0)
            {
                HealthPoints = 0;
            }

            DoesDefence(actualDamage);

            if (HealthPoints == 0)
            {
                Dies();
            }

            return actualDamage;
        }

        /*
         * When attacking, all heroes do randomly between the min and max allowed percentage
         * of their attack points as raw damage.
         * 
         * Calculates a random number between the min and max allowed percentage.
         * Makes attack with the calculated percent.
         * 
         * Returns the raw damage as integer.
         */
        protected int DefaultAttack()
        {
            int percent = new Random().Next(MIN_ATTACK, MAX_ATTACK + 1);

            return Attack(percent);
        }

        /*
         * When defending, all heroes take damage,
         * reduced randomly with between the min and max allowed percentage of their armour points.
         * 
         * Calculates the percent of reducing the raw damage.
         * 
         * Does the defence with the calculated percent of reducing the raw damage.
         * 
         * Returns the actual damage as integer.
         */
        protected int DefaultDefence(int rawDamage)
        {
            int reducingPercent = new Random().Next(MIN_DEFENCE, MAX_DEFENCE + 1);
            return Defence(rawDamage, reducingPercent);
        }

        /*
         * When attacking, some heroes have a chance to do multiplied damage.
         * 
         * Generates a random number within 1 to 100.
         * If the number equals or is less than the indicated chance for it to happen,
         * makes attack with the indicated percent of the attack points as raw damage.
         * 
         * If not, does the default hero attack.
         * 
         * Returns the raw damage as integer.
         */
        protected int IncreasedAttack(int MULTIPLY_DAMAGE_CHANCE, int MULTIPLY_DAMAGE_PERCENT)
        {
            if (new Random().Next(1, 101) <= MULTIPLY_DAMAGE_CHANCE)
            {
                return Attack(MULTIPLY_DAMAGE_PERCENT);
            }
            return DefaultAttack();
        }

        /*
         * When defending, some heroes have a chance to multiply their defence.
         * 
         * Generates a random number within 1 to 100.
         * If the number equals or is less than the indicated chance for it to happen,
         * the defence is done by decreasing the raw damage with the indicated percent of the armour points.
         * 
         * If not, does the default hero attack.
         * 
         * Returns the raw damage as integer.
         */
        protected int IncreasedDefence(int rawDamage, int MULTIPLY_DEFENCE_CHANCE, int MULTIPLY_DEFENCE_PERCENT)
        {
            if (new Random().Next(1, 101) <= MULTIPLY_DEFENCE_CHANCE)
            {
                return Defence(rawDamage, MULTIPLY_DEFENCE_PERCENT);
            }
            return DefaultDefence(rawDamage);
        }

        /*
         * When defending, has a chance to completely block the attack and receive no damage.
         * 
         * Generates a random number within 1 to 100.
         * If the number equals or is less than the indicated chance for it to happen,
         * recieves no damage at all.
         * And raises the "DoesDefence" event.
         * 
         * If not, does the default hero defence.
         */
        protected void DefenceCouldBlockAttack(int rawDamage, int BLOCK_ATTACK_CHANCE)
        {
            if (new Random().Next(1, 101) <= BLOCK_ATTACK_CHANCE)
            {
                DoesDefence(0);
                return;
            }

            DefaultDefence(rawDamage);
        }

        abstract public int Attack();
        abstract public void DefendAgainst(int rawDamage);
    }
}