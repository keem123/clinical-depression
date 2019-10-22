import {
  ACCOUNT_CREATE,
  ACCOUNT_UPDATE,
  ACCOUNT_GET,
  ACCOUNT_LOGIN_SUCCESS,
  ACCOUNT_LOGIN_FAILED,
  ACCOUNT_DELETE
} from "./types";

import { login as accountLogin } from "../service/clinicService";

export const login = data => dispatch => {
  accountLogin(
    data,
    resp => {
      if (resp.allow === false) {
        return dispatch({
          type: ACCOUNT_LOGIN_FAILED,
          payload: resp
        });
      } else {
        return dispatch({
          type: ACCOUNT_LOGIN_SUCCESS,
          payload: resp
        });
      }
    },
    err => {
      return dispatch({
        type: ACCOUNT_LOGIN_FAILED,
        payload: null
      });
    }
  );
};
