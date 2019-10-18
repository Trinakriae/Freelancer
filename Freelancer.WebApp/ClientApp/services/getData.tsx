import * as _ from "lodash";

import { IRequestWrapper, IServiceParameters } from '../interfaces/shared';
import { HttpMethodsEnum } from '../enums';
import { SearchParameters } from '../classes';
import { sendBusinessRequestAsync } from '../utils/restFunctions';

export const getUserProjects = (idUser: number, onSuccess: any, onError: (xhr: JQuery.jqXHR<any>, status: JQuery.Ajax.ErrorTextStatus) => void, parameters?: IServiceParameters) => {
    let hasCallbackParams: boolean = parameters ? parameters.callbackParameters != undefined : false;

    let request: IRequestWrapper = {
        type: HttpMethodsEnum.GET,
        url: `/user/${idUser}/allocatedTimes/search`,
        onSuccess: hasCallbackParams ? (response) => onSuccess(response, parameters!.callbackParameters!) : (response) => onSuccess(response),
        onError: (xhr, status) => onError(xhr, status)
    }
    sendBusinessRequestAsync(request);
}

export const searchUserProjects = (idUser: number, onSuccess: any, onError: (xhr: JQuery.jqXHR<any>, status: JQuery.Ajax.ErrorTextStatus) => void, parameters?: IServiceParameters) => {
    let searchParams: SearchParameters = new SearchParameters();

    let hasCallbackParams: boolean = parameters ? parameters.callbackParameters != undefined : false;

    let request: IRequestWrapper = {
        type: HttpMethodsEnum.GET,
        url: `/user/${idUser}/allocatedTimes/search`,
        data: searchParams.SearchFor,
        onSuccess: hasCallbackParams ? (response) => onSuccess(response, parameters!.callbackParameters!) : (response) => onSuccess(response),
        onError: (xhr, status) => onError(xhr, status)
    }
    sendBusinessRequestAsync(request);
}

export const searchUserTimeRegistrations = (idUser: number, onSuccess: any, onError: (xhr: JQuery.jqXHR<any>, status: JQuery.Ajax.ErrorTextStatus) => void, parameters?: IServiceParameters) => {
    let searchParams: SearchParameters = new SearchParameters();

    let hasCallbackParams: boolean = parameters ? parameters.callbackParameters != undefined : false;

    let request: IRequestWrapper = {
        type: HttpMethodsEnum.GET,
        url: `/user/${idUser}/allocatedTimes/search`,
        data: searchParams.SearchFor,
        onSuccess: hasCallbackParams ? (response) => onSuccess(response, parameters!.callbackParameters!) : (response) => onSuccess(response),
        onError: (xhr, status) => onError(xhr, status)
    }
    sendBusinessRequestAsync(request);
}

export const getProjectsTimeRegistration = (idUser: number, onSuccess: any, onError: (xhr: JQuery.jqXHR<any>, status: JQuery.Ajax.ErrorTextStatus) => void, parameters?: IServiceParameters) => {
    let searchParams: SearchParameters = new SearchParameters();

    let hasCallbackParams: boolean = parameters ? parameters.callbackParameters != undefined : false;

    let request: IRequestWrapper = {
        type: HttpMethodsEnum.GET,
        url: `/user/${idUser}/allocatedTimes/search`,
        data: searchParams.SearchFor,
        onSuccess: hasCallbackParams ? (response) => onSuccess(response, parameters!.callbackParameters!) : (response) => onSuccess(response),
        onError: (xhr, status) => onError(xhr, status)
    }
    sendBusinessRequestAsync(request);
}