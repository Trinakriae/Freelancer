import { IInvoiceSummary } from "./";

export interface IInvoiceLine {
    id: number,
    description: string,
    amount: number
    invoice: IInvoiceSummary
}