using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PokeAPIDEX;

namespace PokedexApiClient
{
    class Program
    {
        static async Task Main(string[] args)
        {

            HttpClient client = new HttpClient();
            string baseUrl = "https://pokeapi.co/api/v2/";
            bool stopper = true;

            while (stopper == true)
            {

                Random random = new Random();
                int test = random.Next(0, 1025);

                HttpResponseMessage response = await client.GetAsync($"{baseUrl}pokemon/{test}/");
                if (response.IsSuccessStatusCode)
                {

                    Console.WriteLine("Which would you like to Test:");
                    Console.WriteLine("You can type hint for a small hint, but you can only get 1");
                    Console.WriteLine("1. ID");
                    Console.WriteLine("2. Typing");
                    Console.WriteLine("3. Abilities");
                    string userInt = Console.ReadLine();

                    string json = await response.Content.ReadAsStringAsync();
                    Pokemon pokemon = JsonConvert.DeserializeObject<Pokemon>(json);
                    #region switch
                    switch (userInt)
                    {
                        case "1":
                            Console.Write($"What is the Pokemon with the ID: {pokemon.ID}\n---");
                            string userChoiceH = Console.ReadLine();

                            if (userChoiceH == "hint")
                            {
                                Console.WriteLine($"{pokemon.Name[0]}");
                            }

                            Console.Write($"What is the Pokemon with the ID: {pokemon.ID}\n---");
                            string userChoice = Console.ReadLine();

                            if (userChoice == pokemon.Name)
                            {
                                Console.WriteLine("\nCongrats! you were right!");

                            }

                            else
                            {
                                Console.WriteLine($"you are wrong, it was: {pokemon.Name}\n");

                            }
                            break;

                        case "2":

                            Console.Write($" What is the Pokemon with the Typing: \n");
                            foreach (var type in pokemon.Types)
                            {
                                Console.Write($"-{type.Type.Name}\n");
                            }
                            Console.Write("---");
                            string userChoiceH2 = Console.ReadLine();

                            if (userChoiceH2 == "hint")
                            {
                                Console.WriteLine($"{pokemon.Name[0]}");
                            }

                            Console.Write($" What is the Pokemon with the Typing: \n");
                            foreach (var type in pokemon.Types)
                            {
                                Console.Write($"-{type.Type.Name}\n");
                            }

                            Console.Write("---");
                            string userChoice2 = Console.ReadLine();

                            if (userChoice2 == pokemon.Name)
                            {
                                Console.WriteLine("\nCongrats! you were right!");

                            }

                            else
                            {
                                Console.WriteLine($"you are wrong, it was: {pokemon.Name}\n");

                            }
                            break;

                        case "3":
                            Console.Write($" What is the Pokemon with the Abilities: \n");
                            foreach (var ability in pokemon.Abilities)
                            {
                                Console.Write($"-{ability.Ability.Name}\n");
                            }
                            Console.Write("---");
                            string userChoiceH3 = Console.ReadLine();

                            if (userChoiceH3 == "hint")
                            {
                                Console.WriteLine($"{pokemon.Name[0]}");
                            }

                            Console.Write($" What is the Pokemon with the abilities: \n");
                            foreach (var ability in pokemon.Abilities)
                            {
                                Console.Write($"-{ability.Ability.Name}\n");
                            }

                            Console.Write("---");
                            string userChoice3 = Console.ReadLine();

                            if (userChoice3 == pokemon.Name)
                            {
                                Console.WriteLine("\nCongrats! you were right!");

                            }

                            else
                            {
                                Console.WriteLine($"\nyou are wrong, it was: {pokemon.Name}\n");

                            }
                            break;
                            default:
                            Console.WriteLine("Please type a number 1-3\n");
                            break;
                            #endregion

                            Console.Write(" Want to try again?\n y to continue\n n to stop\n-");
                            string breaker = Console.ReadLine();

                            if (breaker == "n")
                            {
                                stopper = false;
                            }


                            else
                            {
                                Console.WriteLine($"Failed to retrieve Pokemon details. Status code: {response.StatusCode}");
                            }
                    }
                }
            }
        }
    }
}
