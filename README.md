# QA_Automation_Framework_Playwright 🚀

<p align="center">
  <img src="https://img.shields.io/badge/.NET-8.0-blue?style=for-the-badge"/>
  <img src="https://img.shields.io/badge/Playwright-C%23-green?style=for-the-badge"/>
  <img src="https://img.shields.io/badge/NUnit-Test_Framework-red?style=for-the-badge"/>
  <img src="https://img.shields.io/badge/License-MIT-lightgrey?style=for-the-badge"/>
</p>

---
[![.NET Build & Tests](https://github.com/rustampulatov8/QA_Automation_Framework_Playwright/actions/workflows/dotnet-playwright.yml/badge.svg)](https://github.com/rustampulatov8/QA_Automation_Framework_Playwright/actions)
![GitHub last commit](https://img.shields.io/github/last-commit/rustampulatov8/QA_Automation_Framework_Playwright)
![GitHub stars](https://img.shields.io/github/stars/rustampulatov8/QA_Automation_Framework_Playwright?style=social)
![License: MIT](https://img.shields.io/badge/License-MIT-lightgrey)


## 📖 Overview

End-to-end automation framework built with **Playwright**, **C#**, and **NUnit**  
for validating UI and integration workflows in a sample **e-commerce checkout flow**.

This framework demonstrates:
- ✅ **Page Object Model** design for scalability  
- ✅ **Reusable components** for browser/session management  
- ✅ **HTML reports** with ExtentReports  
- ✅ **Automatic screenshots** on failure  
- ✅ **CI/CD-ready structure** (compatible with Azure DevOps, GitHub Actions, or TeamCity)

---

## ⚙️ How to Run

```bash
dotnet restore
playwright install
dotnet test

