import accountsApi from '../apis/accountsApi';
import * as types from '../models/constants/actionTypes';

export function getAccounts() {
    return dispatch => {
        //dispatch()
        console.log("In accountsActions.getAccounts: ");
        return accountsApi.getAccounts()
            .then(resp => {
                console.log(types.GET_ACCOUNTS_ACTION_SUCCESS + " callback", resp);
                dispatch({ type: types.GET_ACCOUNTS_ACTION_SUCCESS, resp })
            })
            .catch(resp => dispatch({ type: types.GET_ACCOUNTS_ACTION_FAILURE, resp }));
    };
}