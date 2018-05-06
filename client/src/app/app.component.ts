import { Component, OnInit } from '@angular/core';

import { MsalService } from 'msal-angular';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
  constructor(
    private msalService: MsalService
  ) {}

  ngOnInit() {
    if (!this.msalService.authenticated) this.msalService.login();
    
  }

  get authenticated(): Promise<boolean> {
    return this.msalService.authenticated;
  }  
}



//import { Component } from '@angular/core';
////import { Location } from '@angular/common';
////import { MsalService } from './services/msal.service';

//@Component({
//  selector: 'app-root',
//  templateUrl: './app.component.html',
//  styleUrls: ['./app.component.css'],
//  //providers: [MsalService]
//})

//export class AppComponent {
//  title = 'App Title';

//  constructor(
//    //private location: Location,
//    //private msalService: MsalService
//  ) { }

//  login(): void {
//    //this.msalService.login();
//  }

//  logout(): void {
//    //this.msalService.logout();
//  };

//  //isActive(viewLocation: any): boolean {
//  //  return viewLocation === this.location.path();
//  //};

//  isOnline(): boolean {
//    //return this.msalService.isOnline();
//    return true;
//  };


//}


