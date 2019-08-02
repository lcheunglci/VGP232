using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Week3Lib.Data;

namespace Week4
{
    /// <summary>
    /// Interaction logic for DigiEditWindow.xaml
    /// </summary>
    public partial class DigiEditWindow : Window
    {
        public Digimon SelectedDigimon { get; set; }

        public DigiEditWindow(Digimon digimon)
        {
            InitializeComponent();
            SelectedDigimon = digimon;

            txtName.Text = SelectedDigimon.Name;
            txtSpirit.Text = SelectedDigimon.Spirit.ToString();
            txtWisdom.Text = SelectedDigimon.Wisdom.ToString();
            txtStrength.Text = SelectedDigimon.Strength.ToString();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            SelectedDigimon.Name = txtName.Text;
            SelectedDigimon.Spirit = int.Parse(txtSpirit.Text);
            SelectedDigimon.Wisdom = int.Parse(txtWisdom.Text);
            SelectedDigimon.Strength = int.Parse(txtStrength.Text);
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
