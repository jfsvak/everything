import configs from '../../configs';
//import { AccountViewModel } from './generated/api';

import { getJsonAsPromise, jsonTypes, getPromise } from '../common/api/mocks/mockService';

class accountsApi {
    static addAccount(name: string) {
        if (configs.type === 'LOCAL') {
            return getPromise({ "name": name, characterIds: [] });
        }
        return {};
    }

    static getAccounts() {
        if (configs.type === 'LOCAL') {
            return getJsonAsPromise(jsonTypes.GET_ACCOUNTS_API);
        }
        return new Promise((resolve, reject) => {
            resolve({data: []});
        });
    }
}

export default accountsApi;