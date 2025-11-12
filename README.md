# QA_Automation_Framework_Playwright 🚀

<p align="center">
  <img src="https://img.shields.io/badge/.NET-8.0-blue?style=for-the-badge"/>
  <img src="https://img.shields.io/badge/Playwright-C%23-green?style=for-the-badge"/>
  <img src="https://img.shields.io/badge/NUnit-Test_Framework-red?style=for-the-badge"/>
  <img src="https://img.shields.io/badge/License-MIT-lightgrey?style=for-the-badge"/>
</p>

[![CI](https://github.com/rustampulatov8/QA_Automation_Framework_Playwright/actions/workflows/dotnet-playwright.yml/badge.svg)](https://github.com/rustampulatov8/QA_Automation_Framework_Playwright/actions)
## 🧭 Overview
This project is an **end-to-end automation framework** built with **Playwright**, **C#**, and **NUnit**, designed to validate both **UI** and **API** workflows for a sample **e-commerce checkout flow**.

It reflects production-ready automation structure, suitable for enterprise QA environments, and integrates seamlessly into **CI/CD pipelines (GitHub Actions, Azure DevOps, TeamCity)**.

---

## 🧩 Features & Highlights

✅ **Page Object Model (POM)** – scalable design separating UI logic from test logic  
✅ **Reusable Components** – for browser and session management  
✅ **HTML Reporting** – with ExtentReports integration  
✅ **Automatic Screenshots** – captured on failure  
✅ **CI/CD-Ready** – runs Playwright tests headless in GitHub Actions  
✅ **API Testing** – using Playwright APIRequest and NUnit assertions  
✅ **Cross-Browser Support** – Chrome, Edge, Firefox  
✅ **Data-Driven Testing** – via NUnit TestCaseSource  
✅ **Error Recovery** – retry logic and intelligent wait handling

---
## 🧱 Project Structure
```
QA_Automation_Framework_Playwright/
├── Pages/ # Page Object classes (Home, Cart, Product)
├── Tests/ # NUnit test suites (Cart, Checkout, API)
├── Utilities/ # BrowserFactory, TestDataHelper, helpers
├── .editorconfig # Code style conventions
├── .gitignore # Ignored build/test artifacts
├── QA_Automation_Framework_Playwright.csproj
├── dotnet-playwright.yml # CI/CD workflow for GitHub Actions
└── README.md
```
---
[![.NET Build & Tests](https://github.com/rustampulatov8/QA_Automation_Framework_Playwright/actions/workflows/dotnet-playwright.yml/badge.svg)](https://github.com/rustampulatov8/QA_Automation_Framework_Playwright/actions)
![GitHub last commit](https://img.shields.io/github/last-commit/rustampulatov8/QA_Automation_Framework_Playwright)
![GitHub stars](https://img.shields.io/github/stars/rustampulatov8/QA_Automation_Framework_Playwright?style=social)
![License: MIT](https://img.shields.io/badge/License-MIT-lightgrey)

## ⚙️ How to Run Locally

## 📖 Overview
1️⃣ Clone the repo
```
git clone https://github.com/rustampulatov8/QA_Automation_Framework_Playwright.git
cd QA_Automation_Framework_Playwright
```
2️⃣ Install dependencies
```
dotnet restore
```
3️⃣ Install Playwright browsers
```
npx playwright install --with-deps
```
4️⃣ Run tests
```
dotnet test
```

End-to-end automation framework built with **Playwright**, **C#**, and **NUnit**  
for validating UI and integration workflows in a sample **e-commerce checkout flow**.
---
🧠 Skills Demonstrated

Automation Framework Design: Page Object Model & reusable architecture

Playwright Automation: Advanced waits, selectors, dialog handling

Continuous Integration: GitHub Actions workflow for .NET & Playwright

API Testing: HTTP request validation using Playwright API Context

Cross-Functional QA: End-to-end testing of web and backend flows

This framework demonstrates:
- ✅ **Page Object Model** design for scalability  
- ✅ **Reusable components** for browser/session management  
- ✅ **HTML reports** with ExtentReports  
- ✅ **Automatic screenshots** on failure  
- ✅ **CI/CD-ready structure** (compatible with Azure DevOps, GitHub Actions, or TeamCity)
Reporting & Debugging: ExtentReports and screenshots on failures

---
📊 CI/CD Integration

## ⚙️ How to Run
The .github/workflows/dotnet-playwright.yml pipeline runs automatically on every push or PR to the main branch.

```bash
dotnet restore
playwright install
dotnet test
```
It performs:

✅ Restore & build project

✅ Install Playwright browsers (headless)

✅ Run NUnit Playwright tests

✅ Upload test results (TRX or HTML) as artifacts

---
📄 License:
This project is released under the MIT License.

👨‍💻 Author:
Rustam Pulatov
💼 Senior QA Automation Engineer | C# | Playwright | NUnit | CI/CD | API Testing

