import { Component, OnInit, Input } from '@angular/core';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.css']
})
export class RegisterFormComponent implements OnInit {

  registerForm: FormGroup;
  @Input() Password = '';
  @Input() confirmedPassword = '';

  constructor(private autService: AuthService, private router: Router) 
  {
    this.registerForm = new FormGroup ({
      'Login': new FormControl('', [Validators.required,  Validators.minLength(6)]),
      'Password': new FormControl('', [Validators.required, Validators.minLength(6), Validators.maxLength(15)]),
      'UserName': new FormControl(null, Validators.required),
      'LastName' : new FormControl(null, Validators.required),
      'FirstName' : new FormControl(null, Validators.required),
      'confirmedPassword': new FormControl(null, [Validators.required, this.passwordsMatch(this.Password,this.confirmedPassword).bind(this)])
    });
   }

  ngOnInit() {
  }

  register() {
    this.autService.register(this.registerForm.getRawValue()).subscribe(resp => {
      console.log(this.registerForm);
      this.router.navigate(['login']);
    }, error=> {
      alert(error['error']);
    })
  }

  passwordsMatch(password: string, confirmedPassword: string) {
    
    return (control: FormControl) : { [s: string]: boolean } =>{
      //getting undefined values for both variables
      console.log(password,confirmedPassword);
       //if I change this condition to === it throws the error if the 
        //  two fields are the same, so this part works
       if (password !== confirmedPassword) {
         return { 'passwordMismatch': true }
       } else {
         //it always gets here no matter what
         return null;
       }
     }
   }


}
