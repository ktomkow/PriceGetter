import { PRE_PRODUCTS_ACTIONS } from "../constants/action-types";

import { toBase64 } from "../../services/encodingService";

import axios from "axios";

export const getPreproduct = (link, dispatch) => {
  const encodedUrl = toBase64(link);
  gettingDataStarted(dispatch);
  setTimeout(() => {
    axios
      .get(`/api/preProduct/${encodedUrl}`)
      .then(function (response) {
        const payload = response.data;
        dispatch({
          type: PRE_PRODUCTS_ACTIONS.GET_PRE_PRODUCT_BY_URL,
          payload: payload,
        });
      })
      .catch(function (error) {
        console.error(error);
      })
      .then(function () {
        gettingDataCompletedOrFailed(dispatch);
      });
  }, 500);
};

export const gettingDataStarted = (dispatch) => {
  dispatch({ type: PRE_PRODUCTS_ACTIONS.GETTING_PREPRODUCT_IN_PROGRESS_START });
};

export const gettingDataCompletedOrFailed = (dispatch) => {
  dispatch({ type: PRE_PRODUCTS_ACTIONS.GETTING_PREPRODUCT_IN_PROGRESS_END });
};

export const createProduct = (preProduct, dispatch) => {
  creatingProductStarted(dispatch);
  axios
    .post("/api/product", preProduct)
    .then(function (response) {
      console.log(response);
      alert(response);
      dispatch({
        type: PRE_PRODUCTS_ACTIONS.CREATE_PRODUCT_SUCCESS
      });
    })
    .catch(function (error) {
      console.log(error);
      alert(error);
      dispatch({
        type: PRE_PRODUCTS_ACTIONS.CREATE_PRODUCT_FAIL
      });
    })
    .then(function () {
      creatingProductCompletedOrFailed(dispatch);
    });
};

export const creatingProductStarted = (dispatch) => {
  dispatch({ type: PRE_PRODUCTS_ACTIONS.CREATE_PRODUCT_IN_PROGRESS_START });
};

export const creatingProductCompletedOrFailed = (dispatch) => {
  dispatch({ type: PRE_PRODUCTS_ACTIONS.CREATE_PRODUCT_IN_PROGRESS_END });
};