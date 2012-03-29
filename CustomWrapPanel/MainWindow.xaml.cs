using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CustomWrapPanel 
{
    public partial class MainWindow : Window 
    {
        public MainWindow() 
        {
            InitializeComponent();
        }

        private void btnFill_Click(object sender, RoutedEventArgs e) 
        {
            testcustompanel.Children.Clear();

            for(int i = 0; i < 999; i++) 
            {
                if(testcustompanel.PanelFull == false)
                {
                    Rectangle thisrect = new Rectangle();
                    thisrect.Fill = Brushes.Orange;
                    thisrect.Stroke = Brushes.Black;
                    thisrect.StrokeThickness = 1;
                    thisrect.Height = 48;
                    thisrect.Width = 96;

                    testcustompanel.AddControl(thisrect);
                }

            }
        }
    }
}
