using PokemonAPI.Controller;
using PokemonAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PokemonAPI.View
{
    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PokemonsController pokemonController = new PokemonsController();

            List<Pokemons> pokemonList = pokemonController.GetPokemons();

            repPokemons.DataSource = pokemonList;
            repPokemons.DataBind();
        }
    }
}