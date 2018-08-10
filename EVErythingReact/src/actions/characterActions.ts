import * as types from '../models/constants/actionTypes';
import CharactersApi from '../apis/charactersApi';

export function addCharacter(character: string) {
    return dispatch => {
        return dispatch({type: types.ADD_CHARACTER_SUCCESS, character });
    }
}

export function getCharacters() {
    return dispatch => {
        return CharactersApi.getCharacters()
            .then(resp => {
                console.log("getCharacters.Response:", resp);
                dispatch({ type: types.GET_CHARACTERS_SUCCESS, resp});
            })
            .catch(resp => dispatch({ type: types.GET_CHARACTERS_FAILURE, resp}));
    }
}