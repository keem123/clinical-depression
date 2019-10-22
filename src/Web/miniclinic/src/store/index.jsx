import { createStore, combineReducers, applyMiddleware, compose } from "redux";

import { AccountReducer } from "./reducers";
import thunk from "redux-thunk";
const allReducers = combineReducers({ account: AccountReducer });

const allStoreEnchancers = compose(
  applyMiddleware(thunk),
  window.devToolsExtension && window.devToolsExtension()
);

const store = createStore(allReducers, allStoreEnchancers);

export default store;
