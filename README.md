# WinUI3_UnhandledExceptionTestApp

A simple WinUI-3 app that tests out the support for App.UnhandledException in the WindowsAppSDK 1.1.2, and demonstrates that there are a couple of situations where it doesn't behave as expected.

In App.xaml.cs you can set up some flags that enable an exceptions to be thrown (A) in the app constructor, or (B) in 'App.OnLoaded'. Comments in the code explain what we expect to happen, and what actually happens.

Built with 17.4.3 Enterprise ; the WindowsAppSDK 1.2.2 has been installed ; native debugging has been enabled in the project settings.












