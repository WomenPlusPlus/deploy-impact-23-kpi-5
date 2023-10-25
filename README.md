# deploy-impact-23-kpi-5

## Table of Contents
- [Introduction](#introduction)
- [Application](#application)
- [Project](#project)
- [Functionalities](#functionalities)


---


## **INTRODUCTION**
- WEB APP Solution for ProJuventude KPI Management.

---


## **APPLICATION**

Web Application to be used as a single source for:
- **REPORTS**: Can be added, updated and visualized;
- **KPIs**: Can be set and adjusted as needed;
- **INTEGRATION** with external tools via REST API to build customized reports based on standardized data.
- The App provides graphics based on best practices, providing standardization, and facilitating understanding and decision-making.


---

## **PROJECT**

- ### Frontend:
 - [Main Branch](https://github.com/WomenPlusPlus/deploy-impact-23-kpi-5)
 - << text >>

--

- ### Flask Web API (Graphics management)
 - [FlaskWebApi Branch](https://github.com/WomenPlusPlus/deploy-impact-23-kpi-5/tree/FlaskWebApi)
 
  - #### Project
   Implemented with Python, connecting directly with Supabase;
   
   
 - #### Environment
   **GitHub**: Pipeline is implemented in Actions, automatically publishing the code in Microsoft Azure Web App.
   **Azure**: Linux Web App. Free Service, the first access may take a few seconds to build. https://kpi5graphics.azurewebsites.net

--

- ### REST Web API (Backend database read-only access)
 - [BackendDevelopment Branch](https://github.com/WomenPlusPlus/deploy-impact-23-kpi-5/tree/backendDevelopment)
   
 - #### Project
   Implemented with.Net7, connecting directly with Supabase;
   Swagger is implemented to facilitate testing and integration. To access Swagger: https://kpi5.azurewebsites.net/swagger/index.html
   
 - #### Environment
   **GitHub**: Pipeline is implemented in Actions, automatically publishing the code in Microsoft Azure Web App.
   **Azure**: Linux Web App. Free Service, the first access may take a few seconds to build. https://kpi5.azurewebsites.net

---

## **FUNCTIONALITIES**

<< text >>
