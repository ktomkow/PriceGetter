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
    }, 2500);
  };
}

export function clearProducts() {
  return function (dispatch) {
    dispatch({ type: PRODUCTS_ACTIONS.CLEAR_PRODUCTS });
  };
}

export const getProduct = (id, dispatch) => {
  setTimeout(() => {
    axios
      .get(`/api/product/uniquePrices/${id}`)
      .then(function (response) {
        const payload = response.data;
        dispatch({
          type: PRODUCTS_ACTIONS.GET_PRODUCT,
          payload: payload,
        });
      })
      .catch(function (error) {
        console.error(error);
      })
      .then(function () {
      });
  }, 1500);
};
