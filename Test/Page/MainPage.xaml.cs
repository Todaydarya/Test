using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace Test.Page
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void AnalyzeButton_Click(object sender, RoutedEventArgs e)
        {
            string article = ArticleTextBox.Text.Trim();

            if (string.IsNullOrEmpty(article))
            {
                MessageBox.Show("Введите артикуль");
                return;
            }

            AnalyzeGlassPackage(article);
        }

        private void AnalyzeGlassPackage(string article)
        {
            string[] parts = article.Split(new char[] { '/', '\\' });

            int elementCount = parts.Length;

            int chamberCount = elementCount / 2;
            //Почему то артикли с m1 прибавляют 1 к числу, хотя не должно
            int glassThickness = GetGlassThickness(article);
            bool isDoubleChambered = chamberCount == 2;

            int totalThickness = parts.Sum(p => GetThickness(p));

            MessageBox.Show($"Артикуль: {article}\n" +
                            $"Камерность: {chamberCount}\n" +
                            $"Толщина СП: {totalThickness}\n" +
                            $"Толщина стекла: {glassThickness-1}");
        }

        private int GetThickness(string part)
        {
            string thicknessStr = new string(part.TakeWhile(c => char.IsDigit(c) || c == ' ').ToArray());
            return string.IsNullOrEmpty(thicknessStr) ? 0 : thicknessStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Sum(s => int.Parse(s));
        }

        private int GetGlassThickness(string article)
        {
            string[] parts = article.Split(new char[] { '/' });

            int totalGlassThickness = 0;

            totalGlassThickness += GetFirstNumber(parts[0]);

            for (int i = 1; i < parts.Length; i++)
            {
                if (i % 2 == 0)
                {
                    MatchCollection matches = Regex.Matches(parts[i], @"\d+");

                    foreach (Match match in matches)
                    {
                        if (int.TryParse(match.Value, out int thickness))
                        {
                            totalGlassThickness += thickness;
                        }
                    }
                }
            }

            return totalGlassThickness;
        }

        private int GetFirstNumber(string input)
        {
            Match match = Regex.Match(input, @"\d+");

            if (match.Success)
            {
                if (int.TryParse(match.Value, out int thickness))
                {
                    return thickness;
                }
            }

            return 0;
        }

    }
}