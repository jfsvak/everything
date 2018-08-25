import configs from '../../../configs';
//APIs
import { getJson, jsonTypes } from './mocks/mockService';
//import { CasecontrollerApi, CustomercontrollerApi } from './generated/api';

const dummyListData = () => {
    console.log('im calling dummy api');
    if (configs.type === 'LOCAL') {
        return getJson(jsonTypes.dummyAPI);
    }
    else {
        //let customerApi = new CustomercontrollerApi();
        //return customerApi.listCasesByCustomerNumberUsingGET(customerId, caseType)
    }
}

class dummyApi {
    static dummyList() {
        return dummyListData();
    }
}

export default dummyApi;