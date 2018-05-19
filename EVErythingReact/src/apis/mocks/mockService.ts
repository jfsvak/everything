import configs from '../../configs';

export const enum jsonTypes {
    dummyAPI = "dummyAPI"
}

//This method will return the json data based on their types above
export function getJson(type: jsonTypes): any {
    switch (type) {
        case jsonTypes.dummyAPI:
            let data: any;
            if (process.env.NODE_ENV !== 'production')
                data = require('./jsons/dummy.json');
            return new Promise((resolve, reject) => { simulateData(resolve, data, 200, configs.delay) });
    }
}

function simulateData(resolve: any, data: any, status: number, timeout: number): any {
    return setTimeout(() => { resolve(Object.assign({}, { status: status, data: data })); }, timeout);
}