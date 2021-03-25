using SharpDX;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SoftEngine
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Device _device;
        private Mesh[] _meshes;
        private Camera _camera = new Camera();
        DateTime previousDate;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // Get the screen size
            //var displayInformation = Windows.Graphics.Display.DisplayInformation.GetForCurrentView();
            //var screenSize = new Size(displayInformation.ScreenWidthInRawPixels, displayInformation.ScreenHeightInRawPixels);

            WriteableBitmap bmp = new WriteableBitmap(640, 480);

            // Image XAML Control
            frontBuffer.Source = bmp;

            _device = new Device(bmp);

            _meshes = await _device.LoadJsonFileAsync("monkey.babylon");

            _camera.Position = new Vector3(0, 0, 10.0f);
            _camera.Target = Vector3.Zero;

            CompositionTarget.Rendering += CompositionTarget_Rendering;
        }

        void CompositionTarget_Rendering(object sender, object e)
        {
            // Manage Fps
            var now = DateTime.Now;
            var currentFps = 1000.0 / (now - previousDate).TotalMilliseconds;
            previousDate = now;

            fps.Text = string.Format("{0:0.00} fps", currentFps);

            _device.Clear(0, 0, 0, 255);

            foreach (var mesh in _meshes)
                mesh.Rotation = new Vector3(mesh.Rotation.X + 0.01f, mesh.Rotation.Y + 0.01f, mesh.Rotation.Z);

            // Doing the various matrix operations
            _device.Render(_camera, _meshes);

            // Flushing the back buffer into the front buffer
            _device.Present();
        }
    }
}