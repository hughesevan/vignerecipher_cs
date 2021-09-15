using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cipher
{
    class Vigenere
    {
        public string Encrypt(string key, string plaintext) // Encrypts the Plain Text
        {
           
            string ciphertext = "";
            for (int i = 0; i < plaintext.Length; i++)
            {
                int temp = ((int)plaintext[i] + (int)key[i]) % 26;
                temp += (int)'A';
                ciphertext += (char)temp;
            }

            return ciphertext;
        }
        public string Decrypt(string key, string ciphertext) // Decrypts the Cipher Text
        {
            string decrypttext = "";
            for (int i = 0; i < ciphertext.Length; i++)
            {
                int temp = ((int)ciphertext[i] - (int)key[i] + 26) % 26;
                temp += (int)'A';
                decrypttext += (char)temp;

            }
            return decrypttext;
        }
        public string GetKey(string key, string plaintext) // Adjusts Key to be the same lenght as the string
        {
            if (key.Length == plaintext.Length)
            {
                return key;
            }
            else
            {
                int keylength = key.Length;
                for (int i = 0; i < (plaintext.Length-keylength); i++)
                {
                    key += key[i];
                }
                return key;
            }
        }
        public bool GetChoice()
        {
            Console.Write("Do you want to 1). Encode or 2). Decode?: ");
            string choice = Console.ReadLine();
            choice = choice.ToLower();
            bool encode = false;
            while (true)
            {
                if (choice == "1" || choice == "2" || choice == "encode" || choice == "decode")
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please Enter a Valid Input. ");
                    Console.Write("Do you want to 1). Encode or 2). Decode?: ");
                    choice = Console.ReadLine();
                }
            }
            switch (choice)
            {
                case ("1"):
                    encode = true;
                    break;
                case ("encode"):
                    encode = true;
                    break;
                case ("2"):
                    encode = false;
                    break;
                case ("decode"):
                    encode = false;
                    break;
            }
            
            return encode;
        }
    }
    class Program
    {
        static void Main()
        {

            Vigenere vin = new Vigenere();
            
            bool encode = vin.GetChoice();
            string key;
            string keylong;
            switch (encode)
            {
                case (true):
                    Console.Write("Please Enter your Plain Text: ");
                    string plaintext = Console.ReadLine().ToUpper();
                    plaintext = plaintext.Replace(" ", "");

                    Console.Write("Please Enter your Key: ");
                    key = Console.ReadLine().ToUpper();
                    key = key.Replace(" ", "");
                    keylong = vin.GetKey(key, plaintext);

                    Console.WriteLine("Plain Text: " + plaintext);
                    Console.WriteLine("Key: " + key);
                    Console.WriteLine("Cipher Text: " + vin.Encrypt(keylong, plaintext));
                    break;
                case (false):
                    Console.Write("Please Enter your Cipher Text: ");
                    string ciphertext = Console.ReadLine().ToUpper();
                    ciphertext = ciphertext.Replace(" ", "");

                    Console.Write("Please Enter your Key: ");
                    key = Console.ReadLine().ToUpper();
                    key = key.Replace(" ", "");
                    keylong = vin.GetKey(key, ciphertext);

                    Console.WriteLine("Cipher Text: " + ciphertext);
                    Console.WriteLine("Key: " + key);
                    Console.WriteLine("Deciphered Text: " + vin.Decrypt(keylong, ciphertext));
                    break;
            }
            
            Console.ReadLine();
        }
    }
}


/*

for(int i = 0; i < 5; i++){}
for(loop variable decleration; condition; iterator){}

if (1 == 1)
{

}
else if (2 == 2)
{
}
else
{
}


switch(variable){

    case (condition, can only be 1 variable not a conditional like if):
        code
    case (ditto):
        code
    default:
        code to be run if other conditions not met

}

 */
