import * as types from '../../models/constants/actionTypes';
import initialState from '../initialState';

function actionTypeEndsInSuccess(type) {
    return type.substring(type.length - 7) == '_ACTION';
}

export default function ajaxStatusReducer(state = initialState.ajaxCallsInProgress, action) {
    if (action.type == types.BEGIN_AJAX_CALL) {
        return state + 1;
    } else if (action.type == types.AJAX_CALL_ERROR || action.type == types.END_AJAX_CALL ||
        actionTypeEndsInSuccess(action.type)) {
        return state - 1;
    }

    return state;
}
