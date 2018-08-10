import configs from '../configs';

import { getJson, jsonTypes, getPromise } from './mocks/mockService';
import { EVEApi } from './generated/api';

class CharactersApi {
    static getCharacters() {
        if (configs.type === 'LOCAL') {
            return getJson(jsonTypes.GET_CHARACTERS_API);
        }
        return new EVEApi().apiCharactersGet();
    }
}

export default CharactersApi;