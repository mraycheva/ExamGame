using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamGame
{
    /*
     * Class "HeroIsDeadArgs", containing the following property:
     * a. DeadHero - object of type "Hero"
     */
    public class HeroIsDeadArgs : EventArgs
    {
        public Hero DeadHero { get; set; }
    }
}
