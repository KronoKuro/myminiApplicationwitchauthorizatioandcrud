import { Component, OnInit } from "@angular/core";
import { UserServices } from '../user.services';
import { User } from '../models/user.model';



@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
/*  styleUrls: ['./user.component.css']*/
})
export class UserComponent {

  constructor(private userServices: UserServices) { }
  user: User;
  isHasUser: boolean;

  ngOnInit() {
    const id = localStorage.getItem('id');
    this.getUser(id);
  }

  getUser(id: string) {
    this.userServices.getUser(id).subscribe(resp => {
      this.user = resp;
      console.log(this.user);
      if (this.user != null) {
        debugger;
        this.isHasUser = true;
      } else {
        this.isHasUser = false;
      }
    });
  }

}

