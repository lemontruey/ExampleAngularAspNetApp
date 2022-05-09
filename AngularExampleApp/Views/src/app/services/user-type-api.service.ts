import { Injectable } from '@angular/core';
import { UserType } from '../models/user-type';
import { BaseService } from './base-service';

@Injectable({
    providedIn: 'root'
})    
export class UserTypeApiService extends BaseService<UserType>{
    override url = 'api/usertype/';
}
