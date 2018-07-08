import configs from '../configs';

import { getJson, jsonTypes, getPromise } from './mocks/mockService';

class accountsApi {
    static addAccount(name: string) {
        if (configs.type === 'LOCAL') {
            return getPromise({ "name": name, pilotIds: [] });
        }
        return {};
    }

    static getAccounts() {
        if (configs.type === 'LOCAL') {
            return getJson(jsonTypes.GET_ACCOUNTS_API);
        }
        return {};
    }
}

export default accountsApi;