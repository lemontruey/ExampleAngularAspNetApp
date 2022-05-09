import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})
export class BaseService<T> {
    url = "/api/base/";
    constructor(private http: HttpClient) { }

    post(data: T) {
        return this.http.post<T>(this.url, data);
    }

    get() {
        return this.http.get<T[]>(this.url);
    }

    edit(id: number, data: T) {
        return this.http.put<T>(this.url + '?id=' + id, data);
    }

    delete(id: number) {
        return this.http.delete<T>(this.url + id);
    }
}