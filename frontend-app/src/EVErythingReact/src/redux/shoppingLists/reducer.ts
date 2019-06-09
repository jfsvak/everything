import initialState from "./initialState";
import * as types from '../../models/constants/actionTypes';
import { combineReducers } from 'redux';

function shoppingListsById(state = initialState.byId, action) {
    switch(action.type) {
        case types.GET_SHOPPINGLISTS_SUCCESS:
        case types.GET_SHOPPINGLISTS_FAILURE:
        default:
            return state;
    }
}

function allIds(state = initialState.allIds, action) {
    switch(action.type) {
        default:
            return state;
    }
}

export default combineReducers({
    byId: shoppingListsById,
    allIds: allIds
});