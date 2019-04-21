using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamGame
{
    /*
     * Class "DefenceBeginningArgs", containing the following properties:
     * a. Defender - object of type "Hero" 
     * b. ActualDamage - integer
     */
    public class DefenceBeginningArgs : EventArgs
    {
        public Hero Defender { get; set; }
        public int ActualDamage { get; set; }
    }
}
