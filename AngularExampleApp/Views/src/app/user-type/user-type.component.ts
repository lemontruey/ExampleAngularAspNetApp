import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { UserTypeDialogComponent } from '../dialogs/user-type-dialog/user-type-dialog.component';
import { UserType } from '../models/user-type';
import { UserTypeApiService } from '../services/user-type-api.service';

@Component({
    selector: 'app-user-type',
    templateUrl: './user-type.component.html',
    styleUrls: ['./user-type.component.scss']
})
export class UserTypeComponent implements OnInit {
    displayedColumns: string[] = ['name', 'isAllowEditing', 'action'];
    dataSource !: MatTableDataSource<UserType>;

    @ViewChild(MatPaginator) paginator !: MatPaginator;
    @ViewChild(MatSort) sort !: MatSort;

    constructor(
        private dialog: MatDialog,
        private apiService: UserTypeApiService) { }

    ngOnInit(): void {
        this.getAllUserTypes();
    }

    openUserTypeDialog() {
        this.dialog
            .open(UserTypeDialogComponent, {
                width: '30%'
            })
            .afterClosed()
            .subscribe((state) => {
                if (state === 'save') {
                    this.getAllUserTypes();
                }
            });
    }

    getAllUserTypes() {
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

    editUserType(row: UserType) {
        this.dialog
            .open(UserTypeDialogComponent, {
                width: '30%',
                data: row
            })
            .afterClosed()
            .subscribe((state) => {
                if (state === 'update') {
                    this.getAllUserTypes();
                }
            });
    }

    deleteUserType(row: UserType) {
        if (confirm('Are you sure about that?')) {
            this.apiService
                .delete(row.id!)
                .subscribe({
                    next: () => {
                        alert('Deleted successfully');
                        this.getAllUserTypes();
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
