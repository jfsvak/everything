import initialState from "./initialState";
import * as types from '../../models/constants/actionTypes';
import { combineReducers } from 'redux';

function fittingsById(state = initialState.byId, action) {
    switch(action.type) {
        case types.GET_FITTINGS_SUCCESS:
            // do magic here
        case types.GET_FITTINGS_FAILURE:
        default:
            return state;
    }
}

function allFittings(state = initialState.allIds, action) {
    switch(action.type) {
        case types.GET_FITTINGS_SUCCESS:
            // do magic here
        case types.GET_FITTINGS_FAILURE:
        default:
            return state;
    }
}

export default combineReducers({
    byId: fittingsById,
    allIds: allFittings
})