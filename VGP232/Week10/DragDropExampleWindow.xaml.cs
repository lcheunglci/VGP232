using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Week10
{
    /// <summary>
    /// Interaction logic for DragDropExampleWindow.xaml
    /// </summary>
    public partial class DragDropExampleWindow : Window
    {
        public DragDropExampleWindow()
        {
            InitializeComponent();
        }

        private void selection_Click(object sender, MouseButtonEventArgs e)
        {
            DataObject data = new DataObject(DataFormats.Bitmap, ((Image)e.Source).Source);
            DragDrop.DoDragDrop(
                (DependencyObject)e.Source, data, DragDropEffects.Copy);
        }

        private void selectionText_Click(object sender, MouseButtonEventArgs e)
        {
            DataObject data = new DataObject(DataFormats.Text, ((TextBlock)e.Source).Text);
            DragDrop.DoDragDrop(
                (DependencyObject)e.Source, data, DragDropEffects.Copy);
        }

        private void Image_Drop(object sender, DragEventArgs e)
        {
            Image droppedOnTo = e.Source as Image;
            droppedOnTo.Source = (ImageSource)e.Data.GetData(DataFormats.Bitmap);
        }

        private void Text_Drop(object sender, DragEventArgs e)
        {
            TextBlock droppedOnTo = e.Source as TextBlock;
            droppedOnTo.Text = (string)e.Data.GetData(DataFormats.Text);
        }
    }
}
