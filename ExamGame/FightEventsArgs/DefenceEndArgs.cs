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
     * c. HealthPoints - integer
     */
    public class DefenceEndArgs : EventArgs
    {
        public Hero Defender { get; set; }
        public int ActualDamage { get; set; }
        public int HealthPoints { get; set; }
    }
}