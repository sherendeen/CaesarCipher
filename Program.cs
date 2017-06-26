using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Written by Seth G. R. Herendeen.
// 
// This is a C# implementation of the Caesarean Cipher algorithm.
// It is not perfect.
namespace CaesarCipher
{
	class Program
	{
		private const string ALPHABET = " ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		private  static string result = string.Empty;
		private static int offsetVal = 0;
		static void Main(string[] args)
		{
			Console.WriteLine("1) encrypt");
			Console.WriteLine("2) decrypt");
			Console.WriteLine("3) superdecrypt");
			string inVal = Console.ReadLine();
			if (inVal == "1")
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
                    if(keyVal<0){
                        keyVal = ALPHABET.Length+keyVal;
                    }
                    replacementVal = ALPHABET[keyVal];
				}
				result += replacementVal;
			}

			return result;
		}
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
		static List<string> Decrypt(string _inVal)
		{
			List<string> outValList = new List<string>();
			string outVal = string.Empty;
            _inVal = _inVal.Replace(" ","");
			_inVal = _inVal.ToUpper();
			for(int j = 0;j<ALPHABET.Length;j++){
				for(int i = 0;i<_inVal.Length;i++){
					char replaceVal = _inVal[i];
					int index = ALPHABET.IndexOf(replaceVal);
					int keyVal = (index-j )% ALPHABET.Length;
					if(keyVal<0){
						keyVal = ALPHABET.Length+keyVal;
					}
					replaceVal = ALPHABET[keyVal];
					outVal += replaceVal;
				}
				outVal += "\n";
			}

			outValList.Add (outVal);
			return outValList;
		}
	}
}