import * as types from '../../models/constants/actionTypes';
import initialState from '../initialState';

export default function pilotsReducer(state = initialState.pilots, action) {
    switch(action.type) {
        case types.ADD_PILOT_SUCCESS:
            return [...state, action.pilot];
        case types.ADD_PILOT_FAILURE:
            return state;
        default:
            return state;
    }
}
