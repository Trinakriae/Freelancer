import { IDictionary } from "./";

export interface IServiceParameters {
    keyValueParameters?: IDictionary<any>,
    callbackParameters?: IDictionary<string>
}