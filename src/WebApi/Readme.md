# Web API for: deploy-impact-23-kpi-5

## Table of Contents
- [Introduction](#introduction)
- [Application](#application)
- [Project](#project)
- [Functionalities](#functionalities)
- [License](#license)


---


## **INTRODUCTION**
- WEB RESTful API Solution for ProJuventute KPI Management.

---


## **APPLICATION**
- This module aims to provide read-only access to the items below in order to allow customers to build their own reports,
- Integrate with their own websites, BI solutions or any solution able to read JSON files.
- This API accesses the following groups in a previously created database in Supabase:
  - Circles;
  - KPIs (two distinct tables);
  - Dashboards (two distinct tables);
  - Users (two distinct tables).

---


## **PROJECT**
   Implemented with.Net7, connecting directly with Supabase;
   Swagger is implemented to facilitate testing and integration. To access Swagger: https://kpi5.azurewebsites.net/swagger/index.html
   
 - #### Environment
   
   **GitHub**: Pipeline is implemented in Actions, automatically publishing the code in Microsoft Azure Web App.
   
   **Azure**: Linux Web App. Free Service, the first access may take a few seconds to build. https://kpi5.azurewebsites.net

---

- ### DATABASE with Supabase:
   Free database and authentication service.
     - The **database** uses Postgresql and provides access via RESTful API for CRUD data.
     - The diagram to build a similar database is available in the Main branch.

---


## **FUNCTIONALITIES**
- Every group has options to list multiple or single entries.
- To list multiple entries:
![image](https://github.com/WomenPlusPlus/deploy-impact-23-kpi-5/assets/56551789/f9fa5e26-3a72-494b-9b0a-78fc60ce6823)
- To list a single entry:
![image](https://github.com/WomenPlusPlus/deploy-impact-23-kpi-5/assets/56551789/f506ac4f-4d04-47f9-b0ad-5838e3f400f8)

- ### CIRCLES
![image](https://github.com/WomenPlusPlus/deploy-impact-23-kpi-5/assets/56551789/2839a3ea-0a93-402d-a95d-e243bc347c98)

- ### KPIs
![image](https://github.com/WomenPlusPlus/deploy-impact-23-kpi-5/assets/56551789/7ec2ffcb-706d-455d-83bb-a55a0d1d6926)
![image](https://github.com/WomenPlusPlus/deploy-impact-23-kpi-5/assets/56551789/bb035b4e-4df0-4953-aa9d-d321aaedd6ab)

- ### DASHBOARDS
![image](https://github.com/WomenPlusPlus/deploy-impact-23-kpi-5/assets/56551789/778845c2-160e-4867-8086-924d51278140)

- ### USERS
![image](https://github.com/WomenPlusPlus/deploy-impact-23-kpi-5/assets/56551789/087fbda4-29e9-4be3-a464-6460868afb43)


---
## **LICENSE**

- GNU General Public License v3.0 (GNU GPLv3)
[Link to license:](https://github.com/WomenPlusPlus/deploy-impact-23-kpi-5/blob/backendDevelopment/LICENSE) 


