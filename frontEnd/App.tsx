import {
  Route,
  BrowserRouter as Router,
  Routes,
  useNavigate,
} from "react-router-dom";
import { auth } from "./auth.ts";
import EconomistLandingPage from "./src/components/EconomistLandingPage";
import GatekeeperLandingPage from "./src/components/GatekeeperLandingPage";
import Form from "./src/components/Form";
import AuthenticationPage from "./src/components/AuthenticationPage";
import { useEffect } from "react";
import NotFoundPage from "./src/components/NotFoundPage.tsx";

function App() {
  const navigate = useNavigate();

  useEffect(() => {
    if (!auth.firstLoginTimestamp) {
      navigate("/economist");
    }
  }, []);

  return (
    <Router>
      <div>
        <Routes>
          <Route path="/form" element={<Form />} />
          <Route path="/economist" element={<EconomistLandingPage />} />
          <Route path="/gatekeeper" element={<GatekeeperLandingPage />} />
          <Route path="/*" element={<NotFoundPage />} />
          <Route path="/authentication" element={<AuthenticationPage />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;
