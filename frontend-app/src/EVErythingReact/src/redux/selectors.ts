import * as fromCharacters from './characters/selectors';
import * as fromAccounts from './accounts/selectors';
import * as fromFittings from './fittings/selectors';
import * as fromShoppingLists from './shoppingLists/selectors';

export const getAllCharacters = (state) =>
    fromCharacters.getAllCharacters(state.characters);

export const getAllAccounts = (state) =>
    fromAccounts.getAllAccounts(state.accounts);

export const getAllFittings = (state) => 
    fromFittings.getAllFittings(state.fittings);

export const getAllShoppingLists = (state) =>
    fromShoppingLists.getAllShoppingLists(state.shoppingLists);