using System;
using System.Windows;
using PokemonLib;
using PokemonLib.Models;
using PokemonLib.Service;

namespace PokeDexEditor
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PokemonXmlProvider PokemonXmlProvider;

        public MainWindow()
        {
            InitializeComponent();
        }

        private bool ListHasSelectedItems
        {
            get { return PokeDex.SelectedItems != null && PokeDex.SelectedItems.Count > 0; }
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            ReloadPokeDex();
        }

        private void ExitFromApp_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void AddPokemon_OnClick(object sender, RoutedEventArgs e)
        {
            var addPokemon = new AddEditPokemonWindow(PokemonXmlProvider);
            addPokemon.ShowDialog();

            ReloadPokeDex();
        }

        private void ReloadPokeDex()
        {
            PokeDex.Items.Clear();

            PokemonXmlProvider = new PokemonXmlProvider("PokeDexRepo.xml");
            var students = PokemonXmlProvider.GetAll();

            foreach (var student in students)
            {
                PokeDex.Items.Add(student);
            }
        }

        private void EditPokemon_OnClick(object sender, RoutedEventArgs e)
        {
            if (ListHasSelectedItems)
            {
                var pokemon = PokeDex.SelectedItems[0] as Pokemon;
                var addPokemon = new AddEditPokemonWindow(pokemon, PokemonXmlProvider);
                addPokemon.ShowDialog();

                ReloadPokeDex();
            }
        }

        private void RemovePokemon_OnClick(object sender, RoutedEventArgs e)
        {
            if (ListHasSelectedItems)
            {
                var item = PokeDex.SelectedItems?[0] as Pokemon;
                PokemonXmlProvider.Remove(item.Id);
                RemoveFromListBox(item);
            }
        }

        private void RemoveFromListBox(Pokemon item)
        {
            PokeDex.Items.Remove(item);
        }

        private void SaveChanges_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                PokemonXmlProvider.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}