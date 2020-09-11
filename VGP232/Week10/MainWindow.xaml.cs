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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Week10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Image_Drop(object sender, DragEventArgs e)
        {
            Image target = sender as Image;
            if (target != null)
            {
                ImageSource imgSrc = e.Data.GetData(typeof(ImageSource)) as ImageSource;
                target.Source = imgSrc;
            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image image = sender as Image;
            if (image != null)
            {
                tbOutput.Text = image.Source.ToString();

                DataObject dataObject = new DataObject(typeof(ImageSource), image.Source);
                DragDrop.DoDragDrop(image, dataObject, DragDropEffects.Move);
            }
        }

        private void ListBoxItem_Drop(object sender, DragEventArgs e)
        {
            ListBoxItem item = sender as ListBoxItem;
            if (item != null)
            {
                ListBoxItem source = e.Data.GetData(typeof(ListBoxItem)) as ListBoxItem;
                if (source == item)
                {
                    return;
                }

                // There's a bug here.

                //int source = lbItems.SelectedIndex;
                int targetIndex = lbItems.Items.IndexOf(item);
                ListBoxItem targetItem = lbItems.Items.GetItemAt(targetIndex) as ListBoxItem;
                // targetItem.Content = source.Content;

                //var temp = lbItems.Items[targetIndex];
                //lbItems.Items[targetIndex] = lbItems.SelectedItem;
                // lbItems.SelectedItem = temp;
            }
        }

        private void ListBoxItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem item = sender as ListBoxItem;
            if (item != null)
            {
                DataObject dataObject = new DataObject(typeof(ListBoxItem), item);
                DragDrop.DoDragDrop(item, dataObject, DragDropEffects.Move);
            }
        }
    }
}
