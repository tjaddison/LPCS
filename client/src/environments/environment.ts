// The file contents for the current environment will overwrite these during build.
// The build system defaults to the dev environment which uses `environment.ts`, but if you do
// `ng build --env=prod` then `environment.prod.ts` will be used instead.
// The list of which env maps to which file can be found in `.angular-cli.json`.

export const environment = {
  production: false,
  api_url: 'http://localhost:15354/api',
  clientID: 'cd7588e7-f875-4172-b66f-48d63307cb2d',
  graphScopes: ['openid'],
  signUpSignInPolicy: 'B2C_1_SiUpIn',
  tenant: 'b2cvhda.onmicrosoft.com'
};
