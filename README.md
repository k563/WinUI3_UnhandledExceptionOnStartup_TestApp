# WinUI3_UnhandledExceptionTestApp

This is simple WinUI-3 app that tests out the support for App.UnhandledException in the WindowsAppSDK 1.2.221209.1. 

It demonstrates that while most of the previously reported issues (#5221) have been resolved, there are still some situations where things don't behave as expected.

In App.xaml.cs you can set up a flag that enables an exception to be thrown in the app constructor. 
And the main window has some buttons that you can click on to raise exceptions.

Comments in the code explain what we expect to happen, and what actually happens.

In a nutshell :

- When we throw an exception at the end of the App constructor, none of the three UnhandledException handlers we've installed are invoked - and rather than terminating, the app continues to run.

- When we throw an exception from an ordinary button-click, our first two UnhandledException handlers do get called, but the app continues to run even if we don't set the 'Handled' property to true. We'd expect the app to terminate.

- When we throw an exception from an 'async' button-click event handler, the third 'System.AppDomain.CurrentDomain.UnhandledException' handler gets called, and the app terminates. The first two handlers don't get called, so we'd never get an opportunity to set 'Handled' to true and let the app continue.

Built with 17.4.3 Enterprise ; the WindowsAppSDK 1.2.2 has been installed ; native debugging has been enabled in the project settings.













