import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../models/user';

@Injectable({
    providedIn: 'root'
})
export class UserApiService {

    url = "/api/users";
    constructor(private http: HttpClient) { }

    post(userData: User) {
        return this.http.post<User>(this.url, userData);
    }

    get() {
        return this.http.get<User[]>(this.url);
    }

    edit(id: number, userData: User) {
        return this.http.put<User>(this.url + id, userData);
    }

    delete(id: number) {        
        return this.http.delete<User>(this.url + id);
    }
}
