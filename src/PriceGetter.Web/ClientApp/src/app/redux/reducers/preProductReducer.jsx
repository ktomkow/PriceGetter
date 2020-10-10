import preProduct, { preProducts } from "../constants/action-types";

const initialState = {
    preProduct: null
  };
  

  function preProductReducer(state = initialState, action) {
    if (action.type === preProducts.SET_PREPRODDUCT) {
      return Object.assign({}, state, {
        preProduct: action.payload,
      });
    }
  
    return state;
  }
  
  export default preProductReducer;
  