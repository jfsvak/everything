import * as types from '../../../models/constants/actionTypes';
import initialState from '../../initialState';

function actionTypeEndsInSuccess(type) {
    return type.substring(type.length - 8) === '_SUCCESS';
}

export default function ajaxStatusReducer(state = initialState.ajaxCallsInProgress, action) {
    console.log('ajaxStatusReducer: action: ', action);
    console.log('ajaxStatusReducer. reg exp: ', (action.type.match(/_SUCCESS/) || {}).input);

    switch(action.type) {
        case types.GET_FITTINGS:
        case types.BEGIN_AJAX_CALL:
            return state + 1;
        case types.AJAX_CALL_ERROR:
        case types.END_AJAX_CALL:
            return state - 1;
        case (action.type.match(/_SUCCESS/) || {}).input:
        case (action.type.match(/_FAILURE/) || {}).input:
            return state - 1;
        default:
            return state;
    }
}
