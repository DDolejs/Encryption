using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    class Program
    {
        const string encrypted_sentence = "Pokud hledáte pomocnou ruku, najdete ji na konci své paže.";
        static void Main(string[] args)
        {
            Encryptor e = new Encryptor();            
            Console.WriteLine("Šifrování pomocí XOR: " + e.XOR("PRAVDA"));
            Console.WriteLine("Šifrování pomocí Caesar: " + e.Caesar(7));
            Console.ReadLine();
        }
        private class Encryptor 
        {
            public string XOR(string key) 
            { 
                string encrypted_message = "";
                for (int i = 0; i < encrypted_sentence.Length; ++i)
                {
                    encrypted_message += (char)(encrypted_sentence[i] ^ key[i % key.Length]);
                }
                return encrypted_message;

            }
           public string Caesar(int key) 
            {
                string sentence_lower = encrypted_sentence.ToLower();
                string sentence = RemoveDiacritics(sentence_lower);
                
                string encrypted_message = "";
                for (int i = 0; i < sentence.Length; ++i)
                {   
                    char letter = sentence[i];
                    if (!char.IsLetter(letter)) encrypted_message += letter;
                    else 
                    {
                        letter = (char)(letter + key);
                        if (letter > 'z')
                        {
                            letter = (char)(letter - 26);
                        }
                        else if (letter < 'a')
                        {
                            letter = (char)(letter + 26);
                        }
                        encrypted_message += letter;
                    }
                   
                    
                }
                return encrypted_message;
            }
            private string RemoveDiacritics(string s) 
            {                
                byte[] tempBytes;
                tempBytes = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(s);
                string asciiStr = System.Text.Encoding.UTF8.GetString(tempBytes);
                return asciiStr;
            }
        }
    }
    
}
