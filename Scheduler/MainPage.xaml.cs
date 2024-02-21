using Microsoft.Maui.Layouts;
using Microsoft.Maui.Platform;

namespace Scheduler
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            SizeChanged += OnPageSizeChanged;
        }
        private void OnPageSizeChanged(object sender, EventArgs e)
        {
            var isLandscape = Width > Height;
            MyFlexLayout.Direction = isLandscape ? FlexDirection.Row : FlexDirection.Column;
            MainScrollView.Orientation = isLandscape ? ScrollOrientation.Horizontal : ScrollOrientation.Vertical;
        }
    }

}
