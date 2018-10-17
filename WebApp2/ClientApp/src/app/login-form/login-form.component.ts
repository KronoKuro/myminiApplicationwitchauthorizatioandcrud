import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {

  loginForm: FormGroup;

  constructor(private authService: AuthService, private router: Router) {
    this.loginForm = new FormGroup ({
      'Login': new FormControl('', Validators.required),
      'Password': new FormControl('', Validators.required)
    });
  }

  login() {
    this.authService.login(this.loginForm.getRawValue()).subscribe(resp => {
      localStorage.setItem('access_token', resp['access_token']);
      localStorage.setItem('user_name', resp['user_name']);
      console.log(resp['access_token']);
      this.router.navigate(['news']);
    }, error => {
      alert(error['error']);
    })
  }

  

  ngOnInit() {
  }

}
