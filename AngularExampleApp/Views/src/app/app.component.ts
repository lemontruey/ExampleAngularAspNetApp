import { UserApiService } from './services/user.api.service';
import { User } from './models/user';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator} from '@angular/material/paginator';
import { MatSort} from '@angular/material/sort';
import { MatTableDataSource} from '@angular/material/table';
import { DialogComponent } from './dialogs/user-dialog/dialog.component';
import { UserTypeComponent } from './user-type/user-type.component';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
    displayedColumns: string[] = ['name', 'login', 'password', 'lastVisitDate', 'userTypeName', 'action'];
    dataSource !: MatTableDataSource<User>;

    @ViewChild(MatPaginator) paginator !: MatPaginator;
    @ViewChild(MatSort) sort !: MatSort;

    constructor(private dialog: MatDialog, private apiService: UserApiService) {}

    ngOnInit(): void {
        this.getAllUsers();
    }

    openUserDialog() {
        this.dialog
            .open(DialogComponent, {
                width: '30%'                
            })
            .afterClosed()
            .subscribe((state) => {
                if (state === 'save') {
                    this.getAllUsers();
                }
            });
    }

    openUserTypeDialog() {
        this.dialog
            .open(UserTypeComponent, {
                width: '30%'
            })
            .afterClosed()
            .subscribe((state) => {
                this.getAllUsers();
            });
    }

    getAllUsers() {
        this.apiService.get()
            .subscribe({
                next: (response) => {
                    this.dataSource = new MatTableDataSource(response);
                    this.dataSource.paginator = this.paginator;
                    this.dataSource.sort = this.sort;
                },
                error: (err) => {
                    console.log("Error while fetching:" + err);
                }
            });
    }

    editUser(row: User) {
        this.dialog
            .open(DialogComponent, {
                width: '30%',                
                data: row
            })
            .afterClosed()
            .subscribe((state) => {
                if (state === 'update') {
                    this.getAllUsers();
                }
            });
    }

    deleteUser(id: number) {
        if (confirm('Are you sure about that?')) {
            this.apiService
                .delete(id)
                .subscribe({
                        next: () => {
                        alert('Deleted successfully');
                        this.getAllUsers();
                    },
                        error: (err) => {
                        console.log("Error while fetching:" + err);
                    }
                });
        }
    }

    applyFilter(event: Event) {
        const filterValue = (event.target as HTMLInputElement).value;
        this.dataSource.filter = filterValue.trim().toLowerCase();

        if (this.dataSource.paginator) {
            this.dataSource.paginator.firstPage();
        }
    }
}
