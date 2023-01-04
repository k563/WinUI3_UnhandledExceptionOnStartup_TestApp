//
// App.xaml.cs
//

namespace WinUI3_UnhandledExceptionTestApp
{

  // NOTE : DISABLE_XAML_GENERATED_BREAK_ON_UNHANDLED_EXCEPTION has been defined
  // in the project settings, so that we won't get a Debug.Break if an exception
  // does get handled. Instead, the unhandled exception will just be handled here. 

  // Build and run the app with Debug/x64 to demonstrate the issue.

  public partial class App : Microsoft.UI.Xaml.Application
  {

    //
    // If we set this to true, our handler isn't called ; a couple of message boxes appear
    // telling us that the app will terminate immediately ...
    // 
    //   Unhandled exception at 0x00007FFCC94D1C9F (combase.dll)
    //   A fail fast exception occurred. Exception handlers will not be invoked
    //   and the process will be terminated immediately.
    //
    // HOWEVER THE APP CONTINUES TO RUN. The main window comes up and so on.
    // None of our three 'UnhandledException' handlers get called.
    //

    public static bool ThrowExceptionInAppConstructor = true ; // DOESN'T WORK AS YOU'D EXPECT !!!

    public App ( )
    {

      this.InitializeComponent() ;

      // Set up all three flavours of 'UnhandledException' event handler.
      // We surely can expect any exceptions throw from *anywhere* in the app
      // to be caught by one of these ???

      this.UnhandledException += (
        object                                        sender, 
        Microsoft.UI.Xaml.UnhandledExceptionEventArgs unhandledExceptionEventArgs 
      ) => {
        System.Diagnostics.Debug.WriteLine(  
          $"App.UnhandledException : '{unhandledExceptionEventArgs.Exception.Message}'"
        ) ;
      } ;

      Microsoft.UI.Xaml.Application.Current.UnhandledException += (
        object                                        sender, 
        Microsoft.UI.Xaml.UnhandledExceptionEventArgs unhandledExceptionEventArgs 
      ) => {
        // This handler does get called, but only in the same circumstances as App.UnhandledException.
        // And it only tells us 'Error in the application' ; the Message from the thrown exception isn't available.
        System.Diagnostics.Debug.WriteLine(  
          $"Microsoft.UI.Xaml.Application.Current.UnhandledException : '{unhandledExceptionEventArgs.Exception.Message}'"
        ) ;
      } ;

      System.AppDomain.CurrentDomain.UnhandledException += (
        object                             sender, 
        System.UnhandledExceptionEventArgs unhandledExceptionEventArgs
      ) => {
        // We've never seen this being called ...
        System.Diagnostics.Debug.WriteLine(  
          $"AppDomain.CurrentDomain.UnhandledException raised : {unhandledExceptionEventArgs.ExceptionObject} {unhandledExceptionEventArgs.IsTerminating}"
        ) ;
      } ;

      if ( App.ThrowExceptionInAppConstructor ) 
      { 
        System.Diagnostics.Debug.WriteLine("Throwing exception in App constructor") ;
        throw new System.ApplicationException("Thrown in App constructor") ; 
      }

    }

    protected override void OnLaunched ( Microsoft.UI.Xaml.LaunchActivatedEventArgs args )
    {
      m_window = new MainWindow() ;
      m_window.Activate() ;
    }

    private Microsoft.UI.Xaml.Window m_window ;

  }

}
