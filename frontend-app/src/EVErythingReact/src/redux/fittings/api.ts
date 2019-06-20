import configs from "../../configs";
import { getJsonAsPromise, jsonTypes } from '../common/api/mocks/mockService';

class FittingsApi {
    static getFittings() {
        if (configs.type === 'LOCAL') {
            return getJsonAsPromise(jsonTypes.GET_FITTINGS_API);
        }
        return new Promise((resolve, reject) => {
            resolve({data: []});
        });
    }
}

export default FittingsApi;