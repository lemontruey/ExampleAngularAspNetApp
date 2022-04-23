import { UserType } from "./user-type";

export class User {
    id?: number;
    name?: string;
    login?: string;
    password?: string;
    userType?: UserType;
    lastVisitDate?: Date;
}