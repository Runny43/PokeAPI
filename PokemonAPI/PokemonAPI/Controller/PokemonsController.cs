using Newtonsoft.Json;
using PokemonAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Web;

namespace PokemonAPI.Controller
{
    public class PokemonsController
    {
        public List<Pokemons> GetPokemons()
        {
            List<Pokemons> pokeList = new List<Pokemons>();
            List<string> pokemones = new List<string>()
            {
                "bulbasaur", "ivysaur", "venusaur", 
                "charmander", "charmeleon",
                "charizard", "squirtle", "wartortle", "blastoise", "caterpie",
                "metapod", "butterfree", "weedle", "kakuna", "beedrill",
                "pidgey", "pidgeotto", "pidgeot", "rattata", "raticate"
            };
            foreach (string pokemonNames in pokemones)
            {
                string dato = pokemonNames;
                
                string url = "https://pokeapi.co/api/v2/pokemon/";
                string urlimg = "https://img.pokemondb.net/artwork/large/"+dato+".jpg";


                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "GET";
                request.ContentType = "application/json";


                try
                {
                    HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                    
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string jsonResponse = reader.ReadToEnd();
                        Pokemons pokemon = JsonConvert.DeserializeObject<Pokemons>(jsonResponse);
                        pokemon.name = pokemonNames;
                        pokemon.photo = urlimg; 
                        pokeList.Add(pokemon);

                    }
                }
                catch
                {
                    return null;
                }
            }
            return pokeList;
        }
    }
}

