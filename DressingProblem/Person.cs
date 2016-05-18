using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressingProblem
{
    enum TempType { HOT, COLD };

    class Person
    {
        private TempType Temperature;

        private bool[] ActionStates;

        private string Output;

        private string[] Commands;

        // constructor: set up the state array that represent each kind of action 
        public Person()
        {
            
        }

        // execute the input line according to the rules. 
        // parse the input command into a list and then iterate through
        // executing each command by calling TryAction.
        // if any command failed, stop executing by return. 
        public void ExecuteCommand(string command)
        {
            Commands = command.Split(' ', ',');
            if (Commands.Length < 2)
            {
                Console.WriteLine("fail");
                return;
            }
            string temp = Commands[0];
            if (temp == "HOT")
            {
                Temperature = TempType.HOT;
                ActionStates = new bool[8] { false, false, true, false, true, false, false, true };
            }
            else if (temp == "COLD")
            {
                Temperature = TempType.COLD;
                ActionStates = new bool[8] { false, false, false, false, false, false, false, true };
            }
            else
            {
                Console.WriteLine("fail");
                return;
            }
            for (int i = 1; i < Commands.Length; ++i)
            {
                if (Commands[i] != "")
                {
                    if (TryAction(Commands[i]) == false)
                    {
                        Console.WriteLine(Output);
                        return;
                    }
                }
            }
        }

        // private helper function to access the state array.
        // check the whether a state is true or false.
        // e.g. state 1 true = footwear is already put on
        private bool CheckState(int command)
        {
            return ActionStates[command - 1];
        }

        // private helper function to modify the state array.
        // for each state this function should only be called once.
        private void ChangeState(int command)
        {
            if (command == 8) // Removing PJs
            {
                // set it to be false to represent PJs are taken off
                ActionStates[command - 1] = false;
            }
            else // all other actions
            {
                ActionStates[command - 1] = true;
            }
        }

        // A switch statement to call each command's corresponding
        // function, will return false if the command is not within
        // the scope of 1-8
        private bool TryAction(string command)
        {
            switch (command)
            {
                case "1":
                    return TryFootwear();
                case "2":
                    return TryHeadwear();
                case "3":
                    return TrySocks();
                case "4":
                    return TryShirt();
                case "5":
                    return TryJacket();
                case "6":
                    return TryPants();
                case "7":
                    return TryLeaveHouse();
                case "8":
                    return TryRmPjs();
                default:
                    Output += "fail";
                    return false;
            }
        }

        // Try put on footwear.
        // Checks PJs off, footwear on, pants and socks on
        private bool TryFootwear()
        {
            if (CheckState(8) == true || CheckState(1) == true 
                || CheckState(3) == false || CheckState(6) == false)
            {
                Output += "fail";
                return false;
            }
            Output += (Temperature == TempType.HOT) ? "sandals, " : "boots, ";
            ChangeState(1);
            return true;
        }

        // Try put on headwear.
        // checks PJs off, headwear not on, shirts on
        private bool TryHeadwear()
        {
            if (CheckState(8) == true || CheckState(2) == true
                || CheckState(4) == false)
            {
                Output += "fail";
                return false;
            }
            Output += (Temperature == TempType.HOT) ? "sun visor, " : "hat, ";
            ChangeState(2);
            return true;
        }

        // Try put on socks.
        // checks PJs off, socks not on, and temperature is cold
        private bool TrySocks()
        {
            if (CheckState(8) == true || CheckState(3) == true
                || Temperature == TempType.HOT)
            {
                Output += "fail";
                return false;
            }
            Output += "socks, ";
            ChangeState(3);
            return true;
        }

        // Try put on shirt.
        // check PJs off, shirt not already on
        private bool TryShirt()
        {
            if (CheckState(8) == true || CheckState(4) == true)
            {
                Output += "fail";
                return false;
            }
            Output += (Temperature == TempType.HOT) ? "t-shirt, " : "shirt, ";
            ChangeState(4);
            return true;
        }

        // Try put on jacket.
        // checks PJs off, jacket no already on, temperature is cold,
        // and shirt is on.
        private bool TryJacket()
        {
            if (CheckState(8) == true || CheckState(5) == true
                || Temperature == TempType.HOT || CheckState(4) == false)
            {
                Output += "fail";
                return false;
            }
            Output += "jacket, ";
            ChangeState(5);
            return true;
        }

        // Try put on pants.
        // checks PJs off, pants not already on
        private bool TryPants()
        {
            if (CheckState(8) == true || CheckState(6) == true)
            {
                Output += "fail";
                return false;
            }
            Output += (Temperature == TempType.HOT) ? "shorts, " : "pants, ";
            ChangeState(6);
            return true;
        }

        // Try leave the house.
        // depending on the temperature checks whether the required 
        // clothes are put on. This function returns false not matter what,
        // signal the caller the end of a series of command. 
        private bool TryLeaveHouse()
        {
            if (Temperature == TempType.HOT)
            {
                if (CheckState(1) && CheckState(2) && CheckState(4) && CheckState(6))
                {
                    Output += "leaving house";
                }
                else
                {
                    Output += "fail";
                }
            }
            else
            {
                if (CheckState(1) && CheckState(2) && CheckState(3)
                    && CheckState(4) && CheckState(5) && CheckState(6))
                {
                    Output += "leaving house";
                }
                else
                {
                    Output += "fail";
                }
            }
            return false;
        }

        // Try to remove PJs,
        // false if PJs already removed. 
        private bool TryRmPjs()
        {
            if (CheckState(8) == false)
            {
                Output += "fail";
                return false;
            }
            Output += "Removing PJs, ";
            ChangeState(8);
            return true;
        }
    }
}
