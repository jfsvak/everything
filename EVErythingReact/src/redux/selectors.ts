import * as fromCharacters from './selectors/charactersSelectors';
import * as fromAccounts from './selectors/accountsSelectors';

export const getAllCharacters = (state) =>
    fromCharacters.getAllCharacters(state.characters);

    export const getAllAccounts = (state) =>
    fromAccounts.getAllAccounts(state.accounts);