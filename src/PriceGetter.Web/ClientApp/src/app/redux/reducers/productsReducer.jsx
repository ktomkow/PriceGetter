import { PRODUCTS_ACTIONS } from '../constants/action-types';

const initialState = {
  products: [],
  filteredProducts: [],
  singleProduct: {
    id: '',
    name: '',
    productImage: '',
    prices: [],
  },
  statistics: {
    months: [],
  },
  searchExpression: '',
};

function productsReducer(state = initialState, action) {
  if (action.type === PRODUCTS_ACTIONS.GET_ALL_PRODUCTS) {
    return Object.assign({}, state, {
      // the one commented below would actually add a new element to existing collection
      // products: [
      //     ...state.products,
      //     action.payload
      // ]
      products: action.payload,
      filteredProducts: action.payload.filter((x) =>
        x.name.toUpperCase().includes(state.searchExpression.toUpperCase())
      ),
    });
  }

  if (action.type === PRODUCTS_ACTIONS.CLEAR_PRODUCTS) {
    return Object.assign({}, state, {
      products: [],
      filteredProducts: [],
    });
  }

  if (action.type === PRODUCTS_ACTIONS.GET_PRODUCT) {
    return Object.assign({}, state, {
      singleProduct: action.payload,
    });
  }

  if (action.type === PRODUCTS_ACTIONS.GET_MONTH_STATISTICS) {
    return Object.assign({}, state, {
      statistics: { months: action.payload },
    });
  }

  if (action.type === PRODUCTS_ACTIONS.UPDATE_PRODUCTS_SEARCHBOX) {
    return Object.assign({}, state, {
      searchExpression: action.payload.searchExpression,
      filteredProducts: state.products.filter((x) =>
        x.name
          .toUpperCase()
          .includes(action.payload.searchExpression.toUpperCase())
      ),
    });
  }

  return state;
}

export default productsReducer;
