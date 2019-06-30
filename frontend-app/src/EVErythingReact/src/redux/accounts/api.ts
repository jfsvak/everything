import { isLocal } from '../../configs';
import { getJsonAsPromise, jsonTypes, getPromise } from '../common/api/mocks/mockService';

class accountsApi {
    static addAccount(name: string) {
        if (isLocal()) {
            return getPromise({ "name": name, characterIds: [] });
        }
        return {};
    }

    static getAccounts() {
        if (isLocal()) {
            return getJsonAsPromise(jsonTypes.GET_ACCOUNTS_API);
        }
        return new Promise((resolve, reject) => {
            resolve({data: []});
        });
    }
}

export default accountsApi;