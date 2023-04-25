import React, { useState, useEffect, ChangeEvent } from "react";
import { Link } from "react-router-dom";
import PracownikDataService from "../services/PracownikService";
import IPracownikData from '../types/Pracownik';
//import Pracownik from "./Pracownik";

const PracownicyList: React.FC = () => {
  const [pracownik, setPracownik] = useState<Array<IPracownikData>>([]);
  const [CurrentPracownik, setCurrentPracownik] = useState<IPracownikData | null>(null);
  const [currentIndex, setCurrentIndex] = useState<number>(-1);
  const [searchpracownikId, setsearchpracownikId] = useState<string>("");
  useEffect(() => {
    retrievePracownicy();
  }, []);
  const onChangesearchpracownikId = (e: ChangeEvent<HTMLInputElement>) => {
    const searchpracownikId = e.target.value;
    setsearchpracownikId(searchpracownikId);
  };
  const retrievePracownicy = () => {
    PracownikDataService.getAll()
      .then((response: any) => {
        setPracownik(response.data);
        console.log(response.data);
      })
      .catch((e: Error) => {
        console.log(e);
      });
  };
  const refreshList = () => {
    retrievePracownicy();
    setCurrentPracownik(null);
    setCurrentIndex(-1);
  };
  const setActivePracownik = (Pracownik: IPracownikData, index: number) => {
    setCurrentPracownik(Pracownik);
    setCurrentIndex(index);
  };
  //const removeAllTutorials = () => {
  //  PracownikDataService.removeAll()
  //    .then((response: any) => {
  //      console.log(response.data);
  //      refreshList();
  //    })
  //    .catch((e: Error) => {
  //      console.log(e);
  //    });
  //};
  const findById = () => {
    PracownikDataService.findById(searchpracownikId)
      .then((response: any) => {
        setPracownik(response.data);
        setCurrentPracownik(null);
        setCurrentIndex(-1);
        console.log(response.data);
      })
      .catch((e: Error) => {
        console.log(e);
      });
  };
  return (
    <div className="list row">
    <div className="col-md-8">
      <div className="input-group mb-3">
        <input
          type="text"
          className="form-control"
          placeholder="Search by Id"
          value={searchpracownikId}
          onChange={onChangesearchpracownikId}
        />
        <div className="input-group-append">
          <button
            className="btn btn-outline-secondary"
            type="button"
            onClick={findById}
          >
            Szukaj
          </button>
        </div>
      </div>
    </div>
    <div className="col-md-6">
      <h4>Lista Pracownikow</h4>
      <ul className="list-group">
        {pracownik &&
          pracownik.map((pracownik, pracownikId) => (
            <li
              className={
                "list-group-item " + (pracownikId === currentIndex ? "active" : "")
              }
              onClick={() => setActivePracownik(pracownik, pracownikId)}
              key={pracownikId}
            >
              {pracownik.pracownikId}
            </li>
          ))}
      </ul>

    </div>
    <div className="col-md-6">
      {CurrentPracownik ? (
        <div>
          <h4>Pracowik</h4>
          <div>
            <label>
              <strong>Imie Pracownika:</strong>
            </label>{" "}
            {CurrentPracownik.imieP}
          </div>
          <div>
            <label>
              <strong>Nazwisko Pracownika:</strong>
            </label>{" "}
            {CurrentPracownik.nazwiskoP}
          </div>
          <div>
            <label>
              <strong>Pesel:</strong>
            </label>{" "}
            {CurrentPracownik.pesel}
          </div>
          <div>
            <label>
              <strong>Plec:</strong>
            </label>{" "}
            {CurrentPracownik.plec}
          </div>
          <div>
            <label>
              <strong>Data Zatrudnienia:</strong>
            </label>{" "}
            {CurrentPracownik.dataZatrudnienia}
          </div>
          <div>
            <label>
              <strong>Data Urodzin:</strong>
            </label>{" "}
            {CurrentPracownik.dataUrodzin}
          </div>
          <Link
            to={"/Pracownik/" + CurrentPracownik.pracownikId}
            className="badge badge-warning"
          >
            Edit
          </Link>
        </div>
      ) : (
        <div>
          <br />
          <p>Wybierz Pracownika</p>
        </div>
      )}
    </div>
  </div>
  )
};
export default PracownicyList;