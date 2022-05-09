import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { User } from '../../models/user';
import { UserType } from '../../models/user-type';
import { UserTypeApiService } from '../../services/user-type-api.service';
import { UserApiService } from '../../services/user.api.service';

@Component({
    selector: 'app-dialog',
    templateUrl: './dialog.component.html',
    styleUrls: ['./dialog.component.scss']
})
export class DialogComponent implements OnInit {
    actionButtonName: string = 'Save';
    userTypeList: UserType[] = [];

    userForm !: FormGroup;

    constructor(
        private formBuilder: FormBuilder,
        private userTypeApiService: UserTypeApiService,
        private userApiService: UserApiService,
        private dialogRef: MatDialogRef<DialogComponent>,
        @Inject(MAT_DIALOG_DATA) public editData: User
    ) { }

    ngOnInit(): void {
        this.getUserTypeNameList();        

        this.userForm = this.formBuilder.group({
            id: [0, Validators.required],
            name: ['', Validators.required],
            userTypeId: [1, Validators.required],
            userTypeName: ['', Validators.required],
            login: ['', Validators.required],
            password: ['', Validators.required],
            lastVisitDate: [Date, Validators.required]
        });

        if (this.editData) {
            this.actionButtonName = "Update";
            this.userForm.controls['id'].setValue(this.editData.id);
            this.userForm.controls['name'].setValue(this.editData.name);
            this.userForm.controls['login'].setValue(this.editData.login);
            this.userForm.controls['password'].setValue(this.editData.password);
            this.userForm.controls['lastVisitDate'].setValue(this.editData.lastVisitDate);
            this.userForm.controls['userTypeId'].setValue(this.editData.userTypeId);
            this.userForm.controls['userTypeName'].setValue(this.editData.userTypeName);
        }
    }

    addUser() {
        if (this.editData){
            this.updateUser();
        } else {
            this.createUser();
        }
    }

    private createUser() {
        if (this.userForm.valid ) {
            this.userApiService
                .post(this.userForm.value)
                .subscribe({
                    next: (response) =>  {
                        alert("User added successfully");
                        this.dialogRef.close('save');
                    },
                    error: () => {
                        alert("Error while adding the user");
                    }
                });
        }
    }

    private updateUser() {
        if (this.userForm.valid) {
            this.userForm.value.userTypeId = this.userTypeList.find(x => x.name == this.userForm.value.userTypeName)?.id;

            this.userApiService
                .edit(this.editData.id!, this.userForm.value)
                .subscribe({
                    next: () =>  {
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

    private getUserTypeNameList() {
        this.userTypeApiService
            .get()
            .subscribe({
                next: (response) => {
                    this.userTypeList = response;
                }
            });
    }
}
