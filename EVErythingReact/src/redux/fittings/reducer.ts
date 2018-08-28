import initialState from "./initialState";
import * as types from '../../models/constants/actionTypes';
import { combineReducers } from 'redux';

function fittingsById(state = initialState.byId, action) {
    console.log('action: ', action);
    switch(action.type) {
        case types.GET_FITTINGS_FAILURE:
            return {};
        case types.GET_FITTINGS_SUCCESS: {
            return action.resp.data.reduce(
                (accumulator, fitting) => ({ ...accumulator, [fitting.id]: fitting}),
                {}
            );
        }
        default:
            return state;
    }
}

function allFittings(state = initialState.allIds, action) {
    switch(action.type) {
        case types.GET_FITTINGS_FAILURE:
            return [];
        case types.GET_FITTINGS_SUCCESS: {
            return action.resp.data.reduce(
                (accumulator, fitting) => [...accumulator, fitting.id],
                []
            );
        }
        default:
            return state;
    }
}

export default combineReducers({
    byId: fittingsById,
    allIds: allFittings
})