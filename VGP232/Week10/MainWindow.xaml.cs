using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using Week10.Model;

namespace Week10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ImageSource mSelectedBrush;
        private int mBrushIndex;
        private List<Skill> mSkills = new List<Skill>();
        public MainWindow()
        {
            InitializeComponent();
            List <Image> images = new List<Image>();

            string number;
            for (int i = 0; i < 65; i++)
            {
                number = string.Format("{0:000}", i + 1);
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri("Tiles/platformPack_tile" + number + ".png", UriKind.Relative);
                bitmap.EndInit();
                images.Add(new Image() { Source = bitmap });
            }

            brushes.ItemsSource = images;
            UpdateGrid();

            lbSkills.ItemsSource = mSkills;
        }

        private void UpdateGrid()
        {
            if (mapGrid == null)
                return;

            mapGrid.Children.Clear();
            int cellCount = mapGrid.Columns * mapGrid.Rows;
            for (int i = 0; i < cellCount; i++)
            {
                Border border = new Border();
                border.Background = Brushes.Wheat;
                border.BorderThickness = new Thickness(1);
                border.MouseDown += Border_MouseLeftButtonDown;
                TextBlock text = new TextBlock();
                text.Visibility = Visibility.Hidden;
                text.Text = "0";
                border.Child = text;
                mapGrid.Children.Add(border);
            }
        }

        private void menuNewClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("New clicked");
        }

        private void menuExitClick(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }

        private void updateBrush(object sender, SelectionChangedEventArgs e)
        {
            ListBox box = sender as ListBox;
            if (box != null)
            {
                Image selectedImage = box.SelectedItem as Image;
                if (selectedImage != null)
                {
                    mSelectedBrush = selectedImage.Source;
                    mBrushIndex = box.SelectedIndex;
                }
            }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Border border = sender as Border;
            if (border != null)
            {
                border.Background = new ImageBrush(mSelectedBrush);
                TextBlock text = border.Child as TextBlock;
                text.Text = mBrushIndex.ToString();
            }

            // mapGrid.Children.IndexOf(border);
        }

        private void updateGridMap(object sender, TextChangedEventArgs e)
        {
            UpdateGrid();
        }

        private void menuSaveClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    writer.WriteLine("columns: " + mapGrid.Columns.ToString());
                    writer.WriteLine("rows: " + mapGrid.Rows.ToString());
                    writer.WriteLine();
                    int totalCells = mapGrid.Rows * mapGrid.Columns;
                    for (int i = 0; i < totalCells; i++)
                    {
                        var border = mapGrid.Children[i] as Border;
                        if (border != null)
                        {
                            var text = border.Child as TextBlock;
                            writer.Write(text.Text + ",");
                        }
                    }
                }
            }
        }

        private void menuSkillClick(object sender, RoutedEventArgs e)
        {
            SkillEditor editor = new SkillEditor();
            if (editor.ShowDialog() == true)
            {
                mSkills.Add(editor.MySkill);
                lbSkills.Items.Refresh();
            }
        }

        private void menuEnemyClick(object sender, RoutedEventArgs e)
        {
            EnemyEditor editor = new EnemyEditor();
            if (editor.ShowDialog() == true)
            {
                // add save logic to the list of enemy
            }
        }
    }
}
