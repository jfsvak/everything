import * as types from '../../models/constants/actionTypes';
// import { beginAjaxCall, ajaxCallEnded } from '../common/actions/ajaxStatusActions';
// import FittingsApi from './api';

// export function getFittings() {
//     return dispatch => {
//         dispatch(beginAjaxCall());
//         return FittingsApi.getFittings()
//             .then(resp => {
//                 dispatch({ type: types.GET_FITTINGS_SUCCESS, resp});
//                 dispatch(ajaxCallEnded());
//             })
//             .catch(resp => {
//                 dispatch({type: types.GET_ACCOUNTS_FAILURE});
//             });
//     }
// }

export const getFittings = () => ({
    type: types.GET_FITTINGS
});

export const getFittingsSuccess = resp => ({
    type: types.GET_FITTINGS_SUCCESS, 
    resp
});

export const getFittingsFailure = resp => ({
    type: types.GET_FITTINGS_FAILURE,
    resp
});