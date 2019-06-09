import configs from '../../configs';
import { getJsonAsPromise, jsonTypes } from '../common/api/mocks/mockService';

export function getFittings() {
    if (configs.type === 'LOCAL') {
        return getJsonAsPromise(jsonTypes.GET_SHOPPINGLISTS_API);
    }
    return new Promise((resolve, reject) => {
        resolve({data: []});
    });
}