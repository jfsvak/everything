import * as types from '../../models/constants/actionTypes';
import initialState from '../initialState';
import { combineReducers } from '../../../node_modules/redux';

function accountsById(state = initialState.accounts.byId, action) {
    switch(action.type) {
        case types.ADD_CHARACTER_SUCCESS:
            console.log("!!! NOT IMPLEMENTED !!! Add the character id to the account:", action);
            return state;
        case types.ADD_ACCOUNT_SUCCESS:
            console.log("In accountsReducer.ADD_ACCOUNT_SUCCESS: action.resp", action.resp);
            console.log("In accountsReducer.ADD_ACCOUNT_SUCCESS: action.resp", action.resp.data);
            const account = {...action.account};
            const accountId = account.id;
            
            return {
                ...state, 
                [accountId]: account
            };
        case types.GET_ACCOUNTS_SUCCESS:
            console.log("In accountsReducer.GET_ACCOUNTS_SUCCESS: action.resp", action.resp);
            console.log("In accountsReducer.GET_ACCOUNTS_SUCCESS: action.resp.data", action.resp.data);
            // return action.resp.data;
            return action.resp.data.reduce(
                (accumulator, account) => ({ ...accumulator, [account.id]: account }),
                {}
            );
        case types.GET_ACCOUNTS_FAILURE:
            console.log("In accountsReducer.GET_ACCOUNTS_FAILURE: ", state);
            return state;
        default:
            return state;
    }
}

function allAccounts(state = initialState.accounts.allIds, action) {
    switch(action.type) {
        case types.ADD_ACCOUNT_SUCCESS:
        {
            return action.resp.data.reduce(
                (accumulator, account) => [...accumulator, account.id],
                []
            );
        }
        case types.GET_ACCOUNTS_SUCCESS:
            const accountId = action.account.id;
            return state.concat(accountId);
        case types.GET_ACCOUNTS_FAILURE:
        default:
            return state;
    }
}

export default combineReducers({
    byId: accountsById,
    allId: allAccounts
});