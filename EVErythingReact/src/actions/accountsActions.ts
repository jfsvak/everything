import accountsApi from '../apis/accountsApi';
import * as types from '../models/constants/actionTypes';
import { beginAjaxCall, ajaxCallEnded } from './ajaxStatusActions';

export function addAccount(name: string) {
    return dispatch => {
        dispatch(beginAjaxCall());
        return accountsApi.addAccount(name)
            .then(resp => {
                dispatch({ type: types.ADD_ACCOUNT_SUCCESS, resp })
                dispatch(ajaxCallEnded());
            })
            .catch(resp => {
                dispatch({ type: types.ADD_ACCOUNT_FAILURE, resp })
                dispatch(ajaxCallEnded());
            });
    };
}

export function getAccounts() {
    return dispatch => {
        dispatch(beginAjaxCall());
        return accountsApi.getAccounts()
            .then(resp => {
                dispatch({ type: types.GET_ACCOUNTS_SUCCESS, resp })
                dispatch(ajaxCallEnded());
            })
            .catch(resp => {
                dispatch({ type: types.GET_ACCOUNTS_FAILURE, resp })
                dispatch(ajaxCallEnded());
            });
    };
}