import { BrowserRouter, Routes, Route, Link } from "react-router-dom";
import Home from "./pages/Home";
import ProfileForm from "./pages/ProfileForm";
import Login from "./pages/Login";
import Signup from "./pages/Signup";

function App() {
  return (
    <BrowserRouter>
      <nav>
        <Link to="/">Home</Link> |{" "}
        <Link to="/profile">Create/Edit Profile</Link> |{" "}
        <Link to="/login">Login</Link> |{" "}
        <Link to="/signup">Sign Up</Link>
      </nav>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/profile" element={<ProfileForm />} />
        <Route path="/login" element={<Login />} />
        <Route path="/signup" element={<Signup />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;