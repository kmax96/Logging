# Logging 
This is a C# class to write text log in a txt file
Normally, i use it on error handling

Open a LOG folder in the root, and assign write permission
when trigger: 
Logging.writeLog("Hi");

it will add a new line to txt file

Remarks: 
each day will only save 1 new file, if any logging triggered.  
all logging in the same day will append in same file
