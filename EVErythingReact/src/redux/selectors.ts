import * as fromCharacters from '../redux/selectors/charactersSelectors';

export const getAllCharacters = (state) =>
    fromCharacters.getAllCharacters(state.characters);