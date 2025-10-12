# Markdown TOC Generator

A simple and elegant Blazor WebAssembly application that generates a Table of Contents (TOC) from Markdown headings.

## Features

- ✨ **Real-time Parsing**: Automatically detects headings from `#` to `######`
- 📋 **Multiple Output Formats**: View TOC in Markdown or HTML format
- 📝 **Easy Actions**: Build, Insert, and Copy TOC with one click
- 🎨 **Clean UI**: Beautiful gradient design with responsive layout
- 🚀 **100% Client-Side**: No server required, all processing happens in the browser
- 📱 **Mobile Friendly**: Responsive design that works on all devices

## Live Demo

The application provides:
- **Left Panel**: Markdown input textarea
- **Right Panel**: Generated TOC (switchable between Markdown and HTML preview)
- **Action Buttons**: Build TOC, Insert TOC, Copy TOC, Toggle Preview

## Usage

1. Paste your Markdown content into the left panel
2. Click "Build TOC" to generate the table of contents
3. Use "Toggle Preview" to switch between Markdown and HTML views
4. Click "Copy TOC" to copy the generated TOC to clipboard
5. Use "Insert TOC" to add the TOC at the top of your Markdown input

### Example

**Input:**
```markdown
# Project
## Installation
## Usage
### Command Line
### Web Interface
```

**Generated TOC:**
```markdown
- [Project](#project)
  - [Installation](#installation)
  - [Usage](#usage)
    - [Command Line](#command-line)
    - [Web Interface](#web-interface)
```

## Development

### Prerequisites

- .NET 9 SDK

### Running Locally

```bash
dotnet run
```

Then navigate to `http://localhost:5163` in your browser.

### Building for Production

```bash
dotnet publish -c Release
```

The output will be in `bin/Release/net9.0/publish/wwwroot/` and can be deployed to any static hosting service like GitHub Pages.

## Technology Stack

- **Framework**: Blazor WebAssembly (Standalone)
- **Language**: C# (.NET 9)
- **Styling**: Custom CSS with gradient design

## License

This project is open source and available under the MIT License.