# Morioh's Clipboard Manager
# [Download the latest version here](https://github.com/xMorioh/ClipboardManager/releases/latest)
# [Check out my other Projects on my Website](https://xmorioh.gitlab.io/index.html)


**About this Project**

The Goal is to make a lightweight Clipboard listener that would change certain values of a text being copied, it should also have a GUI for easy and quick usage.
<br>
This Application is made in .NET C# as a Forms Application.

**Application Features**:
* Listenes to the Windows Clipboard
* Chooses what to do with a given User Input
* User Input is being saved across sessions
* Has different algorithms depending on the usecase
<br>

**How to use this Application**:
<br>
In the first column you have the Text Field that defines the series of characters you want to application to search for
<br>
<br>
In the second column you enter the values you want the found string to be exchanged by
<br>
<br>
The third Column is meant for the given algorithm you want to choose from, "ContentTrimToEnd" will search for a string and remove it and everything after while "ContentReplace" will search for different patterns separated via ',' and replace it with the second column entered string. Basically 1. input -> 2. Output -> 3. via x Operation.
<br>
<br>
The Application will start hidden by default, it will hide in the Tray Icons, you can open it again with a double click or right click and "Open", there you can also hide it again entirely or Exit the Application.
<br>
<br>
To run this via Windows autostart just make a shortcut and place it under WIN+R "shell:startup".

**Preview**:

![ClipboardManager-Preview](https://github.com/xMorioh/ClipboardManager/blob/master/ClipboardManager-Preview.png)