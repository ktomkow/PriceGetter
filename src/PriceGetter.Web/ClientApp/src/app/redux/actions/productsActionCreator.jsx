import { PRODUCTS_ACTIONS } from '../constants/action-types';

import axios from 'axios';

export function getProducts() {
  return function (dispatch) {
    console.log('Request');
    setTimeout(() => {
      axios
        .get('/api/product')
        .then(function (response) {
          const payload = response.data;
          dispatch({
            type: PRODUCTS_ACTIONS.GET_ALL_PRODUCTS,
            payload: payload,
          });
        })
        .catch(function (error) {
          console.error(error);
        });
    }, 500);
  };
}

export function clearProducts() {
  return function (dispatch) {
    dispatch({ type: PRODUCTS_ACTIONS.CLEAR_PRODUCTS });
  };
}

export const getProduct = (productId, dispatch) => {
  setTimeout(() => {
    axios
      .get(`/api/product/uniquePrices/${productId}`)
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
      .then(function () {});
  }, 100);
};

export const updateSearchBox = (searchExpression) => (dispatch, getState) => {
  return dispatch({
    type: PRODUCTS_ACTIONS.UPDATE_PRODUCTS_SEARCHBOX,
    payload: { searchExpression: searchExpression },
  });
};

export const getMonthStatistics = (productId, dispatch) => {
  axios
    .get(`/api/statistics/months/${productId}`)
    .then(function (response) {
      const payload = response.data;
      dispatch({
        type: PRODUCTS_ACTIONS.GET_MONTH_STATISTICS,
        payload: payload,
      });
    })
    .catch(function (error) {
      console.error(error);
    });
};
