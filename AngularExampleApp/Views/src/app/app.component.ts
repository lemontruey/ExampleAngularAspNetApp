import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { User } from './user/user';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    providers: [DataService]
})
export class AppComponent implements OnInit {

    user: User = new User();
    users: User[];
    tableMode: boolean = true;

    constructor(private dataService: DataService) { }

    ngOnInit() {
        this.loadUsers();
    }

    loadUsers() {
        this.dataService.getUsers()
            .subscribe((userData: User[]) => this.users = userData);
    }

    save() {
        if (this.user.id == null) {
            this.dataService.createUser(this.user)
                .subscribe((userData: User) => this.users.push(userData));
        } else {
            this.dataService.updateUser(this.user)
                .subscribe(data => this.loadUsers());
        }
        this.cancel();
    }
    editUser(u: User) {
        this.user = u;
    }
    cancel() {
        this.user = new User();
        this.tableMode = true;
    }
    delete(u: User) {
        this.dataService.deleteUser(u.id)
            .subscribe(data => this.loadUsers());
    }
    add() {
        this.cancel();
        this.tableMode = false;
    }
}