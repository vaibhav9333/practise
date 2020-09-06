using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace txtfilereaden
{
    class Program
    {
        static void Main(string[] args)
        {
            /*//Read and write from text file 
            string someText = "C# Corner is a community of software and data developers";
            File.WriteAllText(@"C:\Users\user\Desktop\vg.txt", someText);
            // Read a file  
            string readText = File.ReadAllText(@"C:\Users\user\Desktop\vg.txt");
            Console.WriteLine(readText);*/
            //emp.decode();
           // emp e = new emp();
            var text = "The quick brown fox jumps over the lazy dog";
            //var text1= "VGhlIHF1aWNrIGJyb3duIGZveCBqdW1wcyBvdmVyIHRoZSBsYXp5IGRvZw";


            //    string text1 ="VGhlIHF1aWNrIGJyb3duIGZveCBqdW1wcyBvdmVyIHRoZSBsYXp5IGRvZw==";
            //   e.Base64StringEncode(text);
            //   e.Base64StringDecode(text1);

            a a1 = new b();
            a1.ab(6);
               
            Console.ReadLine();
        }
    }

   public class a
    {
        public int ab(int a)
        {
            return 5;
        }
    }

    class b:a
    {
        public void ab(int a)
        {
            Console.WriteLine(" print b");
        }
    }
  /*  class emp
    {//encoding and decoding  string code
        public void Base64StringEncode(string originalString)
        {
            var bytes = Encoding.UTF8.GetBytes(originalString);
              var encodedString = Convert.ToBase64String(bytes);

            Console.WriteLine(encodedString);
        }

        public void  Base64StringDecode(string encodedString)
        {
            var bytes = Convert.FromBase64String(encodedString);

            var decodedString = Encoding.UTF8.GetString(bytes);

            Console.WriteLine(decodedString); 
        }
        
    }
    */
}
