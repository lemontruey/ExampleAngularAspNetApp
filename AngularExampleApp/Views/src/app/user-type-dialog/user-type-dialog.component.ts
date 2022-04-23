import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { UserType } from '../models/user-type';
import { UserTypeApiService } from '../services/user-type-api.service';

@Component({
  selector: 'app-user-type-dialog',
  templateUrl: './user-type-dialog.component.html',
  styleUrls: ['./user-type-dialog.component.scss']
})
export class UserTypeDialogComponent implements OnInit {
    actionButtonName: string = 'Save';

    userForm !: FormGroup;

    constructor(
        private formBuilder: FormBuilder,
        private userTypeApiService: UserTypeApiService,
        private dialogRef: MatDialogRef<UserTypeDialogComponent>,
        @Inject(MAT_DIALOG_DATA) public editData: UserType
    ) { }

    ngOnInit(): void {
        this.userForm = this.formBuilder.group({
            userType: ['', Validators.required],
            isAllowEditing: [false, Validators.required]
        });

        if (this.editData) {
            this.actionButtonName = "Update";
            this.userForm.controls['userType'].setValue(this.editData.name);
            this.userForm.controls['isAllowEditing'].setValue(this.editData.isAllowEditing);
        }
    }

    addUserType() {
        if (this.editData) {
            this.updateUserType();
        } else {
            this.createUserType();
        }
    }

    private createUserType() {
        if (this.userForm.valid) {
            this.userTypeApiService
                .post(this.userForm.value)
                .subscribe({
                    next: (response) => {
                        alert("User added successfully");
                        this.dialogRef.close('save');
                    },
                    error: () => {
                        alert("Error while adding the user");
                    }
                });
        }
    }

    private updateUserType() {
        if (this.userForm.valid) {
            this.userTypeApiService
                .edit(this.editData.id!, this.userForm.value)
                .subscribe({
                    next: () => {
                        alert("User updated successfully");
                        this.userForm.reset();
                        this.dialogRef.close('update');
                    },
                    error: () => {
                        alert("Error while updating the user");
                    }
                });
        }
    }
}
