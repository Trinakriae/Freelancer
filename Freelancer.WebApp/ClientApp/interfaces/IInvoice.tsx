import { IProject, ICustomer, IAllocatedTimeSummary, IInvoiceLine } from "./";

export interface IInvoice {
    id: number,
    description: string,
    status: number,
    customer: ICustomer,
    allocatedTimes: IAllocatedTimeSummary[]
    invoiceLines: IInvoiceLine[]
}