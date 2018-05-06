import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home.component';
//import { HomeAuthResolver } from './home-auth-resolver.service';
import { MsalGuard } from 'msal-angular';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    canActivate: [MsalGuard]
    //resolve: {
    //  isAuthenticated: HomeAuthResolver
    //}
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule {}
