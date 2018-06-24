import * as types from '../../models/constants/actionTypes';
import initialState from '../initialState';

export default function accountsReducer(state = initialState.accounts, action) {
    console.log("accountsReducer action: ", action);
    console.log("accountsReducer state: ", state);

    switch(action.type) {
        case types.GET_ACCOUNTS_ACTION_SUCCESS:
            console.log("In accountsReducer.GET_ACCOUNTS_ACTION_SUCCESS: action.resp", action.resp);
            console.log("In accountsReducer.GET_ACCOUNTS_ACTION_SUCCESS: action.resp.data", action.resp.data);
            return state.concat(action.resp.data);
        case types.GET_ACCOUNTS_ACTION_FAILURE:
            console.log("In accountsReducer.GET_ACCOUNTS_ACTION_FAILURE: ", state);
            return state;
        default:
            return state;
    }
}