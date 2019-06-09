import { navigate } from './navigateUtil';

//This interceptor gonna different status types and do different actions based on them
export function responseInterceptor(response: any, success: any, failed: any, history?: any): any {
    //We succeed
    if (response && response.status && (
        response.status === 200 ||
        response.status === 201 ||
        response.status === 204)) {

        //We return success.
        if (response.data)
            success(response.data);
        else
            success(response);
    }
    //We failed with redirect to login if the response comes as Unauthorized or Forbidden
    else if (response && response.status && (
        response.status === 401 ||
        response.status === 403)) {

        if (history)
            navigate(history, '/login', true);
        else
            failed(response);
    }
    //We have generic fail with callback
    else
        failed(response);
}