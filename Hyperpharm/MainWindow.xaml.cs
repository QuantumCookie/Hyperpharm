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

namespace Hyperpharm
{
    public partial class MainWindow : Window
    {
        private Tool activeTool;

        private Cursor cursorDefault;
        private Cursor cursorTorch;
        private Cursor cursorCotton;

        public MainWindow()
        {
            InitializeComponent();

            activeTool = Tool.NONE;

            cursorDefault = Cursors.Arrow;
            cursorCotton = new Cursor(Application.GetResourceStream(
            new Uri("res/cursor_cotton.cur", UriKind.Relative)).Stream
            );
            cursorTorch = new Cursor(Application.GetResourceStream(
            new Uri("res/cursor_torch.cur", UriKind.Relative)).Stream
            );

            toolTorch.Click += TorchButtonClick;
            toolCotton.Click += CottonButtonClick;
        }

        private void ToolClicked(Tool tool)
        {
            if(tool == activeTool)
            {
                this.Cursor = cursorDefault;
                activeTool = Tool.NONE;
                return;
            }
            else
            {
                activeTool = tool;
            }

            switch(activeTool)
            {
                case Tool.TORCH:
                    this.Cursor = cursorTorch;
                    break;

                case Tool.COTTON:
                    this.Cursor = cursorCotton;
                    break;

                default:
                    this.Cursor = cursorDefault;
                    break;
            }
        }

        private void TorchButtonClick(object sender, RoutedEventArgs e)
        {
            ToolClicked(Tool.TORCH);
        }

        private void CottonButtonClick(object sender, RoutedEventArgs e)
        {
            ToolClicked(Tool.COTTON);
        }
    }
}