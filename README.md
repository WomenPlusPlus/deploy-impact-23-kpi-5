# deploy-impact-23-kpi-5

## Table of Contents
- [Introduction](#introduction)
- [Application](#application)
- [Project](#project)
- [Diagrams](#diagrams)
- [Functionalities](#functionalities)


---


## **INTRODUCTION**
- WEB APP Solution for ProJuventute KPI Management.

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

---

- ### Flask Web API (Graphics management)
 - [FlaskWebApi Branch](https://github.com/WomenPlusPlus/deploy-impact-23-kpi-5/tree/FlaskWebApi)
 
  - #### Project
   Implemented with Python, connecting directly with Supabase, returning data via REST access in JSON format to the Front End to plot graphics;
   
   
 - #### Environment
   **GitHub**: Pipeline is implemented in Actions, automatically publishing the code in Microsoft Azure Web App.
   **Azure**: Linux Web App. Free Service, the first access may take a few seconds to build. https://kpi5graphics.azurewebsites.net

---

- ### REST Web API (Backend database read-only access)
 - [BackendDevelopment Branch](https://github.com/WomenPlusPlus/deploy-impact-23-kpi-5/tree/backendDevelopment)
   
 - #### Project
   Implemented with.Net7, connecting directly with Supabase;
   Swagger is implemented to facilitate testing and integration. To access Swagger: https://kpi5.azurewebsites.net/swagger/index.html
   
 - #### Environment
   
   **GitHub**: Pipeline is implemented in Actions, automatically publishing the code in Microsoft Azure Web App.
   
   **Azure**: Linux Web App. Free Service, the first access may take a few seconds to build. https://kpi5.azurewebsites.net

---

- ### DATABASE with Supabase:
   Free database and authentication service.
     - The **database** uses Postgresql and provides access via RESTful API for CRUD data.
     - The **authentication** offers full support to be integrated directly in FrontEnd.

---

## **DIAGRAMS**

- ### KPI5 App Diagram
<img width="1018" alt="image" src="https://github.com/WomenPlusPlus/deploy-impact-23-kpi-5/assets/56551789/39e8dad4-2ded-40ff-b91a-b1408aa6b400">

- ### KPI5 Database Diagram (Supabase)
<img width="542" alt="image" src="https://github.com/WomenPlusPlus/deploy-impact-23-kpi-5/assets/56551789/18a1371e-619c-4eed-8582-3d330047966b">


---
## **FUNCTIONALITIES**

<< text >>
