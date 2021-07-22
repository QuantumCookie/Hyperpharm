using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Tool _activeTool;

        public Tool ActiveTool
        {
            get { return _activeTool; }
            set { _activeTool = value; OnPropertyRaised("ActiveTool"); }
        }

        private bool _canHighlightEye;
        public bool CanHighlightEye
        {
            get { return _canHighlightEye; }
            set { _canHighlightEye = value; OnPropertyRaised("CanHighlightEye"); }
        }

        private bool _lightReflexActive;
        public bool LightReflexActive
        {
            get { return _lightReflexActive; }
            set { _lightReflexActive = value; OnPropertyRaised("LightReflexActive"); }
        }

        private bool _cornealReflexActive;
        public bool CornealReflexActive
        {
            get { return _cornealReflexActive; }
            set { _cornealReflexActive = value; OnPropertyRaised("CornealReflexActive"); }
        }

        private float _pupilDiameter;
        private float lastPupilDiameter;

        public float PupilDiameter
        {
            get { return _pupilDiameter; }
            set { _pupilDiameter= value; OnPropertyRaised("PupilDiameter"); }
        }

        private Cursor cursorDefault;
        private Cursor cursorTorch;
        private Cursor cursorCotton;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyRaised(string propertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }

        public MainWindow()
        {
            InitializeComponent();

            ActiveTool = Tool.NONE;
            CanHighlightEye = false;
            LightReflexActive = true;
            CornealReflexActive = true;

            cursorDefault = Cursors.Arrow;
            cursorCotton = new Cursor(Application.GetResourceStream(
            new Uri("res/cursor_cotton.cur", UriKind.Relative)).Stream
            );
            cursorTorch = new Cursor(Application.GetResourceStream(
            new Uri("res/cursor_torch.cur", UriKind.Relative)).Stream
            );

            torchButton.Click += TorchButtonClick;
            cottonButton.Click += CottonButtonClick;
        }

        private void ToolClicked(Tool tool)
        {
            if(tool == ActiveTool)
            {
                this.Cursor = cursorDefault;
                ActiveTool = Tool.NONE;
                CanHighlightEye = false;
                return;
            }
            else
            {
                ActiveTool = tool;
            }

            switch(ActiveTool)
            {
                case Tool.TORCH:
                    this.Cursor = cursorTorch;
                    CanHighlightEye = true;
                    break;

                case Tool.COTTON:
                    this.Cursor = cursorCotton;
                    CanHighlightEye = true;
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

        private void NewDrug(object sender, RoutedEventArgs e)
        {
            DrugSelectionWindow drugSelectionWindow = new DrugSelectionWindow();
            drugSelectionWindow.Owner = this;
            drugSelectionWindow.ShowDialog();
            
            if((bool)drugSelectionWindow.DialogResult)
            {
                MessageBox.Show(drugSelectionWindow.SelectedDrug, "Drug Selected", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}