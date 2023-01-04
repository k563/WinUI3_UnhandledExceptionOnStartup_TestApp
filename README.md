# WinUI3_UnhandledExceptionTestApp

This is simple WinUI-3 app that tests out the support for App.UnhandledException in the WindowsAppSDK 1.2.221209.1. 

It demonstrates that while most of the previously reported issues (#5221) have been resolved, there is still one situation where things doesn't behave as expected.

In App.xaml.cs you can set up a flag that enables an exception to be thrown in the app constructor. Comments in the code explain what we expect to happen, and what actually happens. 

In a nutshell ... when we throw an exception at the end of the App constructor, the UnhandledException handlers we've installed are never invoked - and rather than terminating, the app continues to run.

Built with 17.4.3 Enterprise ; the WindowsAppSDK 1.2.2 has been installed ; native debugging has been enabled in the project settings.













