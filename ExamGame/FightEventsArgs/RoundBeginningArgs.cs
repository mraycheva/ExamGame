using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamGame
{
    /*
     * Class "RoundBeginningArgs", containing the following properties:
     * a. Round - integer
     * b. Defender - object of type "Hero" 
     * c. Attacker - object of type "Hero" 
     */
    public class RoundBeginningArgs : EventArgs
    {
        public int Round { get; set; }
        public Hero Defender { get; set; }
        public Hero Attacker { get; set; }
    }
}
