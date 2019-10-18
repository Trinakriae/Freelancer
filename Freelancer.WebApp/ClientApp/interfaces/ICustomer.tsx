import { IUserSummary, IProjectSummary, IInvoiceSummary } from ".";

export interface ICustomer {
    id: number,
    name: string,
    user: IUserSummary,
    projects: IProjectSummary[],
    invoice: IInvoiceSummary[]
}