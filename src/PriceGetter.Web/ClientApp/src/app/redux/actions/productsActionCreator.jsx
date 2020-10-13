import { PRODUCTS_ACTIONS } from "../constants/action-types";

import axios from "axios";

export function getProducts() {
  return function (dispatch) {
    console.log("Request");
    setTimeout(() => {
      axios
      .get("/api/product")
      .then(function (response) {
        const payload = response.data;
        dispatch({ type: PRODUCTS_ACTIONS.GET_ALL_PRODUCTS, payload: payload });
      })
      .catch(function (error) {
        console.error(error);
      });
    }, 1000);
  };
}
