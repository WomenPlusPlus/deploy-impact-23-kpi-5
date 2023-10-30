import { Route, Routes } from "react-router-dom";
// import { auth } from "./auth.ts";
import EconomistLandingPage from "./src/components/EconomistLandingPage";
import GatekeeperLandingPage from "./src/components/GatekeeperLandingPage";
import Form from "./src/components/Form";
import AuthenticationPage from "./src/components/AuthenticationPage";
// import { useEffect } from "react";
import NotFoundPage from "./src/components/NotFoundPage.tsx";

function App() {
  // const navigate = useNavigate();

  // useEffect(() => {
  //   console.log("auth.firstLoginTimestamp:", auth.firstLoginTimestamp);

  //   if (!auth.firstLoginTimestamp) {
  //     navigate("/");
  //   }
  // }, []);

  return (
    <div>
      <Routes>
        <Route path="/" element={<AuthenticationPage />} />
        <Route path="/form" element={<Form />} />
        <Route path="/economist" element={<EconomistLandingPage />} />
        <Route path="/gatekeeper" element={<GatekeeperLandingPage />} />
        <Route path="/*" element={<NotFoundPage />} />
      </Routes>
    </div>
  );
}

export default App;
