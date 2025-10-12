# Product Requirements Document (PRD)
## Project: Markdown TOC Generator – Blazor WASM

---

### 1. Overview
The **Markdown TOC Generator** is a **single-page Blazor WebAssembly application** that allows users to input Markdown text and automatically generate a **Table of Contents (TOC)** based on its headings.  
The TOC can be viewed in Markdown or HTML format, copied, or inserted at the top of the document.  
All processing is done **client-side** for privacy and speed.

---

### 2. Goals
- Parse Markdown headings (`#`, `##`, `###`, etc.).
- Generate a nested Markdown TOC.
- Allow previewing TOC as rendered HTML.
- Provide “Copy TOC” and “Insert TOC” functionality.
- Fully client-side, no backend dependencies.

---

### 3. Non-Goals
- No full Markdown rendering beyond TOC.
- No authentication or user data storage in cloud.
- No external APIs or server communication.

---

### 4. Target Users
- Technical writers generating documentation.
- Developers maintaining Markdown README files.
- Students and bloggers organizing large notes.

---

### 5. Core Features
#### 5.1 Input
- Text area for Markdown input.
- Auto-detect headings (`#` to `######`).
- Real-time parsing on input change.

#### 5.2 Output
- Nested TOC in Markdown list format:
  ```
  - [Introduction](#introduction)
    - [Getting Started](#getting-started)
    - [Installation](#installation)
  ```
- Option to show rendered HTML preview.

#### 5.3 Actions
- **Build TOC**: Generate TOC from current input.
- **Insert TOC**: Insert generated TOC at top of Markdown input.
- **Copy TOC**: Copy TOC to clipboard.
- **Toggle Preview**: Switch between Markdown and HTML preview modes.

---

### 6. Technical Requirements
- **Framework:** Blazor WebAssembly (standalone).
- **Language:** C# (.NET 9).
- **Libraries:** None required; optional `Markdig` for rendering.
- **Storage:** LocalStorage optional for saving input text.
- **Hosting:** GitHub Pages or any static hosting provider.

---

### 7. UI/UX
| Section | Description |
|----------|--------------|
| Header | App title “Markdown TOC Generator” |
| Left Panel | Markdown input textarea |
| Right Panel | Generated TOC in Markdown and HTML preview |
| Footer | Buttons: Build TOC, Insert TOC, Copy TOC, Toggle Preview |

**Layout:** Responsive two-column grid (stacked on mobile).

---

### 8. Security
- 100% client-side operation.
- No data transmission.
- Clipboard write access only via browser permission.

---

### 9. Success Metrics
- Detects and lists all headings correctly.
- Generates nested indentation for subheadings.
- TOC copies successfully to clipboard.
- Works offline after first load.
- Loads and renders in under 2 seconds.

---

### 10. Example
**Input Markdown:**
```
# Project
## Installation
## Usage
### Command Line
### Web Interface
```

**Generated TOC (Markdown):**
```
- [Project](#project)
  - [Installation](#installation)
  - [Usage](#usage)
    - [Command Line](#command-line)
    - [Web Interface](#web-interface)
```

**Rendered HTML Preview:**
```html
<ul>
  <li><a href="#project">Project</a>
    <ul>
      <li><a href="#installation">Installation</a></li>
      <li><a href="#usage">Usage</a>
        <ul>
          <li><a href="#command-line">Command Line</a></li>
          <li><a href="#web-interface">Web Interface</a></li>
        </ul>
      </li>
    </ul>
  </li>
</ul>
```

---

### 11. Future Enhancements
- Option to include or exclude H1 headings.
- Support custom heading ID formats.
- Option to export TOC to `.md` file.
- Add drag-and-drop file input for Markdown files.
- Full Markdown preview integration via `Markdig`.

---

### 12. Example Use Case
A developer pastes a long `README.md` file into the app, generates a nested TOC, copies it, and pastes it back into the top of their documentation file before publishing.