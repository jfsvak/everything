import * as fromCharacters from './characters/selectors';
import * as fromAccounts from './accounts/selectors';

export const getAllCharacters = (state) =>
    fromCharacters.getAllCharacters(state.characters);

export const getAllAccounts = (state) =>
    fromAccounts.getAllAccounts(state.accounts);