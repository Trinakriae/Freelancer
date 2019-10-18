import * as _ from "lodash";

import { IRequestWrapper, IServiceParameters } from '../interfaces/shared';
import { HttpMethodsEnum } from '../enums';
import { PostParameters } from '../classes';
import { sendBusinessRequestAsync } from '../utils/restFunctions';

export const invoiceAllocateTimes = (idUser: number, onSuccess: any, onError: (xhr: JQuery.jqXHR<any>, status: JQuery.Ajax.ErrorTextStatus) => void, parameters?: IServiceParameters) => {
    let hasCallbackParams: boolean = parameters ? parameters.callbackParameters != undefined : false;
    let callbackParameters = hasCallbackParams ? parameters!.callbackParameters : undefined;
    let hasKeyValueParams: boolean = parameters ? parameters.keyValueParameters != undefined : false;
    let keyValueParameters = hasKeyValueParams ? parameters!.keyValueParameters : undefined;

    let postParams: PostParameters = new PostParameters();
    postParams.Post = {
        ...(hasKeyValueParams ? keyValueParameters! : {})
    }

    let request: IRequestWrapper = {
        type: HttpMethodsEnum.POST,
        url: `/user/${idUser}/allocatedTimes/search`,
        data: JSON.stringify(postParams.Post),
        onSuccess: hasCallbackParams ? (response) => onSuccess(response, parameters!.callbackParameters!) : (response) => onSuccess(response),
        onError: (xhr, status) => onError(xhr, status)
    }
    sendBusinessRequestAsync(request);
}