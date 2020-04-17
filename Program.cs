using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace TwistProjekt
{
    class Program
    {
        static void Main(string[] args)
        {
            String eingabe = "";
            String twisted = "";
            String untwist = "";
            String untwisted = "";
            Console.WriteLine("-= Twister =-");

            Console.WriteLine("Bitte den Twister Modus wählen:\n0: Wort 1: Satz");
            int mode = Convert.ToInt32(Console.ReadLine());

            if(mode == 0){

                Console.WriteLine("Bitte das Wort eingeben welches getwistet werden soll:");
                eingabe = Console.ReadLine();
                twisted = leTwister(eingabe);
                untwist = unTwist(twisted);


                Console.WriteLine("\n-|- Eingegebenes Wort: {0,-10} | Getwistetes Word: {1:-10} | Enttwistetes Word: {2:-10} -|-", eingabe, twisted, untwist);

            } else if(mode == 1){

                Console.WriteLine("\nBitte den Satz eingeben welcher getwistet werden soll:");
                eingabe = Console.ReadLine();

                Console.WriteLine("\nGetwisteter Satz:");
                String[] twistedSatz = leTwisterSatz(eingabe.Split(" ", StringSplitOptions.None));
                foreach(string wort in twistedSatz){
                    twisted = twisted+wort+" ";
                }
                Console.WriteLine(twisted); 

                Console.WriteLine("\nEnttwisteter Satz:");
                String[] untwistedSatz = unTwistSatz(twisted.Split(" ", StringSplitOptions.None));
                foreach(string wort in untwistedSatz){
                    untwisted = untwisted+wort+" ";
                }
                Console.WriteLine(untwisted); 

            }
            Console.WriteLine("\nFehler gefunden? Sie können uns dabei helfen den Fehler zu beheben unter:\nhttps://github.com/Erroru61/Twister");
            Console.ReadKey();
            
        }

        static String leTwister(String twist)
        {
            if (twist.Length <= 3)
            {
                return twist;
            } else
            {
                Char[] twistChar = twist.ToCharArray();
                Char[] shortTwist = new char[twistChar.Length-2];
                int randomNumber;
                String tsiwt = "";
                tsiwt += twistChar[0];
                Random rng = new Random();

                //Neues Char array füllen mit allen Zeichen außer dem 1. und dem letzten.
                for (int i=1; i < twistChar.Length-1; i++)
                {
                    shortTwist[i - 1] = twistChar[i];
                }

                //Das gekürzte Array vermischen und an den String hinzufügen
                for (int i = shortTwist.Length; i >= 1; i--)
                {
                    //Zufällige Zahl die im Bereich der Arrays liegt(Index)
                    randomNumber = rng.Next(0, i);
                    tsiwt += shortTwist[randomNumber];
                    shortTwist[randomNumber] = shortTwist[i - 1];
                }

                tsiwt += twistChar[twistChar.Length-1];
                return tsiwt;
            }
        }

        static String[] leTwisterSatz(String[] twisterSatz)
        {
            int index = 0;
            foreach(string twist in twisterSatz){                
                if (twist.Length <= 3)
                {
                    twisterSatz[index] = twist;
                    index++;
                } else
                {
                    Char[] twistChar = twist.ToCharArray();
                    Char[] shortTwist = new char[twistChar.Length-2];
                    int randomNumber;
                    String tsiwt = "";
                    tsiwt += twistChar[0];
                    Random rng = new Random();

                    //Neues Char array füllen mit allen Zeichen außer dem 1. und dem letzten.
                    for (int i=1; i < twistChar.Length-1; i++)
                    {
                        shortTwist[i - 1] = twistChar[i];
                    }

                    //Das gekürzte Array vermischen und an den String hinzufügen
                    for (int i = shortTwist.Length; i >= 1; i--)
                    {
                        //Zufällige Zahl die im Bereich der Arrays liegt(Index)
                        randomNumber = rng.Next(0, i);
                        tsiwt += shortTwist[randomNumber];
                        shortTwist[randomNumber] = shortTwist[i - 1];
                    }

                    tsiwt += twistChar[twistChar.Length-1];
                    twisterSatz[index] = tsiwt;
                    index++;
                }
            }
            return twisterSatz;
        }

        static String unTwist(String twisted)
        {
            if (twisted.Length <= 3)
            {
                return twisted;
            }
            else
            {
                Char[] twistedArray = twisted.ToCharArray();
                Char[] word;
                int highscore = 0;
                int count = 0;
                String result = "Fail";
                var lines = File.ReadAllLines("woerterliste.txt");

                foreach (var line in lines)
                {
                    word = line.ToCharArray();
                    if(twistedArray[0]== word[0]             &&                twistedArray[twistedArray.Length-1] == word[word.Length - 1]                 &&               twistedArray.Length == word.Length)
                    {
                        // Console.WriteLine(word);
                        count = 0;

                        for(int i=1;i<= twistedArray.Length - 1; i++)
                        {
                            char charToCount = twistedArray[i];
                            foreach (char c in word)
                            {
                                    // Console.WriteLine("C ist:" + c + "Andere ist: " + charToCount);

                                if (c == charToCount)
                                {
                                    // Console.WriteLine(c);
                                    // Console.WriteLine(charToCount);
                                    count++;
                                    // Console.WriteLine(count);
                                }
                            }
                        }
                    }
                    if(count > highscore)
                    {
                        // Console.WriteLine(count);
                        // Console.WriteLine(count);
                        highscore = count;
                        result = line;
                    }
                }




                return result;
            }
        }

        static String[] unTwistSatz(String[] twistedSatz)
        {
            int index = 0;
            foreach(string twisted in twistedSatz){   
            if (twisted.Length <= 3){
                    twistedSatz[index] = twisted;
                    index++;         
            }
            else
            {
                Char[] twistedArray = twisted.ToCharArray();
                Char[] word;
                int highscore = 0;
                int count = 0;
                String result = "Fail";
                var lines = File.ReadAllLines("woerterliste.txt");

                foreach (var line in lines){
                        word = line.ToCharArray();
                        if(twistedArray[0]== word[0]             &&                twistedArray[twistedArray.Length-1] == word[word.Length - 1]                 &&               twistedArray.Length == word.Length)
                        {
                            // Console.WriteLine(word);
                            count = 0;

                            for(int i=1;i<= twistedArray.Length - 1; i++)
                            {
                                char charToCount = twistedArray[i];
                                foreach (char c in word)
                                {
                                        // Console.WriteLine("C ist:" + c + "Andere ist: " + charToCount);

                                    if (c == charToCount)
                                    {
                                        // Console.WriteLine(c);
                                        // Console.WriteLine(charToCount);
                                        count++;
                                        // Console.WriteLine(count);
                                    }
                                }
                            }
                        }
                        if(count > highscore)
                        {
                            // Console.WriteLine(count);
                            // Console.WriteLine(count);
                            highscore = count;
                            result = line;
                        }
                    }




                    
                    twistedSatz[index] = result;
                    index++;
                }
            }
            return twistedSatz;
        }
    }   


}
