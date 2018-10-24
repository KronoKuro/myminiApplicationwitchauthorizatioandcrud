import { CanActivate, ActivatedRouteSnapshot, ActivatedRoute, Router } from "@angular/router";
import * as decode from 'jwt-decode';
import { Injectable } from "@angular/core";
import { AuthService } from "./auth.service";

@Injectable()
export class RoleGuard implements CanActivate {
  constructor(public authService: AuthService, public router: Router) { }

  canActivate(router: ActivatedRouteSnapshot): boolean {
    const expectedRole = router.data.expectedRole;
    console.log(expectedRole);
    const token = localStorage.getItem('access_token');
    console.log(token);
    const tokenPayLoad = decode(token);
    console.log(tokenPayLoad);
    console.log(tokenPayLoad.role);
    if (!this.authService.checkAcess() || tokenPayLoad.role !== expectedRole) {
      this.router.navigate(['login']);
      return false;
    }
    return true;
  }
}
