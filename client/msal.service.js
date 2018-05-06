import { Injectable, InjectionToken, Inject } from '@angular/core';
import { MsalConfig } from './msal-config';
import * as Msal from 'msal';
export const MSAL_CONFIG = new InjectionToken('MSAL_CONFIG');
export class MsalService {
  constructor(config) {
        this.config = config;
        const authority = (config.tenant && config.signUpSignInPolicy) ?
            `https://login.microsoftonline.com/tfp/${config.tenant}/${config.signUpSignInPolicy}` : '';
      this.app = new Msal.UserAgentApplication(config.clientID, authority, config.callback, {
            navigateToLoginRequestUrl: this.config.navigateToLoginRequestUrl,
            redirectUri: this.getFullUrl(this.config.redirectUrl)
        });
    }
    getUser() {
        return this.authenticated.then(isauthenticated => isauthenticated ? this.user : {});
    }
    get authenticated() {
        //return this.token.then(t => !!t);
      return this.app.getUser() != null;
    }
    get token() {
        return this.getToken();
    }
    login() {
        return this.config.popup ?
            this.loginPopup() :
            this.loginRedirect();
  }

  getToken() {
   
        return this.app.acquireTokenSilent(this.config.graphScopes)
          .then(token => {
              return token;
          })
          .catch(error => {
                return this.app.acquireTokenPopup(this.config.graphScopes)
                  .then(token => {
                    return Promise.resolve(token);
                  }).catch(innererror => {
                    return Promise.resolve('');
                });
            });
    }

    logout() {
        this.user = null;
        this.app.logout();
    }
    loginPopup() {
        return this.app.loginPopup(this.config.graphScopes).then((idToken) => {
            this.app.acquireTokenSilent(this.config.graphScopes).then((token) => {
                return Promise.resolve(token);
            }, (error) => {
                this.app.acquireTokenPopup(this.config.graphScopes).then((token) => {
                    return Promise.resolve(token);
                }, (innererror) => {
                    console.log('Error acquiring the popup:\n' + innererror);
                    return Promise.resolve('');
                });
            });
        }, (error) => {
            console.log('Error during login:\n' + error);
            return Promise.resolve('');
        });
    }
    loginRedirect() {
        this.app.loginRedirect(this.config.graphScopes);
        return this.getToken().then(() => {
            Promise.resolve(this.app.getUser());
        });
    }
    getFullUrl(url) {
        // this create a absolute url from a relative one.
        const pat = /^https?:\/\//i;
        return pat.test(url) ? url : this.origin() + url;
    }
    origin() {
        return (window.location.origin) ? window.location.origin :
            window.location.protocol + '//' + window.location.hostname + (window.location.port ? ':' + window.location.port : '');
    }
}
MsalService.decorators = [
    { type: Injectable },
];
/** @nocollapse */
MsalService.ctorParameters = () => [
    { type: MsalConfig, decorators: [{ type: Inject, args: [MSAL_CONFIG,] },] },
];
//# sourceMappingURL=msal.service.js.map
