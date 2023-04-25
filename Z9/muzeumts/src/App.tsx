import React from "react";
import { Routes, Route, Link } from "react-router-dom";
import "bootstrap/dist/css/bootstrap.min.css";
import "./App.css";
import AddPracownik from "./components/AddPracownik";
import Pracownik from "./components/Pracownik";
import PracownicyList from "./components/PracownicyList";
const App: React.FC = () => {
  return (
    <div>
      <nav className="navbar navbar-expand navbar-dark bg-dark">
        <a href="/pracownik" className="navbar-brand">
          MARKOKODER
        </a>
        <div className="navbar-nav mr-auto">
          <li className="nav-item">
            <Link to={"/pracownik"} className="nav-link">
              Pracownik
            </Link>
          </li>
          <li className="nav-item">
            <Link to={"/add"} className="nav-link">
              Dodaj
            </Link>
          </li>
        </div>
      </nav>
      <div className="container mt-3">
        <Routes>
          <Route path="/" element={<PracownicyList/>} />
          <Route path="/pracownik" element={<PracownicyList/>} />
          <Route path="/add" element={<AddPracownik/>} />
          <Route path="/pracownik/:pracownikId" element={<Pracownik/>} />
        </Routes>
      </div>
    </div>
  );
}
export default App;