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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        string[] _brailleAlphabet = new string[] { "⠁", "⠃", "⠉" };
        string[] _normalAlphabet = new string[] { "a", "b", "c" };

        public MainWindow()
        {
            InitializeComponent();
            foreach (var c in _brailleAlphabet)
            {
                SelectBrailleCharacter.Items.Add(c);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedChar = SelectBrailleCharacter.SelectionBoxItem;
            BrailleLabel.Content += selectedChar.ToString();
            Translate();
        }

        private void Translate()
        {
            var brailleText = BrailleLabel.Content.ToString();
            var normalText = "";
            foreach (var c in brailleText)
            {
                var index = Array.IndexOf(_brailleAlphabet, c.ToString());
                normalText += index == -1 ? "?" : _normalAlphabet[index];
            }

            TextLabel.Content = normalText;
        }
    }
}
