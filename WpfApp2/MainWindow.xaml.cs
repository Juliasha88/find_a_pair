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
//using System.Windows.Threading.DispatcherTimer;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

    /*    internal class Pic
        {
            Image[] arrImg; //массив картинок
            int[] arrCell; //массив ячеек для картинок
           // public void Init();
        }
        */


        public MainWindow()
        {
            InitializeComponent();
            Init();
        }

        Random rand = new Random();
        int countCol = 5;
        int countRow = 4;

        public void Init()
        {
           
            
            Grid.Height = Window.Height;
            Grid.Width = Window.Width;     

            Grid.HorizontalAlignment = HorizontalAlignment.Stretch;
            Grid.VerticalAlignment = VerticalAlignment.Stretch;

            Grid.ShowGridLines = true;

            for (int i = 0; i<countCol; i++)
            {
                ColumnDefinition colDef = new ColumnDefinition();
                Grid.ColumnDefinitions.Add(colDef);
            }

            for (int j = 0; j < countRow; j++)
            {
                RowDefinition rowDef = new RowDefinition();
                Grid.RowDefinitions.Add(rowDef);
            }

            List<Image> MyList = new List<Image>();
            List<Image> GridList = new List<Image>();

            // Add the first text cell to the Grid
            MyList.Add(new Image());
            MyList[MyList.Count-1].Source = new BitmapImage(new Uri("C://Users/nya/Documents/Visual Studio 2015/Projects/WpfApp2/WpfApp2/img/1.jpg"));

            MyList.Add(new Image());
            MyList[MyList.Count - 1].Source = new BitmapImage(new Uri("C://Users/nya/Documents/Visual Studio 2015/Projects/WpfApp2/WpfApp2/img/0.jpg"));

            MyList.Add(new Image());
            MyList[MyList.Count - 1].Source = new BitmapImage(new Uri("C://Users/nya/Documents/Visual Studio 2015/Projects/WpfApp2/WpfApp2/img/2.jpg"));

            MyList.Add(new Image());
            MyList[MyList.Count - 1].Source = new BitmapImage(new Uri("C://Users/nya/Documents/Visual Studio 2015/Projects/WpfApp2/WpfApp2/img/3.jpg"));

            MyList.Add(new Image());
            MyList[MyList.Count - 1].Source = new BitmapImage(new Uri("C://Users/nya/Documents/Visual Studio 2015/Projects/WpfApp2/WpfApp2/img/4.jpg"));

            MyList.Add(new Image());
            MyList[MyList.Count - 1].Source = new BitmapImage(new Uri("C://Users/nya/Documents/Visual Studio 2015/Projects/WpfApp2/WpfApp2/img/5.jpg"));

            Object control;
            int indx;
            int k = -1; int n = -1;
            for (int i = 0; i<countRow; i++)
            {
                for (int j = 0; j < countRow; j++)
                {

                    try
                    {
                        control = Grid.Children.Cast<UIElement>().First(kk => Grid.GetRow(kk) == i && Grid.GetColumn(kk) == j);
                    }
                    catch
                    {
                        control = null;
                    }

                    if (control == null)
                    {
                        indx = rand.Next(MyList.Count);

                        GridList.Add(new Image());
                        GridList[GridList.Count - 1].Source =MyList[indx].Source;

                        Grid.SetRow(GridList[GridList.Count - 1], i);
                        Grid.SetColumn(GridList[GridList.Count - 1], j);
                        textBox.AppendText(String.Format("({0};{1}) : {2}; ", i,j,indx));// indx.ToString()+"  ");
                        Grid.Children.Add(GridList[GridList.Count - 1]);
                        Twain(ref k, ref n);
                        if (k!=-1 && n!=-1)
                        {
                            Grid.SetRow(GridList[GridList.Count - 1], k);
                            Grid.SetColumn(GridList[GridList.Count - 1], n);
                            textBox.AppendText(String.Format("k n ({0};{1}) : {2}; ", k, n, indx));// indx.ToString()+"  ");
                            Grid.Children.Add(GridList[GridList.Count - 1]);
                        }
                        else
                        {
                            textBox.AppendText("Не нашли место!!!");
                        }
                    }
                    
                }
              
            }

        }

        public void Twain(ref int i, ref int j)
        {
            //ищем свободное место рандомно
            Object control;
            int k=0;
            int n=0;
            do
            {
                k = rand.Next(countCol);
                n = rand.Next(countRow);
                try
                {
                    control = Grid.Children.Cast<UIElement>().First(kk => Grid.GetRow(kk) == k && Grid.GetColumn(kk) == n);
                }
                catch
                {
                    control = null;
                }


            } while (control != null);

            i = k;
            j = n;  

        }

        internal void ImgClick()
        {
 
        }
          

    }
}
