using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamGame
{
    /*
     * Class "HaveAWinnerArgs", containing the following property:
     * a. Winner - object of type "Hero"
     */
    public class HaveAWinnerArgs : EventArgs
    {
        public Hero Winner { get; set; }
    }
}
