import * as types from '../models/constants/actionTypes';

export function addPilot(pilot, accountName: string) {
    return dispatch => {
        return dispatch({type: types.ADD_PILOT_SUCCESS, pilot, accountName });
    }
}