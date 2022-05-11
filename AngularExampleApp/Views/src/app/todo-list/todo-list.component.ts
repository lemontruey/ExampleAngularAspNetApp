import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { TodoDialogComponent } from './todo-dialog/todo-dialog.component';

@Component({
    selector: 'app-todo-list-button',
    templateUrl: './todo-list.component.html',
    styleUrls: ['./todo-list.component.scss']
})
export class TodoListComponent implements OnInit {

    constructor(private dialog: MatDialog) { }

    ngOnInit(): void { }
    openToDoList() {
        this.dialog
            .open(TodoDialogComponent, {
                width: '30%'
            });
    }
}
