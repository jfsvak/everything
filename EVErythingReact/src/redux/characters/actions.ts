import * as types from '../../models/constants/actionTypes';
import CharactersApi from './api';
import { beginAjaxCall, ajaxCallEnded } from '../common/actions/ajaxStatusActions';

export function removeCharacter(id: string) {
    return dispatch => {
        console.log("removeCharacter");
        dispatch(beginAjaxCall());
        return CharactersApi.removeCharacter(id)
            .then(resp => {
                dispatch({ type: types.REMOVE_CHARACTER_SUCCESS, id });
                dispatch(ajaxCallEnded());
            })
            .catch(resp => dispatch({ type: types.REMOVE_CHARACTER_FAILURE, resp }));
    }
}

export function getCharacters() {
    return dispatch => {
        console.log("getCharacters");
        dispatch(beginAjaxCall());
        return CharactersApi.getCharacters()
            .then(resp => {
                console.log("getCharacters.Response:", resp);
                dispatch({ type: types.GET_CHARACTERS_SUCCESS, resp});
                dispatch(ajaxCallEnded());
            })
            .catch(resp => dispatch({ type: types.GET_CHARACTERS_FAILURE, resp}));
    }
}