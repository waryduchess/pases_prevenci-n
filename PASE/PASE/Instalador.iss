; Script Inno Setup para Control de Pases
[Setup]
AppName=Control de Pases
AppVersion=1.0
DefaultDirName=C:\ControlDePases
DefaultGroupName=ControlDePases
OutputBaseFilename=Instalador_ControlDePases
Compression=lzma
SolidCompression=yes
LicenseFile=Licencia.txt
ArchitecturesInstallIn64BitMode=x64
DisableProgramGroupPage=yes


[Files]
; Ejecutable principal
Source: "C:\Users\manue\OneDrive\Escritorio\6 Cuatrimestre\ESTANCIAS\pases_prevenci-n\PASE\PASE\bin\Release\PASE.exe"; DestDir: "{app}"; Flags: ignoreversion

; Todas las DLL necesarias
Source: "C:\Users\manue\OneDrive\Escritorio\6 Cuatrimestre\ESTANCIAS\pases_prevenci-n\PASE\PASE\bin\Release\*.dll"; DestDir: "{app}"; Flags: ignoreversion

; SQLite para x64
Source: "C:\Users\manue\OneDrive\Escritorio\6 Cuatrimestre\ESTANCIAS\pases_prevenci-n\PASE\PASE\bin\Release\x64\SQLite.Interop.dll"; DestDir: "{app}\x64"; Flags: ignoreversion

; SQLite para x86
Source: "C:\Users\manue\OneDrive\Escritorio\6 Cuatrimestre\ESTANCIAS\pases_prevenci-n\PASE\PASE\bin\Release\x86\SQLite.Interop.dll"; DestDir: "{app}\x86"; Flags: ignoreversion

; Archivos XML generados en publicación (si los usas)
Source: "C:\Users\manue\OneDrive\Escritorio\6 Cuatrimestre\ESTANCIAS\pases_prevenci-n\PASE\PASE\bin\Release\*.xml"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

; Imagen del logo (si la usas en PDFGenerator, por ejemplo)
Source: "C:\Users\manue\OneDrive\Escritorio\6 Cuatrimestre\ESTANCIAS\pases_prevenci-n\PASE\PASE\Vistas\img\*"; DestDir: "{app}\img"; Flags: ignoreversion

[Icons]
Name: "{commondesktop}\Control de Pases"; Filename: "{app}\PASE.exe"; IconFilename: "{app}\img\logo.ico"

[Run]
Filename: "{app}\PASE.exe"; Description: "Iniciar Control de Pases"; Flags: nowait postinstall skipifsilent
