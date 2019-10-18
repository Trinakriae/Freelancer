import { ICustomerSummary, IUserSummary } from ".";

export interface IProject {
    id: number,
    name: string,
    description: string,
    customer: ICustomerSummary
    user: IUserSummary
}