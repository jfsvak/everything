import * as fromCharacters from '../reducers/selectors/charactersSelectors';

export const getAllCharacters = (state) =>
    fromCharacters.getAllCharacters(state.characters);