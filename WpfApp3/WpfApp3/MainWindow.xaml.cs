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

namespace WpfApp3
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
    }

namespace YourNamespace
    {
        public static class TextBoxHelper
        {
            public static readonly DependencyProperty PlaceholderTextProperty =
                DependencyProperty.RegisterAttached(
                    "PlaceholderText",
                    typeof(string),
                    typeof(TextBoxHelper),
                    new PropertyMetadata(string.Empty, OnPlaceholderTextChanged));

            public static string GetPlaceholderText(UIElement element) =>
                (string)element.GetValue(PlaceholderTextProperty);

            public static void SetPlaceholderText(UIElement element, string value) =>
                element.SetValue(PlaceholderTextProperty, value);

            private static void OnPlaceholderTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                if (d is TextBox textBox)
                {
                    textBox.GotFocus += (s, _) => RemovePlaceholder(textBox);
                    textBox.LostFocus += (s, _) => ShowPlaceholder(textBox);

                    if (string.IsNullOrEmpty(textBox.Text))
                    {
                        ShowPlaceholder(textBox);
                    }
                }
            }

            private static void ShowPlaceholder(TextBox textBox)
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    textBox.Text = GetPlaceholderText(textBox);
                    textBox.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Gray);
                }
            }

            private static void RemovePlaceholder(TextBox textBox)
            {
                if (textBox.Text == GetPlaceholderText(textBox))
                {
                    textBox.Text = string.Empty;
                    textBox.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.White);
                }
            }
        }
    }

}
 
