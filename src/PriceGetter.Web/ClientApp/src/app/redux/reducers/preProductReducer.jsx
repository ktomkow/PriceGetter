import { PRE_PRODUCTS_ACTIONS } from "../constants/action-types";

const initialState = {
  preProduct: null,
  gettingDataInProgress: false,
};

function preProductReducer(state = initialState, action) {
  if (action.type === PRE_PRODUCTS_ACTIONS.GET_PRE_PRODUCT_BY_URL) {
    return Object.assign({}, state, {
      preProduct: action.payload,
    });
  }

  if (
    action.type === PRE_PRODUCTS_ACTIONS.GETTING_PREPRODUCT_IN_PROGRESS_START
  ) {
    return Object.assign({}, state, {
      gettingDataInProgress: true,
    });
  }

  if (action.type === PRE_PRODUCTS_ACTIONS.GETTING_PREPRODUCT_IN_PROGRESS_END) {
    return Object.assign({}, state, {
      gettingDataInProgress: false,
    });
  }

  return state;
}

export default preProductReducer;
