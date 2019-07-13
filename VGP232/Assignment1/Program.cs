using System;
using System.Collections.Generic;
using System.IO;


// Assignment 1
// NAME: 
// STUDENT NUMBER: 

namespace Assignment1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            #region Variables and Flags
            // Variables and flags

            // The path to the input file to load.
            string inputFile = string.Empty;

            // The path of the output file to save.
            string outputFile = string.Empty;

            // The flag to determine if we overwrite the output file or append to it.
            bool appendToFile = false;

            // The flag to determine if we need to display the number of entries
            bool displayCount = false;

            // The flag to determine if we need to sort the results via name.
            bool sortEnabled = false;
            
            // The results to be output to a file or to the console
            List<Pokemon> results = new List<Pokemon>();

            #endregion

            // TODO: check if there is more than 1 argument if 0 arguments, then run it in a while loop
            // and ask the user questions to fil in the variables above.

            #region Interactive Mode
            // Interactive mode
            // TODO: prompt user for the input to populate the parameters
            #endregion

            #region Scripted Mode
            // Scripted Mode
            for (int i = 0; i < args.Length; i++)
            {
                // h or --help for help to output the instructions on how to use it

                if (args[i] == "-h" || args[i] == "--help")
                {
                    Console.WriteLine("-i <path> or --input <path> loads the input file path specified (required)");
                    Console.WriteLine("-o <path> or --output <path> saves result in the output file path specified (optional)");
                    
                    // TODO: include help info for count
                    //"-c or --count - displays or saves the number of entries are in the text file (optional)";
                    
                    // TODO: include help info for append
                    //"-a or --append for appending to an existing output file (optional)";

                    // TODO: include help info for sort
                    //"-s or --sort - outputs the results sorted by name";

                    break;
                }
                else if (args[i] == "-i" || args[i] == "--input")
                {
                    if (args.Length > i + 1)
                    {
                        // validation to make sure we do have an argument after the flag
                        ++i;
                        inputFile = args[i];

                        if (string.IsNullOrEmpty(inputFile))
                        {
                            // TODO: print no input file specified.
                        }
                        else if (!File.Exists(inputFile))
                        {
                            // TODO: print the file specified does not exist.
                        }
                        else
                        {
                            results = Parse(inputFile);
                        }
                    }
                }
                else if (args[i] == "-s" || args[i] == "--sort")
                {
                    // TODO: set the sortEnabled flag
                }
                else if (args[i] == "-c" || args[i] == "--count")
                {
                    displayCount = true;
                }
                else if (args[i] == "-a" || args[i] == "--append")
                {
                    // TODO: set the appendToFile flag
                }
                else if (args[i] == "-o" || args[i] == "--output")
                {
                    // validation to make sure we do have an argument after the flag
                    if (args.Length > i + 1)
                    {
                        // increment the index.
                        ++i;
                        string filePath = args[i];
                        if (string.IsNullOrEmpty(filePath))
                        {
                            // TODO: print No output file specified.
                        }
                        else
                        {
                            // TODO: set the output file to the filePath
                        }
                    }
                }
                else
                {
                    Console.WriteLine("The argument Arg[{0}] = [{1}] is invalid", i, args[i]);
                }
            }
            #endregion

            if (sortEnabled)
            {
                // Sorts the list based off of the Pokemon name.
                results.Sort(Pokemon.CompareByPokemonName);
            }

            if (results.Count > 0)
            {
                if (!string.IsNullOrEmpty(outputFile))
                {
                    FileStream fs;

                    if (appendToFile && File.Exists((outputFile)))
                    {
                        fs = File.Open(outputFile, FileMode.Append);
                    }
                    else
                    {
                        fs = File.Open(outputFile, FileMode.Create);
                    }

                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        // TODO: use the writer to output the results.  Hint: use writer.WriteLine
                    }
                }
                else
                {
                    if (displayCount)
                    {
                        Console.WriteLine("There are {0} entries", results.Count);
                    }

                    for (int i = 0; i < results.Count; i++)
                    {
                        Console.WriteLine(results[i]);
                    }
                }
            }

            Console.WriteLine("Done!");
        }

        /// <summary>
        /// Reads the file and line by line parses the data into a List of Pokemons
        /// </summary>
        /// <param name="fileName">The path to the file</param>
        /// <returns>The list of pokemons</returns>
        public static List<Pokemon> Parse(string fileName)
        {
            // TODO: implement the streamreader that reads the file and appends each line to the list
            // note that the result that you get from using read is a string, and needs to be parsed 
            // to an int for certain fields i.e. HP, Attack, etc.
            // i.e. int.Parse() and if the results cannot be parsed it will throw an exception
            // or can use int.TryParse() 

            // streamreader https://msdn.microsoft.com/en-us/library/system.io.streamreader(v=vs.110).aspx
            // Use string split https://msdn.microsoft.com/en-us/library/system.string.split(v=vs.110).aspx

            List<Pokemon> output = new List<Pokemon>();

            using (StreamReader reader = new StreamReader(fileName))
            {
                // The header is the first line i.e.
                // Name,HP,Attack,Defense,MaxCP
                string header = reader.ReadLine();

                // The rest of the lines looks like the following:
                // Bulbasaur,128,118,111,1115
                while (reader.Peek() > 0)
                {
                    string line = reader.ReadLine();
                    // string[] values = line.Split(',');
                    Pokemon pokemon = new Pokemon();
                    // Populate the properties of the pokemon

                    // TODO: Add the pokemon to the list
                }
            }

            return output;
        }
    }
}
