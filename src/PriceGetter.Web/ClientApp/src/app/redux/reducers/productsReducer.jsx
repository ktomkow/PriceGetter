import { PRODUCTS_ACTIONS } from "../constants/action-types";

const initialState = {
  products: [],
};

function productsReducer(state = initialState, action) {
  if (action.type === PRODUCTS_ACTIONS.GET_ALL_PRODUCTS) {
    return Object.assign({}, state, {
      // the one commented below would actually add a new element to existing collection
      // products: [
      //     ...state.products,
      //     action.payload
      // ]
      products: action.payload
    });
  }

  return state;
}

export default productsReducer;
