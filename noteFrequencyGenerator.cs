//klutix~
//THIS CRYPTIC LOOKING CLASS WAS PURPOSEFULLY CREATED AS AN EDUCATIONAL CHALLENGE AS MY INTRO TO LABMDA STYLE EXPRESSIONS WITH C# (IN ADDITION TO THE ENCAPSULATING CHALLENGE). 
//THIS CLASS COULD HAVE BEEN WRITTEN MULTIPLE WAYS BUT MY PERSONAL CHALLENGE WAS TO USE ONLY "C# LAMBDA EXPRESSIONS."
//----------------------------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

namespace NotePlayerAndGraphChallenge
{
    class NoteFrequencyGenerator
    {
        //all the parts of this exprimental creation
        static Func<int, int>    OctaveFromKeyNo = (n) => (n>3) ? n > 15 ? (n-3) / 12 + ((n-3) % 12 != 0 ? 1 : 0):1:0;
        static Func<int, int>    GetNoReplace    = (n) => (n >= 15) ? GetNoReplace(n - 12) : (n > 12) ? GetNoReplace(n - 12):n;
        static Func<int, double> MakeNoteFreq    = (n) => Math.Pow(2.0, ((n - 49.0) / 12.0)) * 440.0;
        static Func<int, bool>   isSharpKey      = (n) => n == 2 || n == 5 || n == 7 || n == 10 || n == 12;
        static Func<int, string> NoteFromKeyNo   = (n) => Convert.ToString("0AABCCDDEFFGG"[GetNoReplace(n)]);       
        static Func<int, String> BuildFullSymbol = (n) => Convert.ToString(NoteFromKeyNo(n) + (isSharpKey(GetNoReplace(n)) ?"#":"") + OctaveFromKeyNo(n));
       
        public static Func<int,int,Dictionary<String, double>> GenDictForRangeOfKeys = (st, ed) => 
         {             
             Dictionary<String, double> dct = new Dictionary<String, double>();
             Enumerable.Range(st, ed).ToList().ForEach(x => dct[BuildFullSymbol(x)] = MakeNoteFreq(x));
             return dct;
         };       
    }}
