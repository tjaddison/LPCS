import { Component, OnInit } from '@angular/core';
import { MsalService } from 'msal-angular';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  constructor(private msalService: MsalService) { }

  ngOnInit() {
  }

  logout(): void {
    this.msalService.logout();
  
  };
}
