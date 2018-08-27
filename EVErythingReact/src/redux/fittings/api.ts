import configs from "../../configs";
import { getJson, jsonTypes } from '../common/api/mocks/mockService';

class FittingsApi {
    static getFittings() {
        if (configs.type === 'LOCAL') {
            return getJson(jsonTypes.GET_FITTINGS_API);
        }
        return new Promise((resolve, reject) => {
            resolve({data: []});
        });
    }
}

export default FittingsApi;