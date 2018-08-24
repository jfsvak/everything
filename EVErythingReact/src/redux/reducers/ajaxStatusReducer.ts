import * as types from '../../models/constants/actionTypes';
import initialState from '../initialState';

function actionTypeEndsInSuccess(type) {
    return type.substring(type.length - 7) === '_ACTION';
}

export default function ajaxStatusReducer(state = initialState.ajaxCallsInProgress, action) {
    switch(action.type) {
        case types.BEGIN_AJAX_CALL:
            console.log("Hello*******");
            return state + 1;
        case types.AJAX_CALL_ERROR:
        case types.END_AJAX_CALL:
        case actionTypeEndsInSuccess(action.type):
            return state - 1;
        default:
            return state;
    }
}
