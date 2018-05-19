import * as types from '../../models/constants/actionTypes';
import initialState from '../initialState';

export default function dummyReducer(state = initialState.dummyResponse, action) {
    switch (action.type) {
        case types.DUMMY_ACTION:
            return Object.assign({}, state, action.dummyResponse);
        case types.DUMMY_FAILED:
            return Object.assign({}, state, action.dummyResponse.response);
        default:
            return state;
    }
}
