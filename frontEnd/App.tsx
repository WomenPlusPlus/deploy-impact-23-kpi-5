// App.tsx
import React from "react";
import { BrowserRouter as Router } from "react-router-dom";
import AuthenticationPage from "./src/components/AuthenticationPage";
import LandingPage from "./src/components/LandingPage";

function App() {
  return (
    <Router>
      {/* <Route path="/authentication" element={<AuthenticationPage />} />
      <Route path="/landing" element={<LandingPage />} /> */}
      <AuthenticationPage />
    </Router>
  );
}

export default App;
