# Persian Subtitle UTF-8 Fixer

A C# Windows Forms utility for fixing Persian (Farsi) subtitle encoding issues in media players.  
This tool converts subtitle files to **UTF-8 with BOM**, allowing Persian text to display correctly across most video players.

---

## 📌 Problem

Many Persian subtitle files (e.g., `.srt`, `.ass`) are encoded incorrectly or lack a BOM, causing text to appear as broken characters or unreadable symbols in players like VLC, PotPlayer, or TV media players.

---

## ✅ Solution

This project provides a **batch-processing** solution that:

- Detects subtitle files in a directory or dropped onto the application
- Converts them to **UTF-8 with BOM**
- Preserves subtitle content and formatting
- Renames the original file with a `.corrupted` suffix for backup

---

## 🚀 Features

- Batch conversion of subtitle files
- Fixes Persian text display issues
- Simple and lightweight C# Windows Forms application
- No external dependencies
- Drag-and-drop support for easy usage

---

## 🏗 Project Structure

```text
Subtitle Fixer/                ← Root folder (contains solution & git files)
├── Subtitle Fixer.sln         ← Visual Studio solution file
├── README.md                  ← Project documentation
├── .gitignore                 ← Ignore build artifacts and VS files
├── .gitattributes
└── Subtitle Fixer/            ← Main project folder
    ├── Properties/            ← Visual Studio project properties
    ├── Resources/             ← Embedded resources (icons, images, etc.)
    ├── app.config             ← Application configuration
    ├── Form1.cs               ← Main Windows Form code
    ├── Form1.Designer.cs      ← Designer-generated code for Form1
    ├── Form1.resx             ← Form1 resources
    ├── Program.cs             ← Application entry point
    └── Subtitle Fixer.csproj  ← C# project file
```

---

## ⚙️ Installation

1. Clone the repository:

```bash
git clone https://github.com/mahdi76911/persian-subtitle-utf8-fixer.git
```

2. Open `Subtitle Fixer.sln` in Visual Studio
3. Build the project
4. Run `Subtitle Fixer.exe` from the output folder (`bin/Debug` or `bin/Release`)

---

## ▶️ Usage

1. Open the application.
2. Drag and drop subtitle files (`.srt` or `.ass`) onto the window.
3. The files will be automatically converted to UTF-8 with BOM.
4. Original files are renamed with `.corrupted` suffix for backup.

---

## 🖼 Screenshot

Below is a screenshot of the Persian Subtitle UTF-8 Fixer in action:

![App Screenshot](screenshots\app-screenshot.png)

> Drag and drop subtitle files onto the window to batch fix their encoding.

---

## 📜 Notes / Limitations

- Works on Windows with .NET Framework / .NET Core
- Original files are renamed to `.corrupted` for safety
- Currently supports only `.srt` and `.ass` subtitle files
- Older code style (uploaded retroactively)  

---

## 🔮 Future Improvements

- Auto-detect source encoding for more subtitle types
- Add CLI mode for command-line batch processing
- Cross-platform support
- Option to create backups instead of renaming originals

---

## 🧑‍💻 Technologies Used

- C#  
- Windows Forms  
- .NET Framework / .NET Core  
- System.IO for file handling  
- Encoding conversion (Windows-1256 → UTF-8 BOM)

---

## 🏷 GitHub Topics / Tags

```
csharp
dotnet
winforms
subtitle
encoding
utf8
persian
farsi
media-tools
```

---

## 👤 Author

Mahdi Bideh
