import { IProject } from "./";

export interface IAllocatedTimeSummary {
    id: number,
    description: string,
    startDate: Date,
    endDate: Date,
    invoiced: boolean,
}