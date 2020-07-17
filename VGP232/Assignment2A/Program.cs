using System;
using System.Collections.Generic;
using System.IO;

// TODO: Fill in your name and student number.
// Assignment 1
// NAME: 
// STUDENT NUMBER: 

namespace Assignment2A
{
    class MainClass
    {
        public static void Main(string[] args)
        {
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

            // The column name to be used to determine which sort comparison function to use.
            string sortColumnName = string.Empty;

            // The results to be output to a file or to the console
            PokeDex results = new PokeDex();

            for (int i = 0; i < args.Length; i++)
            {
                // h or --help for help to output the instructions on how to use it
                if (args[i] == "-h" || args[i] == "--help")
                {
                    Console.WriteLine("-i <path> or --input <path> : loads the input file path specified (required)");
                    Console.WriteLine("-o <path> or --output <path> : saves result in the output file path specified (optional)");

                    // TODO: include help info for count
                    //"-c or --count : displays the number of entries in the input file (optional).";

                    // TODO: include help info for append
                    //"-a or --append : enables append mode when writing to an existing output file (optional)";

                    // TODO: include help info for sort
                    //"-s or --sort <column name> : outputs the results sorted by column name";

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
                            // This function returns a List<Pokemon> once the data is parsed.
                            results.Load(inputFile);
                        }
                    }
                }
                else if (args[i] == "-s" || args[i] == "--sort")
                {
                    // TODO: set the sortEnabled flag and see if the next argument is set for the column name
                    // TODO: set the sortColumnName string used for determining if there's another sort function.
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
                            // TODO: set the output file to the outputFile
                        }
                    }
                }
                else
                {
                    Console.WriteLine("The argument Arg[{0}] = [{1}] is invalid", i, args[i]);
                }
            }

            if (sortEnabled)
            {
                // TODO: add implementation to determine the column name to trigger a different sort.

                // Sorts the list based off of the Pokemon name.
                results.Sort(Pokemon.CompareByPokemonName);
            }

            if (results.Count > 0)
            {
                if (!string.IsNullOrEmpty(outputFile))
                {
                    results.Save(outputFile);
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

    }
}
