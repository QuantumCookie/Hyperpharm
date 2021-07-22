using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace Hyperpharm
{
    public partial class DrugSelectionWindow : Window
    {
        public string SelectedDrug { get; set; }
        public List<Drug> drugs;

        public DrugSelectionWindow()
        {
            InitializeComponent();

            drugs = new List<Drug>();
            drugs.Add(new Drug(800, "Physostigmine"));
            drugs.Add(new Drug(801, "Ephedrine"));
            drugs.Add(new Drug(802, "Atropine"));
            drugs.Add(new Drug(803, "Lignocaine"));
            drugs.Add(new Drug(803, "Lignocaine"));
            drugs.Add(new Drug(803, "Lignocaine"));
            drugs.Add(new Drug(803, "Lignocaine"));

            this.DataContext = drugs;
        }

        private void DrugSelected(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            SelectedDrug = b.Content.ToString();
            DialogResult = true;
        }

        public class Drug
        {
            public string Name { get; }
            public int Uid { get; }

            public Drug(int uid, string name)
            {
                Name = name;
                Uid = uid;
            }
        }
    }
}
