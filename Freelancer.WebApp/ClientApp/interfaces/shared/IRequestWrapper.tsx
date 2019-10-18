export interface IRequestWrapper {
    type: string,
    url: string,
    traditional?: boolean,
    contentType?: any,
    processData?: boolean,
    dataType?: string,
    data?: any,
    onSuccess?: (response: any) => void,
    onError?: (xhr: JQuery.jqXHR, status: JQuery.Ajax.ErrorTextStatus) => any
    async?: boolean
}