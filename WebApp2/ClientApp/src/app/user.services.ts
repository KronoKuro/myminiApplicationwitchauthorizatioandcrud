import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import Usermodel = require("./models/user.model");
import User = Usermodel.User;


@Injectable()
export class UserServices {

  constructor(private http: HttpClient) {}

  private url: string = 'api/user';

  getUser(id: string) {
    return this.http.get<User>(this.url + '/' + id);
  }

}
