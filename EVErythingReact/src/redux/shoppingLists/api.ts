import configs from '../../configs';
import { getJson, jsonTypes } from '../common/api/mocks/mockService';

export function getFittings() {
    if (configs.type === 'LOCAL') {
        return getJson(jsonTypes.GET_SHOPPINGLISTS_API);
    }
    return new Promise((resolve, reject) => {
        resolve({data: []});
    });
}