import axios from "axios";
export default axios.create({
  baseURL: "http://localhost:5000/api/v2/",
  headers: {
    "Content-type": "application/json"
  }
});