import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

//import { MsalService } from 'msal-angular';


@Component({
  selector: 'app-home-page',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  //providers: [MsalService]
})
export class HomeComponent implements OnInit {
  constructor(
    //private router: Router,
    //private userService: UserService,
    //private msalService: MsalService
  ) {}

  isAuthenticated: boolean;

    ngOnInit() {
      //this.userService.isAuthenticated.subscribe(
      //    (authenticated) => {
      //      this.isAuthenticated = authenticated;

      //      if (authenticated) {

      //      } else {

      //      }
      //    }
      //  );
      }
    

    //login(): void {
    //  this.msalService.login();
    //}

    //logout(): void {
    //  this.msalService.logout();
    //};

    //get authenticated(): Promise<boolean> {
    //  return this.msalService.authenticated;
    //}


  //ngOnInit() {
  //  this.userService.isAuthenticated.subscribe(
  //    (authenticated) => {
  //      this.isAuthenticated = authenticated;

  //      if (authenticated) {
          
  //      } else {
          
  //      }
  //    }
  //  );

  //}


  //}
}


