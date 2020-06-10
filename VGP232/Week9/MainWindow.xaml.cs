using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Week9.Model;

namespace Week9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new Weapon() { Name = "Axe", Power = 10 };

            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("zh");
            nameText.Text = Properties.Resources.greetings;
        }

        private void selectionClicked(object sender, MouseButtonEventArgs e)
        {
            DataObject data = new DataObject(DataFormats.Bitmap, ((Image)e.Source).Source);
            DragDrop.DoDragDrop(
                (DependencyObject)e.Source, data, DragDropEffects.Copy);
        }

        private void droppedImage(object sender, DragEventArgs e)
        {
            Image droppedOnTo = e.Source as Image;
            droppedOnTo.Source = (ImageSource)e.Data.GetData(DataFormats.Bitmap);
        }
    }

    //public class MyColorConverter : MarkupExtension
    //{
    //    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    //    {
    //        if (destinationType == typeof(Color) && context.GetType() == typeof(bool))
    //        {
    //            return true;
    //        }

    //        return false;
    //    }

    //    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    //    {
    //        if ((bool)value == true)
    //        {
    //            return Brushes.Black;
    //        }
    //        else
    //        {
    //            return Brushes.Red;
    //        }
    //    }

    //}
}
