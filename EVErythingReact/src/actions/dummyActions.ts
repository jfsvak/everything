import dummyApi from '../apis/dummyApi';
import * as types from '../models/constants/actionTypes';
import { beginAjaxCall, ajaxCallError } from './ajaxStatusActions';

export default function dummyListAction() {
    return dispatch => {
        dispatch(beginAjaxCall());
        return dummyApi.dummyList()
            .then(dummyResponse => {
                dispatch({ type: types.DUMMY_ACTION, dummyResponse });
            })
            .catch(dummyResponse => {
                dispatch(ajaxCallError());
                dispatch({ type: types.DUMMY_FAILED, dummyResponse });
                console.log('ERROR ', dummyResponse);
            });
    };
}
