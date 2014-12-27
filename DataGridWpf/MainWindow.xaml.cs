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
using System.ComponentModel;

namespace DataGridWpf
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            BibliosEntities db = new BibliosEntities();

            var query = from b in db.Books select new { b.isbn, b.title, b.publisher_id, b.pages };

            List<Libro> libros = new List<Libro>();

            foreach (var item in query)
            {
                libros.Add(new Libro { isbn = item.isbn, title = item.title, publisher_id = item.publisher_id, pages = item.pages });
            }

            //dataGrid.ItemsSource = db.Books.ToList();
            dataGrid.ItemsSource = libros;
        }

        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.Column.DisplayIndex == 0)
            {
                Libro libro = e.Row.Item as Libro;

                if (libro != null)
                {
                    libro.pages = -12;
                }
            }
        }
    }

    public class Libro : INotifyPropertyChanged
    {
        private string _isbn;
        public string isbn
        {
            get { return _isbn; }
            set
            {
                _isbn = value;
                OnPropertyChanged("isbn");
            }
        }
        public int publisher_id { get; set; }
        public string title { get; set; }
        private int _pages;
        public int pages
        {
            get { return _pages; }
            set
            {
                _pages = value;
                OnPropertyChanged("pages");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
