using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamGame
{
    /*
     * Class "AttackBeginningArgs", containing the following properties:
     * a. Attacker - object of type "Hero"
     * b. RawDamage - integer
     */
    public class AttackBeginningArgs : EventArgs
    {
        public Hero Attacker { get; set; }
        public int RawDamage { get; set; }
    }
}
