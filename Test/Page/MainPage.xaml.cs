using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
using Test.Model;

namespace Test.Page
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage
    {
        private TestEntities dbContext = new TestEntities();
        public MainPage()
        {
            InitializeComponent();
            dataGridPackages.ItemsSource = dbContext.GlassPackages.ToList();
        }

        private void btnCheckArticle_Click(object sender, RoutedEventArgs e)
        {
            string article = txtArticle.Text;

            try
            {
                var package = dbContext.GlassPackages.FirstOrDefault(p => p.Article == article);
                if (package != null)
                {
                    dataGridPackages.ItemsSource = new[] { package };
                }
                else
                {
                    MessageBox.Show("Стеклопакет с указанным артикулом не найден.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}
