using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonEvolution
{
    class Program
    {
        static void Main(string[] args)
        {
            var pokemonsDict = new Dictionary<string, Pokemon>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "wubbalubbadubdub")
                {
                    PrintAllPokemons(pokemonsDict);
                    return;
                }
                if (pokemonsDict.ContainsKey(input))
                {
                    PrintOnePokemon(input, pokemonsDict);
                    continue;
                }
                string[] tokens = input.Trim().Split(new string[] { " -> " }
                , StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (tokens.Length == 3)
                {
                    string pokeName = tokens[0];
                    string pokeType = tokens[1];
                    long pokeIndex = long.Parse(tokens[2]);
                    if (!pokemonsDict.ContainsKey(tokens[0]))
                    {
                        pokemonsDict.Add(pokeName, new Pokemon());
                        pokemonsDict[pokeName].Type = new List<string>();
                        pokemonsDict[pokeName].Type.Add(pokeType);
                        pokemonsDict[pokeName].Index = new List<long>();
                        pokemonsDict[pokeName].Index.Add(pokeIndex);
                    }
                    else 
                    {
                        
                        pokemonsDict[pokeName].Type.Add(pokeType);
                        
                        pokemonsDict[pokeName].Index.Add(pokeIndex);
                    }
                }
            }
        }

        private static void PrintOnePokemon(string input, Dictionary<string, Pokemon> pokemonsDict)
        {
            foreach (var item in pokemonsDict)
            {
                if (item.Key == input)
                {
                    Console.WriteLine("# " + item.Key);
                    int count = 0;
                    foreach (var type in item.Value.Type)
                    {
                        Console.WriteLine(type + " <-> " + item.Value.Index[count]);
                        count++;
                    }
                }
                
            }
        }

        private static void PrintAllPokemons(Dictionary<string, Pokemon> pokemonsDict)
        {
            foreach (var item in pokemonsDict)
            {
                Console.WriteLine("# " + item.Key);
                
                foreach (var index in item.Value.Index.OrderByDescending(x => x))
                {
                    int findIndex = item.Value.Index.FindIndex(a => a == index);
                    Console.WriteLine(item.Value.Type[findIndex] + " <-> " + index);
                }
            }
        }
    }
    public class Pokemon
    {
        public List<string> Type { get; set; }
        public List<long> Index { get; set; }
    }
}
