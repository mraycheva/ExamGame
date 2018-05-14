using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamGame
{
    /*
     * Class "Program" implementing console interface interaction.
     */
    class Program
    {
        /*
         * When the "RoundBeginning" event is being raised,
         * prints in the console the round number
         * and the health points of the hero who is receiving the attack.
         */
        private static void GameEngine_RoundBeginning(object sender, RoundBeginningArgs e)
        {
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Round " + e.Round);
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine(e.Defender.Nickname + "'s health points before the attack: " + e.Defender.HealthPoints + ".");
        }

        /*
         * When the "RoundEnd" event is being raised,
         * prints in the console the health points of the defending hero
         * and message for end of round.
         */
        private static void GameEngine_RoundEnd(object sender, RoundEndArgs e)
        {
            Console.WriteLine(e.Defender.Nickname + "'s health points after the attack: " + e.Defender.HealthPoints + ".");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("End of round " + e.Round);
        }

        /*
         * When the "AttackBeginning" event is being raised,
         * prints in the console the pure damage unleashed from the attacking hero.
         */
        private static void GameEngine_AttackBeginning(object sender, AttackBeginningArgs e)
        {
            Console.WriteLine(e.Attacker.Nickname + " unleashed " + e.RawDamage + " points of pure damage.");
        }

        /*
         * When the "DefenceBeginning" event is being raised,
         * prints in the console the actual damage received from the defending hero.
         */
        private static void GameEngine_DefenceBeginning(object sender, DefenceBeginningArgs e)
        {
            Console.WriteLine(e.Defender.Nickname + " recieved " + e.ActualDamage + " points of actual damage.");
        }

        /*
         * When the "DefenceEnd" event is being raised,
         * prints in the console the health points of the hero who was attacked.
         */
        private static void GameEngine_DefenceEnd(object sender, DefenceEndArgs e)
        {
            Console.WriteLine(e.Defender.Nickname + "'s health points: " + e.Defender.HealthPoints + ".");
        }

        /*
         * When the "HeroIsDead" event is being raised,
         * prints in the console the nickname of the hero who died.
         */
        private static void GameEngine_HeroIsDead(object sender, HeroIsDeadArgs e)
        {
            Console.WriteLine();
            Console.WriteLine(e.DeadHero.Nickname + " is now dead.");
        }

        /*
         * When the "HaveAWinner" event is being raised,
         * prints in the console the nickname of the winner.
         */
        private static void GameEngine_HaveAWinner(object sender, HaveAWinnerArgs e)
        {
            Console.WriteLine("Winner: " + e.Winner.Nickname + ".");
        }

        static void Main(string[] args)
        {
            var firstHero = new Knight("Knight");
            var secondHero = new Barbarian("Barbarian");
            
            var gameEngine = new GameEngine<Knight, Barbarian>(firstHero, secondHero);
            
            gameEngine.RoundBeginning += GameEngine_RoundBeginning;
            gameEngine.RoundEnd += GameEngine_RoundEnd;
            gameEngine.AttackBeginning += GameEngine_AttackBeginning;
            gameEngine.DefenceBeginning += GameEngine_DefenceBeginning;
            gameEngine.DefenceEnd += GameEngine_DefenceEnd;
            gameEngine.HeroIsDead += GameEngine_HeroIsDead;
            gameEngine.HaveAWinner += GameEngine_HaveAWinner;

            gameEngine.Fight();

            Console.ReadKey();
        }
    }
}
