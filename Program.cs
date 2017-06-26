using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Written by Seth G. R. Herendeen.
// 
// This is a C# implementation of the Caesarean Cipher algorithm.
// It is not perfect.
// Note: uploading to github somehow messed up the formatting.
namespace CaesarCipher
{
	class Program
	{
		private const string ALPHABET = " ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		private  static string result = string.Empty;
		private static int offsetVal = 0;
		
		//Entry point
		static void Main(string[] args)
		{
			
			Console.WriteLine("1) encrypt");
			Console.WriteLine("2) decrypt");
			Console.WriteLine("3) superdecrypt");
			
			string inVal = Console.ReadLine();
			
			//If the input value is equal to one, we encrypt
			if (inVal == "1")
			{
				
				inVal = "";
				Console.Write("Input offset:"); // the offset of the cipher.
				//If you don't understand this part, read about the cipher
				inVal = Console.ReadLine();
				
				//Make sure the inValue is a valid integer
				if (int.TryParse(inVal, out offsetVal) == false)
				{
					Console.WriteLine("Invalid input");
				}
				else
				{
					inVal = "";
					Console.Write("Input string to be ciphered:");
					inVal = Console.ReadLine();

					Console.WriteLine(Encrypt(offsetVal, inVal));
				}


			}
			else if(inVal=="2")
			{
				inVal = "";
				Console.Write("Input offset:");
				inVal = Console.ReadLine();
				if (int.TryParse(inVal, out offsetVal) == false)
				{
					Console.WriteLine("Invalid input");
				}
				else
				{
					inVal = "";
					Console.Write("Input string to be unciphered:");
					inVal = Console.ReadLine();

					Console.WriteLine(Decrypt(offsetVal, inVal));
				}

			}
			else if(inVal=="3")
			{

				List<string> result = new List<string>();
				result = Decrypt(Console.ReadLine());
				for(int i = 0; i < result.Count; i++)
				{
					Console.WriteLine(result[i]);
				}
			}
			Console.ReadKey();
		}
		static string Encrypt(int _shiftVal, string _inVal)
		{
			string result = string.Empty;
			_inVal = _inVal.ToUpper();
			for (int i = 0; i < _inVal.Length; i++)
			{
				char replacementVal = _inVal[i];
				int index = ALPHABET.IndexOf(replacementVal);
				if (index >0)
				{
					int keyVal = (index + _shiftVal) % ALPHABET.Length;
                    			if(keyVal<0)
		    			{
                        			keyVal = ALPHABET.Length+keyVal;
                    			}
                    			replacementVal = ALPHABET[keyVal];
				}
				result += replacementVal;
			}

			return result;
		}
		// The method for decrypting a given string
		static string Decrypt(int _shiftVal, string _inVal)
		{
			string outVal = string.Empty;
			_inVal = _inVal.ToUpper();
           		 _inVal = _inVal.Replace(" ","");
			for(int i = 0; i < _inVal.Length; i++)
			{
				char replacementVal = _inVal[i];
				int index = ALPHABET.IndexOf(replacementVal);
                		int keyVal = ( index-_shiftVal) % ALPHABET.Length;
                		if(keyVal<0){
                			keyVal = ALPHABET.Length+keyVal;
                		}
				replacementVal = ALPHABET[keyVal];
				outVal += replacementVal;
			}

			return outVal;
		}
		
		// An overloaded version of Decrypt that only requires a string. It returns a list of strings.
		// You can call it the brute force method.
		static List<string> Decrypt(string _inVal)
		{
			List<string> outValList = new List<string>();
			//Alternate way of creating an empty string.
			string outVal = string.Empty;
			// Replace the space with no space.
            		_inVal = _inVal.Replace(" ","");
			_inVal = _inVal.ToUpper();
			for(int j = 0;j<ALPHABET.Length;j++)
			{
				for(int i = 0;i<_inVal.Length;i++)
				{
					char replaceVal = _inVal[i];
					int index = ALPHABET.IndexOf(replaceVal);
					// Create an integer to be the keyValue of index minus j remainder of ALPHABET LENGTH 
					//(27 because of the space in front)
					int keyVal = (index-j )% ALPHABET.Length;
					//If the keyvalue is less than zero
					if(keyVal<0)
					{	// the keyvalue is equal to 27 plus the keyvalue
						keyVal = ALPHABET.Length+keyVal;
					}
					// the replacement value becomes equal to the selected char
					replaceVal = ALPHABET[keyVal];
					
					outVal += replaceVal;
				}
				outVal += "\n";
			}

			outValList.Add(outVal);
			return outValList;
		}
	}
}
