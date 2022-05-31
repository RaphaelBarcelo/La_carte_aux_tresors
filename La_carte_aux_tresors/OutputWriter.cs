using System;
using System.Text;
using System.IO;

namespace La_carte_aux_tresors
{
    public class OutputWriter
    {
        [STAThread]
        public static void Write(string output, string path)
        {
            try
            {
                //Create and Open the File
                File.Create(path).Close();
                StreamWriter sw = new StreamWriter(path, true, Encoding.ASCII);
                sw.Write(output);
                //close the file
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
    }
}
