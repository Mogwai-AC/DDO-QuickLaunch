# DDO-QuickLaunch
The faster, easier way to log in to Dungeons and Dragons Online (DDO)

# How it works
DDO-QuickLaunch skips a bunch of steps that the normal launcher does:
* Downloading News
* Downloading Splash Screens
* Patch Checking
* Patching
* EULAs

Things DDO-QuickLaunch does not skip:
* Getting a GLS ticket
* Waiting for the Login Queue, if there is one.

# How do you store passwords?
When the Microsoft.Net framework is installed on a machine, it generates a key that is unique to that computer.  For the purposes of DDO-QuickLaunch, that's here:
C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config\machine.config.

This is the key DDO-QuickLaunch uses to encrypt your password.  If your DDO-QuickLaunch files are ever stolen, your password remains secure as long as the machine.config file is not stolen as well.  This is fairly common practice in .Net applications.  There are other ways to do it better, but they are more cumbersome and have other risks that are less acceptable.  The reality is that your passwords have to be decoded somehow, and using the machine.config is as good a solution as any.

# How do I find Mogwai?
You can find me as Mogwai in the DDO Discord Server here:
https://discordapp.com/invite/7kAAp
