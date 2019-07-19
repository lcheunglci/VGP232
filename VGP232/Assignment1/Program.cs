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

            if (args.Length == 0)
            {
                bool requiredInput = true;
                bool saveResults = false;
                while (requiredInput)
                {
                    if (string.IsNullOrEmpty(inputFile))
                    {
                        Console.Write("Please enter the path to the input file to load: ");
                        inputFile = Console.ReadLine();
                    }

                    if (string.IsNullOrEmpty(inputFile))
                    {
                        continue;
                    }

                    Console.WriteLine("Do you want to save the results? (Y/N) ");
                    string choice = Console.ReadLine();
                    if (choice.ToUpper() == "Y")
                    {
                        saveResults = true;
                        Console.WriteLine("Please enter the output file path to save the results");
                        outputFile = Console.ReadLine();
                        if (string.IsNullOrEmpty(outputFile))
                        {
                            continue;
                        }
                    }

                    Console.WriteLine("Would you like to know how many entries are loaded? (Y/N)");
                    choice = Console.ReadLine();
                    if (choice.ToUpper() == "Y")
                    {
                        displayCount = true;
                    }

                    Console.WriteLine("Would you like to see the results sorted alphabetically? (Y/N)");
                    choice = Console.ReadLine();
                    if (choice.ToUpper() == "Y")
                    {
                        sortEnabled = true;
                    }
                    if (!string.IsNullOrEmpty(inputFile) &&
                        (!saveResults || saveResults && !string.IsNullOrEmpty(outputFile)))
                    {
                        requiredInput = false;
                    }
                }
            }

            #endregion

            #region Quiet Mode
            // Quiet Mode
            for (int i = 0; i < args.Length; i++)
            {
                // h or --help for help to output the instructions on how to use it

                if (args[i] == "-h" || args[i] == "--help")
                {
                    Console.WriteLine("-i <path> or --input <path> loads the input file path specified (required)");
                    Console.WriteLine("-o <path> or --output <path> saves result in the output file path specified (optional)");
                    // TODO: include help info for count
                    //"-c or --count - displays or saves the number of entries are in the text file (optional)";
                    Console.WriteLine("-c or --count - displays or saves the number of entries are in the text file (optional)");

                    // TODO: include help info for append
                    //"-a or --append for appending to an existing output file (optional)";
                    Console.WriteLine("-a or --append for appending to an existing output file (optional)");

                    // TODO: include help info for sort
                    //"-s or --sort - outputs the results sorted by name";
                    Console.WriteLine("-s or --sort - outputs the results sorted by name");

                    break;
                }
                else if (args[i] == "-i" || args[i] == "--input")
                {
                    if (args.Length > i + 1)
                    {
                        // validation to make sure we do have an argument after the flag
                        ++i;
                        inputFile = args[i];
                    }
                }
                else if (args[i] == "-s" || args[i] == "--sort")
                {
                    // TODO: set the sortEnabled flag
                    sortEnabled = true;
                }
                else if (args[i] == "-c" || args[i] == "--count")
                {
                    displayCount = true;
                }
                else if (args[i] == "-a" || args[i] == "--append")
                {
                    // TODO: set the appendToFile flag
                    appendToFile = true;
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
                            Console.WriteLine("No output file specified.");
                            // TODO: print No output file specified.
                        }
                        else
                        {
                            // TODO: set the output file to the filePath
                            outputFile = args[i];
                        }
                    }
                }
                else
                {
                    Console.WriteLine("The argument Arg[{0}] = [{1}] is invalid", i, args[i]);
                }
            }
            #endregion

            if (string.IsNullOrEmpty(inputFile))
            {
                // TODO: print no input file specified.
                Console.WriteLine("No input file specified.");
            }
            else if (!File.Exists(inputFile))
            {
                // TODO: print the file specified does not exist.
                Console.WriteLine(inputFile + " specified does not exist");
            }
            else
            {
                results = Parse(inputFile);
            }

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
                        if (displayCount)
                        {
                            writer.WriteLine("There are {0} entries", results.Count);
                        }

                        for (int i = 0; i < results.Count; i++)
                        {
                            writer.WriteLine(results[i]);
                        }
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

            //using (StreamReader reader = new StreamReader(fileName))
            //{
            //    // The header is the first line i.e.
            //    // Name,HP,Attack,Defense,MaxCP
            //    string header = reader.ReadLine();

            //    // The rest of the lines looks like the following:
            //    // Bulbasaur,128,118,111,1115
            //    while (reader.Peek() > 0)
            //    {
            //        string line = reader.ReadLine();
            //        string[] values = line.Split(',');
            //        Pokemon pok;
            //        if (Pokemon.TryParse(line, out pok))
            //        {
            //            Add()
            //        }
            //        Pokemon pokemon = new Pokemon {
            //            Name = values[0],
            //            HP = int.Parse(values[1]),
            //            Attack = int.Parse(values[2]),
            //            Defense = int.Parse(values[3]),
            //            MaxCP = int.Parse(values[4])
            //        };

            //        //pokemon.Name = values[0];
            //        //pokemon.HP = values[1];
            //        //pokemon.Attack = values[2];
            //        //pokemon.Defense = values[3];
            //        //pokemon.MaxCP = values[4];

            //        // Populate the properties of the pokemon

            //        // TODO: Add the pokemon to the list
            //        output.Add(pokemon);
            //    }
            //}

            return output;
        }
    }
}
