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
In the first column you have the Text Field that defines the series of characters you want the application to search for, you can enter several values here (comma separated), the first value that is found in the clipboard of each comma separated values present in this field will be the one that the algorithm will choose. Note that comma separation does not require a space after and should in fact not be entered unless you require it yourself for your logic setup.
<br>
<br>
In the second column you enter the values you want the found string to be exchanged by if a given algorithm supports this field.
<br>
<br>
The third Column is meant for the given algorithm you want to choose from, "ContentTrimToEnd" will search for a string and remove it and everything after while "ContentReplace" will search for different patterns separated via comma and replace it with the second column entered string. Basically 1. input -> 2. Output -> 3. via x Operation. Note that here too the first found value in the clipboard will be the one that is chosen, not necessarily the one that you've entered first in the first column!
<br>
<br>
The application will loop through every row every time it detects a change in the clipboard, it will skip every row you leave blank in between but it is recommended to fill the rows from top to bottom regardless. If you get an empty clipboard back or a value you didn't anticipate then check your logic as it may be easy to have a string going through several rows which you didn't want it to from your previous setup. This is also why you should always provide as long of a string as possible in your first column!
<br>
Let's say you want to exchange a domain name in a link, then it is best to input "https://github.com/" and replace it with "https://gitlab.com/" for example. Even though there are just 2 letters to exchange this will make sure that the loop won't interact with it again given multiple rows are being used.
<br>
<br>
The Application will start hidden by default, it will hide in the Tray Icons, you can open it again with a double click or right click and "Open", there you can also hide it again entirely or Exit the Application.
<br>
<br>
To run this application via Windows autostart just make a shortcut and place it under WIN+R "shell:startup".

**Preview**:

![ClipboardManager-Preview](https://github.com/xMorioh/ClipboardManager/blob/master/ClipboardManager-Preview.png)