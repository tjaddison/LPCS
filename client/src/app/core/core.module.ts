import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { HttpTokenInterceptor } from './interceptors/http.token.interceptor';
import { MsalModule } from 'msal-angular';
import { environment } from '../../environments/environment';

import {
  ApiService,
  //ArticlesService,
  //AuthGuard,
  //CommentsService,
  JwtService,
  //ProfilesService,
  //TagsService,
  //MsalService,
  UserService
} from './services';

@NgModule({
  imports: [
    CommonModule,
    [MsalModule.forRoot({
      clientID: environment.clientID,
      graphScopes: environment.graphScopes,
      signUpSignInPolicy: environment.signUpSignInPolicy,
      tenant: environment.tenant,
      redirectUrl: ''
    })]
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: HttpTokenInterceptor, multi: true },
    ApiService,
    //ArticlesService,
    //AuthGuard,
    //CommentsService,
    JwtService,
    //ProfilesService,
    //TagsService,
    //MsalService,
    UserService
  ],
  declarations: []
})

export class CoreModule { }
