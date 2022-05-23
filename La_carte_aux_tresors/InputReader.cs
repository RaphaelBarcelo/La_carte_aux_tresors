using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace La_carte_aux_tresors
{
    public class InputReader
    {
        public InputReader()
        {
        }

        [STAThread]
        public static List<string> ReadFile(string filePath = "../Res/Input/Input.txt")
        {
            List<string> fileLines = new List<string>();
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(filePath);
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //add the line to the list
                    fileLines.Add(line);
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
            return fileLines;
        }
    } 
}
