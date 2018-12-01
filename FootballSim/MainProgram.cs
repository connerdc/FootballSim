using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballSim
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            //hello here is a change
            Player player = new Player("Conner", "Christopherson", 23, "01/02/1995", "Mizzou", 84, 155, false, 0);
            System.Console.WriteLine(player.printPlayer());
            Console.ReadLine();
        }
    }

    class Player
    {
        //fname, lname, age, college, height, weight, injury (bool), injury length, and all the playing stats (speed, jump, throw power, etc)

        //player information
        private string fname;
        private string lname;
        private int age;
        private string dateOfBirth; //do a date of birth function to figure out date of birth from one string with /'s. So like 5/21/2018.
        private string college;
        private double height; //will be in total inches, could write a small function to turn this into feet/inches
        private double weight; //could do same thing for weight as height
        private bool injury;
        private int injuryLength; //just in # of days out

        //player attributes
        SortedDictionary<string, int> playerAttributes; 
        //general attributes

        public string printPlayer ()
        {
            String playerString = "Name: " + fname + " " + lname + "\nAge: " + age + "\nDate of Birth: " + dateOfBirth + "\nCollege: " + college + "\nHeight: " 
                                    + height + "\nWeight: " + weight + "\nInjury: " + injury + "\nInjury Length: " + injuryLength;
            foreach (KeyValuePair<string, int> kvp in playerAttributes)
            {
                playerString += "\n" + kvp.Key + ": " + kvp.Value;
            }
            return playerString;
        }

        public Player (string firName, string lastName, int pAge, string DoB, string pCollege, double pHeight, double pWeight, bool pInjury, int pInjLength){
            playerAttributes = new SortedDictionary<string, int>();
            initializeAttributes(playerAttributes);
            fname = firName;
            lname = lastName;
            age = pAge;
            dateOfBirth = DoB;
            college = pCollege;
            height = pHeight;
            weight = pWeight;
            injury = pInjury;
            injuryLength = pInjLength;
        }

        private SortedDictionary<String,int> initializeAttributes (SortedDictionary<String,int> playerAtt) {
            //general attributes
            playerAtt.Add("speed", 90);
            playerAtt.Add("awareness", 99);
            playerAtt.Add("strength", 99);
            playerAtt.Add("stamina", 99);
            playerAtt.Add("injury", 99);
            //quarterback attributes
            playerAtt.Add("throwPower", 99);
            playerAtt.Add("throwPowerOnRun", 99);
            playerAtt.Add("throwAccuracyShort", 99);
            playerAtt.Add("throwAccuracyMedium", 99);
            playerAtt.Add("throwAccuracyLong", 99);
            playerAtt.Add("throwAccuracyOnRun", 99);
            playerAtt.Add("throwUnderPressure", 99);
            playerAtt.Add("deceptiveness", 99); //this is stuff like looking off defenders
            playerAtt.Add("defenseRecognition", 99);
            playerAtt.Add("throwRelease", 99); //how fast the release is
            playerAtt.Add("playAction", 99);
            playerAtt.Add("clutchness", 99);
            //receiving attributes
            playerAtt.Add("release", 99);
            playerAtt.Add("jumping", 99);
            playerAtt.Add("routeRunning", 99);
            playerAtt.Add("catching", 99);
            playerAtt.Add("catchRange", 99);
            playerAtt.Add("contestedCatch", 99);
            playerAtt.Add("sidelineCatch", 99);
            playerAtt.Add("spectacularCatch", 99);
            //rushing attributes
            playerAtt.Add("vision", 99);
            playerAtt.Add("shedding", 99);
            playerAtt.Add("elusiveness", 99);
            playerAtt.Add("cutting", 99);
            playerAtt.Add("trucking", 99);
            playerAtt.Add("ballControl", 99);
            playerAtt.Add("acceleration", 99);
            playerAtt.Add("agility", 99);
            //blocking attributes
            playerAtt.Add("powerBlocking", 99);
            playerAtt.Add("technicalBlocking", 99);
            playerAtt.Add("manBlocking", 99);
            playerAtt.Add("zoneBlocking", 99);
            playerAtt.Add("runBLocking", 99);
            playerAtt.Add("passBLocking", 99);
            playerAtt.Add("pullBlocking", 99);
            //defense attributes
            playerAtt.Add("playRecognition", 99);
            playerAtt.Add("blockShedding", 99);
            playerAtt.Add("hitPower", 99);
            playerAtt.Add("tackling", 99);
            playerAtt.Add("powerMoves", 99);
            playerAtt.Add("speedMoves", 99);
            playerAtt.Add("gapDiscipline", 99);
            playerAtt.Add("manCoverage", 99);
            playerAtt.Add("pressCoverage", 99);
            playerAtt.Add("zoneCoverage", 99);

            return playerAtt;
        }
    }
}
