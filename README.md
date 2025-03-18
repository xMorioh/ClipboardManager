# Morioh's Clipboard Manager
# [Download the latest version here](https://github.com/xMorioh/ClipboardManager/releases/latest)
# [Check out my other Projects on my Website](https://xmorioh.gitlab.io/index.html)


**About this Project**

The Goal is to make a lightweight Clipboard listener that would change certain values of a text being copied, it should also have a GUI for easy and quick usage.
<br>
This Application is made in .NET C# as a Forms Application.

**Application Features**:
* Listenes to the Windows Clipboard
* Chooses on how to change it given a specific User Input
* User Input is being saved across sessions
* Has different algorithms depending on the usecase
<br>

**How to use this Application**:
<br>
In the first column you have the Text Field that defines the series of characters you want the application to search for and only if your entered text is present in the clipboard then the application will proceed, if you leave this field empty it assums that you do not want to set a required text to search for in the clipboard which will lead to the application to proceed, so this field only does something if you set some text in it, otherwise this field will just be skipped, you can enter several values here (comma separated). Note that comma separation does not require a space after and should in fact not be entered unless you require it yourself for your logic setup.
<br>
<br>
In the second column you have the Text Field that defines the series of characters you specifically want the application to search for, you can enter several values here (comma separated), the first value that is found in the clipboard of each comma separated values present in this field will be the one that the algorithm will choose. Note that here as well comma separation does not require a space after and should in fact not be entered unless you require it yourself for your logic setup.
<br>
<br>
In the third column you enter the values you want the found string to be exchanged by if a given algorithm supports this field.
<br>
<br>
The fourth Column is meant for the given algorithm you want to choose from, "ContentTrimToEnd" will search for a string and remove it and everything after while "ContentReplace" will search for different patterns separated via comma and replace it with the third column entered string. Basically (1. only do something if this is present -> 2. which content to take -> 3. replace with this -> 4. via x Operation). Note that here too the first found value in the clipboard will be the one that is chosen, not necessarily the one that you've entered first in the second column when it isn't present! The algorithm "ContentAddToEnd" will add some content to the end of the clipboard if present in the third column, note that due to a bug this algorithm does not work when you add some text that is already present in the clipboard, meaning that you can only add content at the end that isn't already somewhere in the clipboard.
<br>
<br>
The application will loop through every row every time it detects a change in the clipboard, it will skip every row you leave blank in between but it is recommended to fill the rows from top to bottom regardless. If you get an empty clipboard back or a value you didn't anticipate then check your logic as it may be easy to have a string going through several rows which you didn't want it to from your previous setup. This is also why you should always provide as long of a string as possible in your second column!
<br>
Let's say you want to exchange a domain name in a link, then it is best to input "https://github.com/" and replace it with "https://gitlab.com/" for example. Even though there are just 2 letters to exchange this will make sure that the loop won't interact with it again given multiple rows are being used and the word won't be exchanged or done anything to it if you copy a text where it happens to be in as well.
<br>
<br>
The Application will start hidden by default, it will hide in the Tray Icons, you can open it again with a double click or right click and "Open", there you can also hide it again entirely or Exit the Application.
<br>
<br>
To run this application via Windows autostart just create a new task in Windows Task Scheduler for it.
<br>
<br>

**Known Bugs**:
<br>
When the application is started and sometimes when running in the background and the User is not logged in to their Desktop session or it's locked, then the application could occasionally throw an error "Requested Clipboard operation did not succeed". This is being catched and logged under "C:\Users\%username%\AppData\Local\Morioh\ClipboardManager\Logging". There is currently no fix for this. If the occurance in the Log is rappidly repeating in short time intervals then make sure to close the application and report this as a bug in this Repository here and include your running processes in the bug report as this bug is probably caused by interactions from or to other applications.
<br>
<br>

**Preview**:

![ClipboardManager-Preview](https://github.com/xMorioh/ClipboardManager/blob/master/ClipboardManager-Preview.png)