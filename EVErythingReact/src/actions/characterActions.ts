import * as types from '../models/constants/actionTypes';
import CharactersApi from '../apis/charactersApi';

export function removeCharacter(id: string) {
    return dispatch => {
        return CharactersApi.removeCharacter(id)
            .then(resp => {
                dispatch({ type: types.REMOVE_CHARACTER_SUCCESS, id });
            })
            .catch(resp => dispatch({ type: types.REMOVE_CHARACTER_FAILURE, resp }));
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