import {
  ACCOUNT_CREATE,
  ACCOUNT_UPDATE,
  ACCOUNT_GET,
  ACCOUNT_LOGIN_SUCCESS,
  ACCOUNT_LOGIN_FAILED,
  ACCOUNT_DELETE
} from "../actions/types";

const initialState = {
  loggedIn: false,
  currentUser: null,
  message: ""
};
export default function processLogsReducer(state = initialState, action) {
  var stateCopy = Object.assign({}, state);
  switch (action.type) {
    case ACCOUNT_GET:
      return stateCopy;

    case ACCOUNT_LOGIN_SUCCESS:
      stateCopy.loggedIn = true;
      stateCopy.currentUser = action.payload.account;
      return stateCopy;

    case ACCOUNT_UPDATE:
      return stateCopy;

    case ACCOUNT_DELETE:
      return stateCopy;
    case ACCOUNT_CREATE:
      return stateCopy;

    case ACCOUNT_LOGIN_FAILED:
      stateCopy.loggedIn = false;
      stateCopy.message = action.payload.message;
      stateCopy.currentUser = null;
      return stateCopy;

    default:
      return state;
  }
}
