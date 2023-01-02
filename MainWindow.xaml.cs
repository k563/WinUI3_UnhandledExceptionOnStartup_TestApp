//
// MainWindow.cs
//

namespace WinUI3_UnhandledExceptionTestApp
{

  public sealed partial class MainWindow : Microsoft.UI.Xaml.Window
  {

    public MainWindow ( )
    {
      this.InitializeComponent() ;
    }

    private void myButton_Click ( object sender, Microsoft.UI.Xaml.RoutedEventArgs e )
    {
      System.Diagnostics.Debug.WriteLine("myButton_Click") ;
      myButton.Content = "Clicked" ;
    }

  }

}
