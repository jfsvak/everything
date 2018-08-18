import * as types from '../../models/constants/actionTypes';
import initialState from '../initialState';

export default function accountsReducer(state = initialState.accounts, action) {
    // console.log("accountsReducer action: ", action);
    // console.log("accountsReducer state: ", state);

    switch(action.type) {
        case types.ADD_CHARACTER_SUCCESS:
            console.log("!!! NOT IMPLEMENTED !!! Add the character id to the account:", action);
            return state;
        case types.ADD_ACCOUNT_SUCCESS:
            console.log("In accountsReducer.ADD_ACCOUNT_SUCCESS: action.resp", action.resp);
            console.log("In accountsReducer.ADD_ACCOUNT_SUCCESS: action.resp", action.resp.data);
            return [...state, action.resp.data];
        case types.GET_ACCOUNTS_SUCCESS:
            console.log("In accountsReducer.GET_ACCOUNTS_SUCCESS: action.resp", action.resp);
            console.log("In accountsReducer.GET_ACCOUNTS_SUCCESS: action.resp.data", action.resp.data);
            return action.resp.data;
        case types.GET_ACCOUNTS_FAILURE:
            console.log("In accountsReducer.GET_ACCOUNTS_FAILURE: ", state);
            return state;
        default:
            return state;
    }
}