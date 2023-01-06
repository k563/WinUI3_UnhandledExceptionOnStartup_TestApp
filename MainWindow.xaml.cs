//
// MainWindow.cs
//

using System.Threading.Tasks;

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
      // We're not throwing an exception here.
      System.Diagnostics.Debug.WriteLine("myButton_Click") ;
      myButton.Content = "Clicked" ;
    }

    private void myButtonThrow_Click ( object sender, Microsoft.UI.Xaml.RoutedEventArgs e )
    {
      //
      // Throwing an exception here kindof works as expected, in that two of our UnhandledException
      // event handlers get invoked. However, the app continues to run, even when we don't set 'Handled' to true.
      // The docs state that the app would be expected to terminate when 'Handled' is left as false.
      // Note that the 'System.AppDomain.CurrentDomain.UnhandledException' handler doesn't get called.
      System.Diagnostics.Debug.WriteLine("myButtonThrow_Click") ;
      throw new System.ApplicationException("Thrown in click handler") ;
      myButtonThrow.Content = "Clicked" ;
    }

    private async void myButtonThrowAsync_Click ( object sender, Microsoft.UI.Xaml.RoutedEventArgs e )
    {
      //
      // Here our UnhandledException event handlers don't get invoked, instead the
      // 'System.AppDomain.CurrentDomain.UnhandledException' handler gets invoked. 
      // The app then terminates.
      //
      System.Diagnostics.Debug.WriteLine("myButtonThrowAsync_Click") ;
      await Task.Run(
        () => throw new System.ApplicationException("Thrown in async click handler")
      ) ;
      throw new System.ApplicationException("Thrown in async click handler") ;
      myButtonThrowAsync.Content = "Clicked" ;
    }

  }

}
