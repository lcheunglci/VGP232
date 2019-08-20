using System;
using System.Windows;
using PokemonLib;
using PokemonLib.Service;
using PokemonLib.Models;

namespace PokeDexEditor
{
    /// <summary>
    ///     Interaction logic for AddEditPokemonWindow.xaml
    /// </summary>
    public partial class AddEditPokemonWindow : Window
    {
        private readonly PokemonXmlProvider provider;
        private readonly bool isEditing;
        private Pokemon pokemon;

        public AddEditPokemonWindow(PokemonXmlProvider provider)
        {
            this.provider = provider;
            InitializeComponent();
        }

        public AddEditPokemonWindow(Pokemon pokemonForEditing, PokemonXmlProvider provider)
        {
            this.provider = provider;
            pokemon = pokemonForEditing;
            isEditing = true;

            InitializeComponent();

            InitUITextBoxes(pokemonForEditing);
        }

        private void InitUITextBoxes(Pokemon pokemonForEditing)
        {
            PName.Text = pokemonForEditing.Name;
            HP.Text = pokemonForEditing.HP.ToString();
            Attack.Text = pokemonForEditing.Attack.ToString();
            Defense.Text = pokemonForEditing.Defense.ToString();
            MaxCP.Text = pokemonForEditing.MaxCP.ToString();
            MType.Text = pokemonForEditing.MType.ToString();
        }

        private void Confirm_OnClick(object sender, RoutedEventArgs e)
        {
            if (!isEditing)
            {
                pokemon = new Pokemon();
            }
            pokemon.Name = PName.Text;
            pokemon.HP = int.Parse(HP.Text);
            pokemon.Attack = int.Parse(Attack.Text);
            pokemon.Defense = int.Parse(Defense.Text);
            pokemon.MaxCP = int.Parse(MaxCP.Text);
            pokemon.MType = (Pokemon.MonsterType)Enum.Parse(typeof(Pokemon.MonsterType),MType.Text);

            if (isEditing)
            {
                provider.Edit(pokemon);
            }
            else
            {
                provider.Add(pokemon);
            }
            provider.SaveChanges();

            Close();
        }

        private void Decline_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}