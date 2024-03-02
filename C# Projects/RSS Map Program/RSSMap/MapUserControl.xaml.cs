using Microsoft.Maps.MapControl.WPF;
using Microsoft.Maps.MapControl.WPF.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RSSMap
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class MapControl : UserControl
    {
        public event MouseButtonEventHandler clicked;
        public MapControl()
        {
            InitializeComponent();
        }

        internal void addPins(List<RSSArticle> articles)
        {
            //InitializeComponent();
            this.Map.Children.Clear();
            foreach (RSSArticle article in articles)
            {
                Pushpin mypin = new Pushpin();
                mypin.Location = new Location(article.latitude, article.longitude);
                mypin.Content = article.URL;
                mypin.ToolTip = article.Title + "\n" + article.Description;
                mypin.MouseDown += clicked;
                this.Map.Children.Add(mypin);
            }
            

        }

        private void PinClicked(object sender, MouseButtonEventArgs e)
        {
            Pushpin p = sender as Pushpin;
        }

    }


}
