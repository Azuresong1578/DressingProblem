using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DressingProblem
{
    class Test
    {
        static void Main(string[] args)
        {
            // successful
            Person p1 = new Person();
            p1.ExecuteCommand("HOT 8, 4, 6, 1, 2, 7");
            // successful
            Person p2 = new Person();
            p2.ExecuteCommand("HOT 8, 6, 4, 2, 1, 7");
            // successful
            Person p3 = new Person();
            p3.ExecuteCommand("COLD 8, 4, 5, 2, 6, 3, 1, 7");
            // successful
            Person p4 = new Person();
            p4.ExecuteCommand("COLD 8, 6, 3, 1, 4, 5, 2, 7");
            // invalid temperature command
            Person p5 = new Person();
            p5.ExecuteCommand("WARM 8, 4, 6, 1, 2, 7");
            // invalid command that doesn't end properly
            Person p6 = new Person();
            p6.ExecuteCommand("HOT");
            // try leave house directly
            Person p7 = new Person();
            p7.ExecuteCommand("HOT 7");
            // try to wear sock in hot temperature
            Person p8 = new Person();
            p8.ExecuteCommand("HOT 8, 6, 3, 1, 4, 1, 2, 7");
            // try to wear jacket in hot temperature
            Person p9 = new Person();
            p9.ExecuteCommand("HOT 8, 4, 5, 6, 1, 2, 7");
            // try to not wear socks and jacket in cold
            Person p10 = new Person();
            p10.ExecuteCommand("COLD 8, 4, 6, 1, 2, 7");
            // take off PJs twice
            Person p11 = new Person();
            p11.ExecuteCommand("HOT 8, 4, 6, 8, 1, 2, 7");
            // wear the same cloth twice
            Person p12 = new Person();
            p12.ExecuteCommand("COLD 8, 4, 6, 5, 5, 1, 2, 7");
            // not taking off PJs before wearing clothes
            Person p13 = new Person();
            p13.ExecuteCommand("COLD 4, 6, 5, 5, 1, 2, 7");
            // wear shoes before socks
            Person p14 = new Person();
            p14.ExecuteCommand("COLD 8, 4, 6, 5, 2, 1, 3, 7");
            // wear shoes before pants
            Person p15 = new Person();
            p15.ExecuteCommand("COLD 8, 4, 5, 2, 3, 1, 6, 7");
            // wear jacket before shirt
            Person p16 = new Person();
            p16.ExecuteCommand("COLD 8, 5, 4, 2, 3, 1, 6, 7");
            // wear hat before shirt
            Person p17 = new Person();
            p17.ExecuteCommand("COLD 8, 2, 5, 4, 3, 1, 6, 7");
        }
    }
}
