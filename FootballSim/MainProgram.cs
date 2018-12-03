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
            Player player = new Player("Conner", "Christopherson", 23, "Quarterback", "01/02/1995", "Mizzou", 84, 155, false, 0);
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
        private string position;
        private string dateOfBirth; //do a date of birth function to figure out date of birth from one string with /'s. So like 5/21/2018.
        private string college;
        private double height; //will be in total inches, could write a small function to turn this into feet/inches
        private double weight; //could do same thing for weight as height
        private bool injury;
        private int injuryLength; //just in # of days out

        //player attributes
        SortedDictionary<string, double> playerAttributes;
        //general attributes

        public Player(string firName, string lastName, int pAge, string pPosition, string DoB, string pCollege, double pHeight, double pWeight, bool pInjury, int pInjLength)
        {
            playerAttributes = new SortedDictionary<string, double>();
            initializeAttributes(playerAttributes);
            fname = firName;
            lname = lastName;
            age = pAge;
            position = pPosition;
            dateOfBirth = DoB;
            college = pCollege;
            height = pHeight;
            weight = pWeight;
            injury = pInjury;
            injuryLength = pInjLength;
        }

        public string printPlayer ()
        {
            String playerString = "Name: " + fname + " " + lname + "\nAge: " + age + "\nPosition: " + position + "\nDate of Birth: " + dateOfBirth + "\nCollege: " + college + "\nHeight: " 
                                    + height + "\nWeight: " + weight + "\nInjury: " + injury + "\nInjury Length: " + injuryLength;
            foreach (KeyValuePair<string, double> kvp in playerAttributes)
            {
                playerString += "\n" + kvp.Key + ": " + kvp.Value;
            }
            double playerOverall = calculatePlayerOverall(this);
            playerString += "\nOverall Rating: " + playerOverall;
            return playerString;
        }

        public double calculatePlayerOverall(Player player)
        {
            double overallRating = 0;

            switch(player.position)
            {
                case "Quarterback":
                    /*Formula (Out of 100):
                     * Awareness: 10
                     * Speed: 3
                     * Throw Power: 15
                     * TP On Run: 7
                     * TA Short: 10
                     * TA Medium: 12
                     * TA Deep: 9
                     * Throw Under Pressure: 5
                     * Deceptiveness: 8
                     * Defensive Recognition: 10
                     * Throw Release: 5
                     * Play Action: 3
                     * Clutchness: 3
                    */
                    overallRating = (playerAttributes["awareness"] * .1) + (playerAttributes["speed"] * .03) + (playerAttributes["throwPower"] * .15) + (playerAttributes["throwPowerOnRun"] * .07)
                                    + (playerAttributes["throwAccuracyShort"] * .1) + (playerAttributes["throwAccuracyMedium"] * .12) + (playerAttributes["throwAccuracyLong"] * .09)
                                    + (playerAttributes["throwUnderPressure"] * .05) + (playerAttributes["deceptiveness"] * .08) + (playerAttributes["defenseRecognition"] * .1)
                                    + (playerAttributes["throwRelease"] * .05) + (playerAttributes["playAction"] * .03) + (playerAttributes["clutchness"] * .03);
                    break;
            }

            return overallRating;
        }

        private SortedDictionary<String,double> initializeAttributes (SortedDictionary<String,double> playerAtt) {
            //general attributes
            playerAtt.Add("speed", 60.0);
            playerAtt.Add("awareness", 80.0);
            playerAtt.Add("strength", 99);
            playerAtt.Add("stamina", 99);
            playerAtt.Add("injury", 99);
            //quarterback attributes
            playerAtt.Add("throwPower", 97);
            playerAtt.Add("throwPowerOnRun", 95);
            playerAtt.Add("throwAccuracyShort", 78);
            playerAtt.Add("throwAccuracyMedium", 85);
            playerAtt.Add("throwAccuracyLong", 85);
            playerAtt.Add("throwAccuracyOnRun", 90);
            playerAtt.Add("throwUnderPressure", 90);
            playerAtt.Add("deceptiveness", 85); //this is stuff like looking off defenders
            playerAtt.Add("defenseRecognition", 87);
            playerAtt.Add("throwRelease", 75); //how fast the release is
            playerAtt.Add("playAction", 90);
            playerAtt.Add("clutchness", 95);
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
