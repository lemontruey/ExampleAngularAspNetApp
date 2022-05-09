import { Injectable } from '@angular/core';
import { User } from '../models/user';
import { BaseService } from './base-service';

@Injectable({
    providedIn: 'root'
})
export class UserApiService extends BaseService<User> {
    override url = "/api/user/";
}
