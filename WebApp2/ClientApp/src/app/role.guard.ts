import { CanActivate, ActivatedRouteSnapshot, ActivatedRoute, Router } from "@angular/router";
import * as decode from 'jwt-decode';
import { Injectable } from "@angular/core";
import { AuthService } from "./auth.service";
import { Observable } from "rxjs";

@Injectable()
export class RoleGuard implements CanActivate {
  constructor(public authService: AuthService, public router: Router) { }

  canActivate(router: ActivatedRouteSnapshot): boolean {
    const expectedRole = router.data.expectedRole;
    const token = localStorage.getItem('access_token');
    const tokenPayLoad = decode(token);
    if (!this.authService.checkAcess() || tokenPayLoad.role !== expectedRole) {
      this.router.navigate(['login']);
      return false;
    }
    return true;
  }

  IsAdmin() {
    const token = localStorage.getItem('access_token');
    if (token != null) {
    const tokenPayLoad = decode(token);
    if (tokenPayLoad.role === "Admin"){
      return true;
    }
    else {
      return false;} 
    }
    return false;
  }
}
