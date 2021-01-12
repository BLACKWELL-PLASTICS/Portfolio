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
using System.Drawing;
using System.IO;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GridEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int GridWidth = 0;
        int GridHeight = 0;

        private bool penIsDown = false;

        public Image[,] images;

        private ImageSource penImageSource;
        public enum Tool
        {
            Pen,
            Erase
        }
        private Tool selectedTool = Tool.Pen;

        public MainWindow()
        {

            InitializeComponent();

            CreateGrid();

            images = new Image[GridWidth, GridHeight];

            for (int x = 0; x < GridWidth; x++)
            {
                for (int y = 0; y < GridHeight; y++)
                {
                    Image image = new Image();
                    Grid.SetColumn(image, x);
                    Grid.SetRow(image, y);

                    grid.Children.Add(image);

                    images[x, y] = image;
                }
            }
            grid.MouseDown += OnMouseDown;
            grid.MouseUp += OnMouseUp;
        }

        void CreateGrid()
        {
            double WIDTH = this.Width;
            double HEIGHT = this.Height;

            for (int x = 0; x <= WIDTH / 32; x++)
            {
                GridWidth++;
                ColumnDefinition columnToAdd = new ColumnDefinition();
                columnToAdd.Width = new System.Windows.GridLength(32);
                grid.ColumnDefinitions.Add(columnToAdd);
            }

            for (int x = 0; x <= HEIGHT / 32; x++)
            {
                GridHeight++;
                RowDefinition rowToAdd = new RowDefinition();
                rowToAdd.Height = new System.Windows.GridLength(32);
                grid.RowDefinitions.Add(rowToAdd);
            }
        }


        public void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            penIsDown = true;
            grid.MouseMove += OnMouseMove;

            int x = (int)e.GetPosition(grid).X / 32;
            int y = (int)e.GetPosition(grid).Y / 32;

            if (penIsDown)
            {
                UseTool(x, y);
            }

        }

        private void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            penIsDown = false;
            grid.MouseMove -= OnMouseMove;

        }

        public void OnMouseMove(object sender, MouseEventArgs e)
        {
            penIsDown = true;
            int x = (int)e.GetPosition(grid).X / 32;
            int y = (int)e.GetPosition(grid).Y / 32;

            if (penIsDown)
            {
                UseTool(x, y);
            }
        }


        #region FILE_REGION
        private void HandleNew(object sender, RoutedEventArgs e)
        {
            for (int x = 0; x < GridWidth; x++)
            {
                for (int y = 0; y < GridHeight; y++)
                {
                    images[x, y].Source = null;
                    Coordinates.Text = "Coordinates:" + 0 + "," + 0;
                }
            }
        }

        private void HandleOpen(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog
            {
                Filter = "JSON (*.json)|*.json"
            };
            openDialog.Title = "Open File";

            if (openDialog.ShowDialog() == true)
            {
                string jsonData = System.IO.File.ReadAllText(openDialog.FileName);

                List<TileData> TileListLoaded = JsonConvert.DeserializeObject<List<TileData>>(jsonData);

                for (int xTile = 0; xTile < 60; xTile++)
                {
                    for (int yTile = 0; yTile < 31; yTile++)
                    {
                        if (TileListLoaded.Exists(i => i.tileID == Convert.ToString(xTile) + "." + Convert.ToString(yTile)))
                        {
                            int indexInt = TileListLoaded.FindIndex(i => i.tileID == Convert.ToString(xTile) + "." + Convert.ToString(yTile));
                            string imagePath = ((TileData)TileListLoaded[indexInt]).tileImage;
                            if (imagePath == "")
                            {
                                images[xTile, yTile].Source = null;
                            }
                            else
                            {
                                images[xTile, yTile].Source = new BitmapImage(new Uri(imagePath));
                            }
                        }
                        else
                        {
                            images[xTile, yTile].Source = null;
                        }
                    }
                }
            }
        }

        public void HandleJSON(object sender, RoutedEventArgs e)
        {
            var tileDataList = new List<TileData>();

            var TileListLoaded = new List<TileData>();

            int id = 0;

            for (int xTile = 0; xTile < 60; xTile++)
            {
                for (int yTile = 0; yTile < 31; yTile++)
                {
                    if (images[xTile, yTile].Source == null)
                    {
                        tileDataList.Add(new TileData
                        {
                            tileID = Convert.ToString(xTile) + "." + Convert.ToString(yTile),
                            tileImage = "",
                            tileX = xTile,
                            tileY = yTile

                        });
                    }
                    else
                    {
                        tileDataList.Add(new TileData
                        {
                            tileID = Convert.ToString(xTile) + "." + Convert.ToString(yTile),
                            tileImage = images[xTile, yTile].Source.ToString(),
                            tileX = xTile,
                            tileY = yTile

                        });
                    }
                    id++;
                }
                id++;
            }

            MainWindow saver = new MainWindow();
            SaveFileDialog saveJSONDialog = new SaveFileDialog
            {
                Filter = "JSON (*.json)|*.json"

            };
            if (saveJSONDialog.ShowDialog() == true)
            {
                StreamWriter sw = new StreamWriter(File.Create(saveJSONDialog.FileName));

                JsonSerializer serializer = new JsonSerializer();
                serializer.Converters.Add(new JavaScriptDateTimeConverter());
                serializer.NullValueHandling = NullValueHandling.Ignore;
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, tileDataList);
                }
            }

        }

        private void HandleClose(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        #endregion FILE_REGION


        #region TOOLBAR_REGION

        private void UseTool(int gridX, int gridY)
        {
            if (gridX < GridWidth && gridY < GridHeight)
            {
                switch (selectedTool)
                {
                    case Tool.Pen:
                        images[gridX, gridY].Source = penImageSource;
                        Coordinates.Text = "Coordinates:" + gridX + "," + gridY;
                        break;
                    case Tool.Erase:
                        images[gridX, gridY].Source = null;
                        break;
                    default:
                        break;
                }
            }
        }

        private void HandlePen(object sender, RoutedEventArgs e)
        {
            selectedTool = Tool.Pen;
        }

        private void HandleErase(object sender, RoutedEventArgs e)
        {
            selectedTool = Tool.Erase;
        }

        private void ComboBoxItem_Selected_3(object sender, RoutedEventArgs e)
        {
            // DIRT
            penImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/dirt.png"));
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            // SAND
            penImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/sand.png"));
        }

        private void ComboBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {
            // GRASS
            penImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/grass2.png"));
        }

        private void ComboBoxItem_Selected_2(object sender, RoutedEventArgs e)
        {
            // WATER
            penImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/water.png"));
        }

        #endregion TOOLBAR_REGION


    }
}
