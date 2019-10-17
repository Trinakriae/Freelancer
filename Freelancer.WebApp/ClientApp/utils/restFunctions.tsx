import * as $ from 'jquery';
import { IRequestWrapper } from '../interfaces/IRequestWrapper';

declare const CONFIG: any; 

export const sendBusinessRequestAsync = (request: IRequestWrapper) => {
    const { type, url, data, onSuccess, onError } = request;

    let serviceUrl = '';

    if (typeof CONFIG.BUSINESS_SERVICEURL !== 'undefined') {
        serviceUrl = CONFIG.BUSINESS_SERVICEURL;
    }

    sendRequestAsync(request, serviceUrl);
}


const sendRequestAsync = (request: IRequestWrapper, serviceUrl: string) => {
    const { type, url, data, onSuccess, contentType, processData, traditional, onError } = request;

    $.ajax(
        {
            type: type,
            url: `${serviceUrl}${url}`,
            contentType: contentType != undefined ? contentType : 'application/json',
            processData: processData != undefined ? processData : true,
            data: data,
            traditional: traditional != undefined ? traditional : false,
            crossDomain: true, //CORS
            cache: false,
            success: onSuccess,
            error: onError,
        }
    );
}




