using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamGame
{
    /*
     * Class "GameEngine", containing the following variable:
     * a. _round - integer
     * 
     * Also, the following objects:
     * a. _firstHero - of type extending "Hero"
     * b. _secondHero - of type extending "Hero"
     * c. _attacker - of type "Hero"
     * d. _defender - of type "Hero"
     * 
     * And the following events:
     * a. RoundBeginning
     * b. RoundEnd
     * c. AttackBeginning
     * d. AttackEnd
     * e. DefenceBeginning
     * f. DefenceEnd
     * g. HeroIsDead
     * h. HaveAWinner
     */
    public class GameEngine<F, S>
        where F : Hero
        where S : Hero
    {
        private int _round;

        private F _firstHero;
        private S _secondHero;
        private Hero _attacker;
        private Hero _defender;
        
        public event EventHandler<RoundBeginningArgs> RoundBeginning;
        public event EventHandler<RoundEndArgs> RoundEnd;
        public event EventHandler<AttackBeginningArgs> AttackBeginning;
        public event EventHandler<AttackEndArgs> AttackEnd;
        public event EventHandler<DefenceBeginningArgs> DefenceBeginning;
        public event EventHandler<DefenceEndArgs> DefenceEnd;
        public event EventHandler<HeroIsDeadArgs> HeroIsDead;
        public event EventHandler<HaveAWinnerArgs> HaveAWinner;

        public GameEngine(F firstHero, S secondHero)
        {
            _firstHero = firstHero;
            _secondHero = secondHero;

            _firstHero.AttackBeginning += Hero_AttackBeginning;
            _secondHero.AttackBeginning += Hero_AttackBeginning;

            _firstHero.AttackEnd += Hero_AttackEnd;
            _secondHero.AttackEnd += Hero_AttackEnd;

            _firstHero.DefenceBeginning += Hero_DefenceBeginning;
            _secondHero.DefenceBeginning += Hero_DefenceBeginning;

            _firstHero.DefenceEnd += Hero_DefenceEnd;
            _secondHero.DefenceEnd += Hero_DefenceEnd;

            _firstHero.HeroIsDead += Hero_IsDead;
            _secondHero.HeroIsDead += Hero_IsDead;
        }

        /*
         * Increases the round counter with 1.
         * Raises the event "RoundBeginning", if an subscription for it exists.
         * The attacker attacks and the defender defends.
         */
        private void NewRound()
        {
            _round++;

            if (RoundBeginning != null)
            {
                new EventHandler<RoundBeginningArgs>(RoundBeginning)
                    (this, new RoundBeginningArgs
                    {
                        Round = _round,
                        Defender = _defender,
                        Attacker = _attacker
                    });
            }

            _defender.DefendAgainst(_attacker.Attack());

        }

        /*
         * Raises the event "EndOfRound", if an subscription for it exists.
         */
        private void EndOfRound()
        {
            if (RoundBeginning != null)
            {
                new EventHandler<RoundEndArgs>(RoundEnd)
                    (this, new RoundEndArgs
                    {
                        Round = _round,
                        Defender = _defender,
                        Attacker = _attacker
                    });
            }
        }

        /*
         * Raises the event "AttackBeginning", if an subscription for it exists.
         */
        private void Hero_AttackBeginning(object sender, AttackBeginningArgs e)
        {
            if (AttackBeginning != null)
            {
                new EventHandler<AttackBeginningArgs>(AttackBeginning)
                    (this, e);
            }
        }

        /*
         * Raises the event "AttackEnd", if an subscription for it exists.
         */
        private void Hero_AttackEnd(object sender, AttackEndArgs e)
        {
            if (AttackEnd != null)
            {
                new EventHandler<AttackEndArgs>(AttackEnd)
                    (this, e);
            }
        }

        /*
         * Raises the event "DefenceBeginning", if an subscription for it exists.
         */
        private void Hero_DefenceBeginning(object sender, DefenceBeginningArgs e)
        {
            if (DefenceBeginning != null)
            {
                new EventHandler<DefenceBeginningArgs>(DefenceBeginning)
                    (this, e);
            }
        }

        /*
        * Raises the event "DefenceEnd", if an subscription for it exists.
        */
        private void Hero_DefenceEnd(object sender, DefenceEndArgs e)
        {
            if (DefenceEnd != null)
            {
                new EventHandler<DefenceEndArgs>(DefenceEnd)
                    (this, e);
            }
        }

        /*
         * Raises the event "HeroIsDead", if an subscription for it exists.
         */
        private void Hero_IsDead(object sender, HeroIsDeadArgs e)
        {
            if (HeroIsDead != null)
            {
                new EventHandler<HeroIsDeadArgs>(HeroIsDead)
                    (this, e);
            }
        }

        /*
         * Raises the event "HaveAWinner", if an subscription for it exists.
         * The "attacker" and "defender" roles are being unassigned.
         */
        private void NewWin(Hero winner)
        {

            if (HaveAWinner != null)
            {
                new EventHandler<HaveAWinnerArgs>(HaveAWinner)
                    (this, new HaveAWinnerArgs
                    {
                        Winner = winner
                    });

                _attacker = null;
                _defender = null;
            }
        }
        
        /*
         * Swaps the two heroes' roles of being an attacker and defender.
         */
        private void SwapHeroesRoles()
        {
            Hero swap = _attacker;
            _attacker = _defender;
            _defender = swap;
        }

        /*
         * Swaps the two heroes' roles.
         * Calls new round.
         * Ends current round.
         */
        private void RoundImplementation()
        {
            SwapHeroesRoles();
            NewRound();
            EndOfRound();
        }

        /*
         * * Implements a fight where the two heroes fight each other in turns
         * (hero 1 attacks and hero 2 defends;
         * if hero 2 survives the attack, hero 2 attacks back;
         * the game continues until one of the heroes dies).
         * 
         * Makes initial check whether both heroes are alive
         * (e.g. whether their health points are more than zero).
         * 
         * If not, a fight cannot happen.
         * If yes, randomly decides which hero will attack first and the fight begins.
         * 
         * The round begins.
         * 
         * After the round ends, checks whether the hero, who was defending, survived.
         * 
         * If no, the fight ends and the attacking hero wins.
         * If yes, a new round begins.
         * 
         */
        public void Fight()
        {
            if ((_firstHero.HealthPoints <= 0) || (_secondHero.HealthPoints <= 0))
            {
                return;
            }

            _attacker = _firstHero;
            _defender = _secondHero;

            if (new Random().Next(1, 3) == 1)
            {
                _attacker = _secondHero;
                _defender = _firstHero;
            }

            while (true)
            {
                RoundImplementation();

                if (_defender.HealthPoints <= 0)
                {
                    NewWin(_attacker);
                    return;
                }
            }
        }
    }
}