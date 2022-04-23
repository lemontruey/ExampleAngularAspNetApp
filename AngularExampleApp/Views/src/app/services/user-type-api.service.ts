import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserType } from '../models/user-type';

@Injectable({
    providedIn: 'root'
})
export class UserTypeApiService {

    url = 'api/userType/';
    constructor(private http: HttpClient) { }

    post(userTypeData: UserType) {
        return this.http.post<UserType>(this.url, userTypeData);
    }

    get() {
        return this.http.get<UserType[]>(this.url)
    }

    edit(id: number, userTypeData: UserType) {
        return this.http.put<UserType>(this.url + id, userTypeData);
    }

    delete(id: number) {        
        return this.http.delete<UserType>(this.url + id);
    }
}
