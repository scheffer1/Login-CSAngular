import { Component, OnInit } from '@angular/core';
import { UserService } from '../../shared/user.service';
import { ToastrService } from 'ngx-toastr';
import {FormControl, Validators} from '@angular/forms';
import {Router} from "@angular/router";
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {


  emailFormControl = new FormControl('', [Validators.required, Validators.email]);
  nameFormControl = new FormControl('', [Validators.required]);
  passwordFormControl = new FormControl('', [Validators.required, Validators.minLength(8)]);
  cpfFormControl = new FormControl('', [Validators.required, Validators.minLength(11)]);
  phoneFormControl = new FormControl('', [Validators.required]);
  addressFormControl = new FormControl('', [Validators.required]);
  hide = true;


  onSubmit(){
    this.service.register().subscribe(
      (res: any) => {
        if (res.succeeded) {
          this.router.navigateByUrl('user/login')
          this.service.resetForm();
          this.toastr.success('New user created!', 'Registration successful.');
        } else {
          res.errors.forEach((res:any)=> {
            switch (res.code) {
              case 'DuplicateUserName':
                this.toastr.error('Username is already taken','Registration failed.');
                break;

              default:
                this.toastr.error(res.description,'Registration failed.');
                break;
            }
          });
        }
      },
      err => {
        console.log(err);
      }
    );
  }
  constructor(public  service: UserService, private toastr: ToastrService, public router: Router) { }
  ngOnInit(): void {

  }
}



