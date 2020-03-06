using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Week7_canvas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public enum CharacterType { female, male, zombie };
        public MainWindow()
        {
            InitializeComponent();
            cbHead.ItemsSource = Enum.GetNames(typeof(CharacterType));
            cbBody.ItemsSource = Enum.GetNames(typeof(CharacterType));
            cbArms.ItemsSource = Enum.GetNames(typeof(CharacterType));
            cbLegs.ItemsSource = Enum.GetNames(typeof(CharacterType));
        }




        private void SaveButtonPressed(object sender, RoutedEventArgs e)
        {
            RenderTargetBitmap rtb = new RenderTargetBitmap(
                (int)canvasCharacter.RenderSize.Width,
                (int)canvasCharacter.RenderSize.Height,
                96d,
                96d,
                System.Windows.Media.PixelFormats.Default);

            rtb.Render(canvasCharacter);

            BitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(rtb));

            using (var fs = new FileStream("character.png", FileMode.Create))
            {
                encoder.Save(fs);
            }

            MessageBox.Show("Saved.");
        }

        private void SelectedItem(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                if (cbHead == comboBox)
                {
                    string newPath = comboBox.SelectedValue.ToString() + "\\" + "head.png";
                    imgHead.Source = new BitmapImage(new Uri(newPath, UriKind.Relative));
                }
                else if (cbArms == comboBox)
                {
                    string newPath = comboBox.SelectedValue.ToString() + "\\" + "arm.png";
                    imgLeftArm.Source = new BitmapImage(new Uri(newPath, UriKind.Relative));
                    imgRightArm.Source = new BitmapImage(new Uri(newPath, UriKind.Relative));
                }
                else if (cbBody == comboBox)
                {
                    string newPath = comboBox.SelectedValue.ToString() + "\\" + "body.png";
                    imgBody.Source = new BitmapImage(new Uri(newPath, UriKind.Relative));
                }
            }
        }

        int selectedLanguageIndex = 0;
        string[] locales = { "en-US", "fr", "zh", "jp" };

        private void ChangeLocale(object sender, RoutedEventArgs e)
        {
            selectedLanguageIndex = (selectedLanguageIndex + 1) % locales.Length;

            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(locales[selectedLanguageIndex]);
            GreetingsTxt.Text = strings.Hello;
        }
    }
}
