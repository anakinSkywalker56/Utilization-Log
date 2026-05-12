# Utilization-Log
This is the C5/C6 Utilization Log system for paperless monitoring

## Developers

- Admin: [John Anakin Injug](https://github.com/anakinSkywalker56) 
- Collaborator: [Kyle Albeos](https://github.com/gKylee)


## Description

This program is initially for `C7`, A Utilization log system to replace the original paper-based login. The program contains multiple restrictions for end users to force data entry or face being unable to use the PC

## Restrictions

- Clicking outside the form
- Incomplete form record
- alt+f4
- alt+tab
- Control tabs (esc, min)

## Automatic

- Auto run on startup
- Auto run on all users (Read [Auto run on all users](#auto-run-on-all-users) for instructions)

## Auto run on all users

Instructions on How-To auto run to all users

### Steps

- Step 1:
    - Login as .\itadmin or .\admin
- Step 2:
    - Open `Registry Editor` on windows search bar
- Step 3:
    - Navigate to:
    ```bash
    Computer\HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Run
    ```

    This is the visual:
    ```bash
    Computer\
    └── HKEY_LOCAL_MACHINE
        └── SOFTWARE
            └── Microsoft
                └── Windows
                    └── CurrentVersion
                        └── Run
    ```
- Step 4:
    - `Right-click ` inside the space and click `New` > `String value`
- Step 5:
    - Rename the default name to C7 (or whatever your app name is)
- Step 6:
    - `Right-click` again to `Modify`, then change the Data to the app file path with the app.exe file
    ```bash
    Encase in string quotes ("")

    "C:\Users\working\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\C7\C7.lnk"
    ```
