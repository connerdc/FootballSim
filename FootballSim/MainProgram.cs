using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Stuff Want to Do:
 * 1. Add more specialized roles overall rating. (Slot Receiver)
 * 2. Make a random player generator
 */
namespace FootballSim
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            //hello here is a change
            //Player player = new Player("Conner", "Christopherson", 23, "Left Guard", "01/02/1995", "Mizzou", 84, 155, false, 0);
            //System.Console.WriteLine(player.printPlayer());
            string[] firstNames = {"Hal", "Wilson", "Emile", "Emmanuel", "Elwood", "Parker", "Lucas", "Gonzalo", "Miquel", "Al", "Bradly", "Royal", "Stanford", "Rusty", "Raymundo", "Dan", "Leo",
                                  "Tyler", "Edgar", "Boris", "Amos", "Giuseppe", "Virgil", "Burton", "Alexis", "Dong", "Cornell", "Robbie", "Travis", "Jerry", "Brock", "Alberto", "Damien", "Brian",
                                  "Larry", "Percy", "Ramon", "Kory", "Robert", "Wilton", "Asa", "Buddy", "Porfirio", "Warren", "Efrain", "Alfonso", "Nicolas", "Lou", "Merle", "Bernard"};


            Console.ReadLine();
        }
    }

    class Team
    {
        private string name;
        private string stadium;

        private ArrayList players;

        public Team(string tName, string tStadium)
        {
            players = new ArrayList();
            name = tName;
            stadium = tStadium;
        }

        public void addPlayer(Player aPlayer)
        {
            players.Add(aPlayer);
        }
    }

    class Contract
    {
        private int length;
        private double salary;
        private double 
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
                                    + height + "\nWeight: " + weight + "\nInjury: " + injury + "\nInjury Length: " + injuryLength + "\n\nPlayer Attributes:\n";
            double playerOverall = calculatePlayerOverall(this);
            playerString += "\nOverall Rating: " + playerOverall + "\n";
            foreach (KeyValuePair<string, double> kvp in playerAttributes)
            {
                playerString += "\n" + kvp.Key + ": " + kvp.Value;
            }
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
                     * Accleration: 2
                     * Agility: 1
                     * Throw Power: 13
                     * TP On Run: 7
                     * TA Short: 10
                     * TA Medium: 12
                     * TA Deep: 9
                     * Throw Under Pressure: 5
                     * Deceptiveness: 7
                     * Defensive Recognition: 10
                     * Throw Release: 5
                     * Play Action: 3
                     * Clutchness: 3
                    */
                    overallRating = (playerAttributes["awareness"] * .1) + (playerAttributes["speed"] * .03) + (playerAttributes["throwPower"] * .13) + (playerAttributes["throwPowerOnRun"] * .07)
                                    + (playerAttributes["throwAccuracyShort"] * .1) + (playerAttributes["throwAccuracyMedium"] * .12) + (playerAttributes["throwAccuracyLong"] * .09)
                                    + (playerAttributes["throwUnderPressure"] * .05) + (playerAttributes["deceptiveness"] * .07) + (playerAttributes["defenseRecognition"] * .1)
                                    + (playerAttributes["throwRelease"] * .05) + (playerAttributes["playAction"] * .03) + (playerAttributes["clutchness"] * .03) + (playerAttributes["accleration"] * .02) 
                                    + (playerAttributes["agility"] * .01);
                    break;
                case "Running Back":
                    /*Formula (Out of 100):
                     * Awareness: 10
                     * Speed: 10
                     * Vision: 12
                     * Shedding: 8
                     * Elusiveness: 8
                     * Cutting: 7
                     * Trucking: 3
                     * Ball Control: 7
                     * Acceleration: 10
                     * Agility: 8
                     * Release: 2
                     * Route Running: 7
                     * Catching: 8
                    */
                    overallRating = (playerAttributes["awareness"] * .1) + (playerAttributes["speed"] * .1) + (playerAttributes["vision"] * .12) + (playerAttributes["shedding"] * .08)
                                    + (playerAttributes["elusiveness"] * .08) + (playerAttributes["cutting"] * .07) + (playerAttributes["trucking"] * .03)
                                    + (playerAttributes["ballControll"] * .07) + (playerAttributes["acceleration"] * .1) + (playerAttributes["agility"] * .08)
                                    + (playerAttributes["release"] * .02) + (playerAttributes["routeRunning"] * .07) + (playerAttributes["catching"] * .08);
                    break;
                case "Wide Receiver":
                    /*Formula (Out of 100):
                     * Awareness: 10
                     * Speed: 10
                     * Release: 5
                     * Jumping: 8
                     * Route Running: 12
                     * Catching: 12
                     * Catch Range: 5
                     * Contested Catch: 4
                     * Sideline Catch: 3
                     * Spectacular Catch: 3
                     * Shedding: 1
                     * Elusiveness: 3
                     * Cutting: 2 
                     * Ball Control: 3
                     * Acceleration: 8
                     * Agility: 6
                    */
                    overallRating = (playerAttributes["awareness"] * .1) + (playerAttributes["speed"] * .1) + (playerAttributes["release"] * .05) + (playerAttributes["jumping"] * .08)
                                    + (playerAttributes["routeRunning"] * .12) + (playerAttributes["catching"] * .12) + (playerAttributes["catchRange"] * .05)
                                    + (playerAttributes["contestedCatch"] * .04) + (playerAttributes["sidelineCatch"] * .03) + (playerAttributes["spectacularCatch"] * .03)
                                    + (playerAttributes["shedding"] * .01) + (playerAttributes["elusiveness"] * .03) + (playerAttributes["cutting"] * .02) + (playerAttributes["ballControl"] * .03)
                                    + (playerAttributes["acceleration"] * .08) + (playerAttributes["agility"] * .06);
                    break;
                case "Tight End":
                    /*Formula (Out of 100):
                     * Awareness: 8
                     * Speed: 8
                     * Release: 6
                     * Jumping: 6
                     * Route Running: 8
                     * Catching: 10
                     * Catch Range: 7
                     * Contested Catch: 6
                     * Sideline Catch: 2
                     * Spectacular Catch: 2
                     * Shedding: 2
                     * Trucking: 2
                     * Elusiveness: 1
                     * Cutting: 1
                     * Ball Control: 3
                     * Acceleration: 6
                     * Agility: 5
                     * Strength: 2
                     * Pass Blocking: 1
                     * Run Blocking: 4
                     * Power Blocking: 2
                    */
                    overallRating = (playerAttributes["awareness"] * .08) + (playerAttributes["speed"] * .08) + (playerAttributes["release"] * .06) + (playerAttributes["jumping"] * .06)
                                    + (playerAttributes["routeRunning"] * .08) + (playerAttributes["catching"] * .1) + (playerAttributes["catchRange"] * .07)
                                    + (playerAttributes["contestedCatch"] * .06) + (playerAttributes["sidelineCatch"] * .02) + (playerAttributes["spectacularCatch"] * .02)
                                    + (playerAttributes["shedding"] * .02) + (playerAttributes["trucking"] * .02) + (playerAttributes["elusiveness"] * .01) + (playerAttributes["cutting"] * .01)
                                    + (playerAttributes["ballControl"] * .03) + (playerAttributes["acceleration"] * .06) + (playerAttributes["agility"] * .05) + (playerAttributes["strength"] * .02)
                                    + (playerAttributes["passBlocking"] * .01) + (playerAttributes["runBlocking"] * .04) + (playerAttributes["powerBlocking"] * .02);
                    break;
                case "Left Tackle":
                    /*Formula (Out of 100):
                     * Awareness: 12
                     * Speed: 5
                     * Power Blocking: 8
                     * Technical Blocking: 14
                     * Man Blocking: 10
                     * Zone Blocking: 7
                     * Run Blocking: 10
                     * Pass Blocking: 14
                     * Pull Blocking: 5
                     * Strength: 12
                     */
                    overallRating = (playerAttributes["awareness"] * .12) + (playerAttributes["speed"] * .05) + (playerAttributes["powerBlocking"] * .08) + (playerAttributes["technicalBlocking"] * .14)
                                    + (playerAttributes["manBlocking"] * .1) + (playerAttributes["zoneBlocking"] * .07) + (playerAttributes["runBlocking"] * .1)
                                    + (playerAttributes["passBlocking"] * .14) + (playerAttributes["pullBlocking"] * .05) + (playerAttributes["strength"] * .12);
                    break;
                case "Left Guard":
                    /*Formula (Out of 100):
                     * Awareness: 10
                     * Speed: 4
                     * Power Blocking: 12
                     * Technical Blocking: 10
                     * Man Blocking: 10
                     * Zone Blocking: 10
                     * Run Blocking: 12
                     * Pass Blocking: 10
                     * Pull Blocking: 8
                     * Strength: 14
                     */
                    overallRating = (playerAttributes["awareness"] * .1) + (playerAttributes["speed"] * .04) + (playerAttributes["powerBlocking"] * .12) + (playerAttributes["technicalBlocking"] * .1)
                                    + (playerAttributes["manBlocking"] * .1) + (playerAttributes["zoneBlocking"] * .1) + (playerAttributes["runBlocking"] * .12)
                                    + (playerAttributes["passBlocking"] * .1) + (playerAttributes["pullBlocking"] * .08) + (playerAttributes["strength"] * .14);
                    break;
                case "Center":
                    /*Formula (Out of 100):
                     * Awareness: 14
                     * Speed: 4
                     * Power Blocking: 10
                     * Technical Blocking: 10
                     * Man Blocking: 9
                     * Zone Blocking: 11
                     * Run Blocking: 14
                     * Pass Blocking: 9
                     * Pull Blocking: 7
                     * Strength: 12
                     */
                    overallRating = (playerAttributes["awareness"] * .14) + (playerAttributes["speed"] * .04) + (playerAttributes["powerBlocking"] * .1) + (playerAttributes["technicalBlocking"] * .1)
                                    + (playerAttributes["manBlocking"] * .09) + (playerAttributes["zoneBlocking"] * .11) + (playerAttributes["runBlocking"] * .14)
                                    + (playerAttributes["passBlocking"] * .09) + (playerAttributes["pullBlocking"] * .07) + (playerAttributes["strength"] * .12);
                    break;
                case "Right Guard":
                    /*Formula (Out of 100):
                     * Awareness: 10
                     * Speed: 4
                     * Power Blocking: 13
                     * Technical Blocking: 9
                     * Man Blocking: 11
                     * Zone Blocking: 9
                     * Run Blocking: 13
                     * Pass Blocking: 9
                     * Pull Blocking: 8
                     * Strength: 14
                     */
                    overallRating = (playerAttributes["awareness"] * .1) + (playerAttributes["speed"] * .04) + (playerAttributes["powerBlocking"] * .13) + (playerAttributes["technicalBlocking"] * .09)
                                    + (playerAttributes["manBlocking"] * .11) + (playerAttributes["zoneBlocking"] * .09) + (playerAttributes["runBlocking"] * .13)
                                    + (playerAttributes["passBlocking"] * .09) + (playerAttributes["pullBlocking"] * .08) + (playerAttributes["strength"] * .14);
                    break;
                case "Right Tackle":
                    /*Formula (Out of 100):
                     * Awareness: 10
                     * Speed: 5
                     * Power Blocking: 9
                     * Technical Blocking: 12
                     * Man Blocking: 11
                     * Zone Blocking: 7
                     * Run Blocking: 11
                     * Pass Blocking: 13
                     * Pull Blocking: 5
                     * Strength: 12
                     */
                    overallRating = (playerAttributes["awareness"] * .1) + (playerAttributes["speed"] * .05) + (playerAttributes["powerBlocking"] * .09) + (playerAttributes["technicalBlocking"] * .12)
                                    + (playerAttributes["manBlocking"] * .11) + (playerAttributes["zoneBlocking"] * .07) + (playerAttributes["runBlocking"] * .11)
                                    + (playerAttributes["passBlocking"] * .13) + (playerAttributes["pullBlocking"] * .05) + (playerAttributes["strength"] * .12);
                    break;
            }

            return overallRating;
        }

        private SortedDictionary<String,double> initializeAttributes (SortedDictionary<String,double> playerAtt) {
            //general attributes
            playerAtt.Add("speed", 70.0);
            playerAtt.Add("awareness", 80.0);
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
            playerAtt.Add("runBlocking", 99);
            playerAtt.Add("passBlocking", 99);
            playerAtt.Add("pullBlocking", 99);
            playerAtt.Add("strength", 99);
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
