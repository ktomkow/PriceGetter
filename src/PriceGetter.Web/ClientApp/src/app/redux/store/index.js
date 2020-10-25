import { createStore, applyMiddleware, compose, combineReducers } from "redux";
import rootReducer from "../reducers/index";
import preProductReducer from "../reducers/preProductReducer";
import productsReducer from "../reducers/productsReducer";
import notificationsReducer from "../reducers/notificationReducer";
import { forbiddenWordsMiddleware } from "../../middleware/index";
import thunk from "redux-thunk";

const storeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;

const reducers = combineReducers({
  rootReducer,
  productsReducer,
  preProductReducer,
  notificationsReducer
});

const store = createStore(
  reducers,
  storeEnhancers(applyMiddleware(forbiddenWordsMiddleware, thunk))
);

export default store;
