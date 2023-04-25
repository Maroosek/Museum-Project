import React, { useState, useEffect, ChangeEvent } from "react";
import { useParams, useNavigate } from 'react-router-dom';
import PracownikDataService from "../services/PracownikService";
import IPracownikData from "../types/Pracownik";

const Pracownik: React.FC = () => {
  const { pracownikId }= useParams();
  let navigate = useNavigate();
  const initialPracownikState = {
    pracownikId: null,
    imieP: "",
    nazwiskoP: "",
    pesel: "",
    plec: "",
    dataZatrudnienia: "",
    dataUrodzin: ""
  };
  const [currentPracownik, setCurrentPracownik] = useState<IPracownikData>(initialPracownikState);
  const [message, setMessage] = useState<string>("");
  const getPracownik = (pracownikId: string) => {
    PracownikDataService.get(pracownikId)
      .then((response: any) => {
        setCurrentPracownik(response.data);
        console.log(response.data);
      })
      .catch((e: Error) => {
        console.log(e);
      });
  };
  useEffect(() => {
    if (pracownikId)
      getPracownik(pracownikId);
  }, [pracownikId]);
  const handleInputChange = (event: ChangeEvent<HTMLInputElement>) => {
    const { name, value } = event.target;
    setCurrentPracownik({ ...currentPracownik, [name]: value });
  };
  
  const updatePracownik = () => {
    PracownikDataService.update(currentPracownik.pracownikId, currentPracownik)
      .then((response: any) => {
        console.log(response.data);
        setMessage("The pracownik was updated successfully!");
      })
      .catch((e: Error) => {
        console.log(e);
      });
  };
  const deletePracownik = () => {
    PracownikDataService.remove(currentPracownik.pracownikId)
      .then((response: any) => {
        console.log(response.data);
        navigate("/pracownik");
      })
      .catch((e: Error) => {
        console.log(e);
      });
  };
  return (
    <div>
    {currentPracownik ? (
      <div className="edit-form">
        <h4>Pracownik</h4>
        <form>
          <div className="form-group">
            <label htmlFor="imieP">Imie Pracownika</label>
            <input
            type="text"
            className="form-control"
            id="imieP"
            required
            value={currentPracownik.imieP}
            onChange={handleInputChange}
            name="imieP"
            />
        </div>
        <div className="form-group">
            <label htmlFor="nazwiskoP">Nazwisko Pracownika</label>
            <input
            type="text"
            className="form-control"
            id="nazwiskoP"
            required
            value={currentPracownik.nazwiskoP}
            onChange={handleInputChange}
            name="nazwiskoP"
            />
        </div>
        <div className="form-group">
            <label htmlFor="pesel">Pesel</label>
            <input
            type="text"
            className="form-control"
            id="pesel"
            required
            value={currentPracownik.pesel}
            onChange={handleInputChange}
            name="pesel"
            />
        </div>
        <div className="form-group">
            <label htmlFor="plec">plec</label>
            <input
            type="number"
            min="0" max="1"
            className="form-control"
            id="plec"
            required
            value={currentPracownik.plec}
            onChange={handleInputChange}
            name="plec"
            />
        </div>
        <div className="form-group">
            <label htmlFor="dataZatrudnienia">Data Zatrudnienia</label>
            <input
            type="text"
            className="form-control"
            id="dataZatrudnienia"
            required
            value={currentPracownik.dataZatrudnienia}
            onChange={handleInputChange}
            name="dataZatrudnienia"
            />
        </div>
        <div className="form-group">
            <label htmlFor="dataUrodzin">DataUrodzin</label>
            <input
            type="text"
            className="form-control"
            id="dataUrodzin"
            required
            value={currentPracownik.dataUrodzin}
            onChange={handleInputChange}
            name="dataUrodzin"
            />
        </div>
        </form>
    
        <button className="badge badge-danger mr-2" onClick={deletePracownik}>
          Delete
        </button>
        <button
          type="submit"
          className="badge badge-success"
          onClick={updatePracownik}
        >
          Update
        </button>
        <p>{message}</p>
      </div>
    ) : (
      <div>
        <br />
        <p>Please click on a Pracownik...</p>
      </div>
    )}
  </div>
  );
};
export default Pracownik;