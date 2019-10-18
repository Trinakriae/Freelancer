import { IProject } from ".";

export interface IAllocatedTime {
    id: number,
    description: string,
    startDate: Date,
    endDate: Date,
    invoiced: boolean,
    project: IProject
}