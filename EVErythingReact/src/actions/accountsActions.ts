import accountsApi from '../apis/accountsApi';
import * as types from '../models/constants/actionTypes';

export function addAccount(name: string) {
    return dispatch => {
        console.log("In accountsActions.addAccount. Adding account name: ", name);
        return accountsApi.addAccount(name)
            .then(resp => {
                console.log(types.ADD_ACCOUNT_SUCCESS + " callback", resp);
                dispatch({ type: types.ADD_ACCOUNT_SUCCESS, resp })
            })
            .catch(resp => dispatch({ type: types.ADD_ACCOUNT_FAILURE, resp }));
    };
}

export function getAccounts() {
    return dispatch => {
        //dispatch()
        console.log("In accountsActions.getAccounts: ");
        return accountsApi.getAccounts()
            .then(resp => {
                console.log(types.GET_ACCOUNTS_SUCCESS + " callback", resp);
                dispatch({ type: types.GET_ACCOUNTS_SUCCESS, resp })
            })
            .catch(resp => dispatch({ type: types.GET_ACCOUNTS_FAILURE, resp }));
    };
}