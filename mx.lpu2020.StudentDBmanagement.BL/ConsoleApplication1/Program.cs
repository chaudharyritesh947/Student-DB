using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        public static void Main()
        {

            string str = "LeadSquaredOrgId:9419;LeadSquaredEmailId:4e92ef03-419f-427e-b60f-3dcf0042bb82;Feedback-ID:9419:92ef2383-e901-11e9-9d9b-069b743e848f::1486035168068;";
            string[] authorsList = str.Split(';');
            //   bio.Substring(0, 12);    
            string[] finalwa = new string[2];
            int i = 0;
            finalwa[0] = authorsList[0].Substring(authorsList[0].IndexOf(':')+1);
            finalwa[1] = authorsList[1].Substring(authorsList[1].IndexOf(':')+1);

            Console.WriteLine(finalwa[0]+"  "+finalwa[1]+"   ");
            /*	foreach(string s in finalwa)
                {
                Console.WriteLine(s);
                }
                */
            Console.Read();


        }
    }
}