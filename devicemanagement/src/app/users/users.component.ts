import { Component, OnInit } from '@angular/core';
import { UsersService } from 'src/app/shared/users.service';
import { NgForm } from '@angular/forms';
import { Users } from 'src/app/shared/users.model';
import { ToastrService } from 'ngx-toastr';



@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styles: [
  ]
})
export class UsersComponent implements OnInit {
  user = new Users();
  users: Users[] = [];
  isEdit = false;
  constructor(public service: UsersService,
    private toastr: ToastrService) {

  }

  ngOnInit(): void {
    this.get();
  }

  onSubmit() {
    if (this.isEdit)
      this.updateUser();
    else
      this.addUser();
  }

  addUser() {
    this.service.postUser(this.user).subscribe(
      res => {
        this.resetForm();
        this.toastr.success('Submitted successfully', 'Users register');
        this.get();
      },
      err => { console.log(err); }
    );
  }

  updateUser() {
    this.service.putUser(this.user).subscribe(
      res => {
        this.resetForm();
        this.toastr.success('Submitted successfully', 'Users register')
      },
      err => { console.log(err); }
    );
  }

  resetForm() {
    this.user = new Users();
    this.isEdit = false;
  }

  get() {
    this.service.getAll().subscribe(
      res => {
        this.users = res;
      },
      err => {
        this.toastr.error('Users couldnt be load');
      }

    )
  }

  onSelect(usr: Users) {
    this.user = usr;
    this.isEdit = true;
  }

  remove(event: any, usr: Users) {
    event.stopPropagation();
    var r = confirm("Do you want to delete the user?");
    if (r == false) {
      return;
    }

    this.service.deleteUser(usr.userId).subscribe(
      res => {
        this.users = this.users.filter(obj => obj !== usr);
        this.toastr.success('Deleted successfully')
      },
      err => {
        this.toastr.error('User couldnt be deleted');
      })
  }
}
