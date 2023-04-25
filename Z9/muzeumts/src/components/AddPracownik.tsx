import React, { useState, ChangeEvent } from "react";
import PracownikDataService from "../services/PracownikService";
import IPracownikData from "../types/Pracownik";
import Pracownik from "./Pracownik";

const AddPracownik: React.FC = () => {
  const initialPracownikState = {
    pracownikId: null,
    imieP: "",
    nazwiskoP: "",
    pesel: "",
    plec: "",
    dataZatrudnienia: "",
    dataUrodzin: "",

  };
  const [pracownik, setPracownik] = useState<IPracownikData>(initialPracownikState);
  const [submitted, setSubmitted] = useState<boolean>(false);
  const handleInputChange = (event: ChangeEvent<HTMLInputElement>) => {
    const { name, value } = event.target;
    setPracownik({ ...pracownik, [name]: value });
  };
  const savePracownik = () => {
    var data = {
        //pracownikId: pracownik.pracownikId,
        imieP: pracownik.imieP,
        nazwiskoP: pracownik.nazwiskoP,
        pesel: pracownik.pesel,
        plec: pracownik.plec,
        dataZatrudnienia: pracownik.dataZatrudnienia,
        dataUrodzin: pracownik.dataUrodzin
    };
    PracownikDataService.create(data)
      .then((response: any) => {
        setPracownik({
          pracownikId: response.data.pracownikId,
          imieP: response.data.imieP,
          nazwiskoP: response.data.nazwiskoP,
          pesel: response.data.pesel,
          plec: response.data.plec,
          dataZatrudnienia: response.data.dataZatrudnienia,
          dataUrodzin: response.data.dataUrodzin,
        });
        setSubmitted(true);
        console.log(response.data);
      })
      .catch((e: Error) => {
        console.log(e);
      });
  };
  const newPracownik = () => {
    setPracownik(initialPracownikState);
    setSubmitted(false);
  };
  return (
    <div className="submit-form">
    {submitted ? (
        <div>
        <h4>Udalo sie dodac pracownika!</h4>
        <button className="btn btn-success" onClick={newPracownik}>
            Wroc
        </button>
        </div>
    ) : (
        <div>
        <div className="form-group">
            <label htmlFor="imieP">Imie Pracownika</label>
            <input
            type="text"
            className="form-control"
            id="imieP"
            required
            value={pracownik.imieP}
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
            value={pracownik.nazwiskoP}
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
            value={pracownik.pesel}
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
            value={pracownik.plec}
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
            value={pracownik.dataZatrudnienia}
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
            value={pracownik.dataUrodzin}
            onChange={handleInputChange}
            name="dataUrodzin"
            />
        </div>
        <button onClick={savePracownik} className="btn btn-success">
            Dodaj
        </button>
        </div>
    )}
    </div>
);
};
export default AddPracownik;