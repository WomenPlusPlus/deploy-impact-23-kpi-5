// import React from "react";
// import {
//   Route,
//   BrowserRouter as Router,
//   Routes,
//   useNavigate,
// } from "react-router-dom";
// import EconomistLandingPage from "./src/components/EconomistLandingPage";
// import GatekeeperLandingPage from "./src/components/GatekeeperLandingPage";
// import Form from "./src/components/Form";
// import AuthenticationPage from "./src/components/AuthenticationPage";
// import NotFoundPage from "./src/components/NotFoundPage"; // Make sure to import NotFoundPage

// function App() {
//   const navigate = useNavigate();

//   return (
//     <Router>
//       <div>
//         <Routes>
//           <Route
//             path="/form"
//             element={
//               auth.firstLoginTimestamp ? <Form /> : navigate("/economist")
//             }
//           />
//           <Route path="/economist" element={<EconomistLandingPage />} />
//           <Route path="/gatekeeper" element={<GatekeeperLandingPage />} />
//           <Route path="/authentication" element={<AuthenticationPage />} />
//           <Route path="/*" element={<NotFoundPage />} />
//         </Routes>
//       </div>
//     </Router>
//   );
// }

// export default App;
