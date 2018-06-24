import configs from '../configs';

import { getJson, jsonTypes } from './mocks/mockService';

class accountsApi {
    static getAccounts() {
        if (configs.type === 'LOCAL') {
            return getJson(jsonTypes.GET_ACCOUNTS_API);
        }
        return {};
    }
}

export default accountsApi;