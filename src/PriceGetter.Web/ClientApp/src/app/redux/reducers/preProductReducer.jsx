import { PRE_PRODUCTS_ACTIONS } from "../constants/action-types";

const initialState = {
    preProduct: null
  };
  

  function preProductReducer(state = initialState, action) {
    if (action.type === PRE_PRODUCTS_ACTIONS.GET) {
      console.log("Payload:", action.payload)
      return Object.assign({}, state, {
        preProduct: action.payload,
      });
    }
  
    return state;
  }
  
  export default preProductReducer;
  