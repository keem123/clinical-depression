import axios from "axios";

const clinicService = axios.create({
  baseURL: "http://localhost:54675/api"
});

export const login = (data, OnSuccessCallback, OnErrorCallback) => {
  clinicService
    .get("/Accounts/Login", {
      params: {
        Username: data.username,
        Password: data.password
      },
      headers: { accept: "application/json" }
    })
    .then(
      res => {
        OnSuccessCallback(res.data);
      },
      err => {
        OnErrorCallback({
          title: err.message,
          content: JSON.stringify(err.response.data)
        });
      }
    );
};
