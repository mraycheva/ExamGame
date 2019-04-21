using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamGame
{
    /*
     * Class "AttackBeginningArgs", containing the following property:
     * a. Attacker - object of type "Hero"
     */
    public class AttackEndArgs : EventArgs
    {
        public Hero Attacker { get; set; }
    }
}