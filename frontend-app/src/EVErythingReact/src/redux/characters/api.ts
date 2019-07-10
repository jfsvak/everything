import configs from '../../configs';

import { getJsonAsPromise, jsonTypes, getPromise } from '../common/api/mocks/mockService';
import { EVEApi } from '../common/api/generated/api';

class CharactersApi {
    static getCharacters() {
        if (configs.type === 'LOCAL') {
            console.log('getting chars from LOCAL');
            return getJsonAsPromise(jsonTypes.GET_CHARACTERS_API);
        }
        console.log('getting chars from SERVICE');
        return new EVEApi().apiCharactersGet();
    }

    static removeCharacter(id: string) {
        if (configs.type === 'LOCAL') {
            return getPromise({});
        }
        return new EVEApi().apiCharactersByIdDelete(id);
    }
}

export default CharactersApi;