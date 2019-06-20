import { beginAjaxCall, ajaxCallEnded } from "../common/actions/ajaxStatusActions";
import * as ShoppingListAPI from './api';
import * as types from '../../models/constants/actionTypes';

export function getShoppingLists() {
    return dispatch => {
        dispatch(beginAjaxCall());
        return ShoppingListAPI.getFittings()
            .then(resp => {
                dispatch({ type: types.GET_SHOPPINGLISTS_SUCCESS, resp});
                // dispatch(ajaxCallEnded());
            })
            .catch(resp => dispatch({ type: types.GET_SHOPPINGLISTS_FAILURE}));
    }
}