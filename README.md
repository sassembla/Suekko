#Suekko
ver 0.3.0

create Unity WindowGUI from plane C# code, without additional coding.

![loading](./doc/scr.png?raw=true)



## surpported types
public bool, string, enum are available.


## supported methods
public no parameter methods are available.


## installation
1. download this repo and copy Assets/SuekkoWindow folder into your Assets folder.
1. change next line. set your script's type into L13's typeof() method.

e.g, if you want to create GUI of "YourScript" class, 

set your script type to **SuekkoWindow.cs#L13** like below.

```
static Type targetType = typeof(YourScript);
```

[setting location is uekkoWindow.cs#L13](https://github.com/sassembla/Suekko/blob/master/Assets/SuekkoEditorWindow/Editor/GUI/SuekkoWindow.cs#L13)


## license
[MIT](./LICENSE)