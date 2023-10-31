# deploy-impact-23-kpi-5

## Table of Contents
- [Introduction](#introduction)
- [Application](#application)
- [Project](#project)
- [Diagrams](#diagrams)
- [License](#license)


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
 - "src/FlaskGraphics" directory
 
  - #### Project
   Implemented with Python, connecting directly with Supabase, returning data via REST access in JSON format to the Front End to plot graphics;
   
   
 - #### Environment
   **GitHub**: Pipeline is implemented in Actions, automatically publishing the code in Microsoft Azure Web App.
   **Azure**: Linux Web App. Free Service, the first access may take a few seconds to build. https://kpi5graphics.azurewebsites.net
 
 - #### Frontend
  - Preliminary visualisations have been deployed (e.g. https://kpi5graphics.azurewebsites.net/generate_linechart/6a9d1286-0654-4c79-b247-6f558539ab8d, https://kpi5graphics.azurewebsites.net/generate_barchart/ & https://kpi5graphics.azurewebsites.net/generate_multibarchart/). The html files in the "src/FlaskGraphics/templates" directory have to be tweaked to achieve the desired dashboard design (see point below)
 
  - #### Visualisation
  - The "src/streamlit_dashboard" directory contains the code that has been deployed on the Streamlit Community Cloud (can be viewed at https://dashboard-kpi.streamlit.app/). This is the desired layout of the in-app data visualisation dashboard, which should be achieved by tweaking the html files in the "src/FlaskGraphics/templates" directory
  
---

- ### REST Web API (Backend database read-only access)
 - "src/WebApi" directory
   
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
<img width="1018" alt="KPI5 App Diagram" src="https://github.com/WomenPlusPlus/deploy-impact-23-kpi-5/assets/56551789/39e8dad4-2ded-40ff-b91a-b1408aa6b400">

- ### KPI5 Database Diagram (Supabase)
<img width="542" alt="KPI5 Database Diagram (Supabase)" src="https://github.com/WomenPlusPlus/deploy-impact-23-kpi-5/assets/56551789/18a1371e-619c-4eed-8582-3d330047966b">


---
## **LICENSE**

- GNU General Public License v3.0 (GNU GPLv3)
Link to license: [link](https://github.com/WomenPlusPlus/deploy-impact-23-kpi-5/blob/main/LICENSE)

---
