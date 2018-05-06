//import { BrowserModule } from '@angular/platform-browser';
//import { FormsModule } from '@angular/forms';
//import { HttpModule } from '@angular/http';
//import { NgModule } from '@angular/core';
//import { RouterModule, Routes } from '@angular/router';


//import { AppComponent } from './app.component';
//import { MsalService } from './services/msal.service';
//import { NavBarComponent } from './nav-bar/nav-bar.component';
//import { RightSidebarComponent } from './right-sidebar/right-sidebar.component';
//import { FooterComponent } from './footer/footer.component';

//@NgModule({
//  declarations: [
//    AppComponent,
//    NavBarComponent,
//    RightSidebarComponent,
//    FooterComponent
//  ],
//  imports: [
//    BrowserModule
//  ],
//  providers: [
//    MsalService
//  ],
//  bootstrap: [AppComponent]
//})
//export class AppModule { }

import { ModuleWithProviders, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AuthModule } from './auth/auth.module';
import { HomeModule } from './home/home.module';
import {
  FooterComponent,
  NavBarComponent,
  RightSidebarComponent,
  SharedModule
} from './shared';
import { AppRoutingModule } from './app-routing.module';
import { CoreModule } from './core/core.module';
//import { HomeRoutingModule } from './home/home-routing.module';

@NgModule({
  declarations: [AppComponent, FooterComponent, NavBarComponent, RightSidebarComponent],
  imports: [
    BrowserModule,
    CoreModule,
    SharedModule,
    HomeModule,
    AuthModule,
    AppRoutingModule,
   // HomeRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
