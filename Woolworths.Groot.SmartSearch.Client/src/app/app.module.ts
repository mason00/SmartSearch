import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AuthModule } from '@auth0/auth0-angular';
import { reducer } from '@core/store/link-click.reducer';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { StoreModule } from '@ngrx/store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { WebShellModule } from '@shell/web-shell.module';
import { GoogleLoginProvider, SocialLoginModule } from 'angularx-social-login';
import { CoreModule } from './@core/core.module';
import { AppComponent } from './app.component';
import { UserInfoComponent } from './pages/user-info/user-info.component';

@NgModule({
  declarations: [AppComponent, UserInfoComponent],
  providers: [{
    provide: 'SocialAuthServiceConfig',
    useValue: {
      autoLogin: true, //keeps the user signed in
      providers: [
        {
          id: GoogleLoginProvider.PROVIDER_ID,
          provider: new GoogleLoginProvider('535648816304-dqqvv9tnv9e38vdo0debrov4ps63jdgg.apps.googleusercontent.com') // your client id
        }
      ]
    }
  }],
  imports: [BrowserModule,
    CoreModule,
    WebShellModule,
    BrowserAnimationsModule,
    NgbModule,
    StoreModule.forRoot({linkClickInfo: reducer}),
    StoreDevtoolsModule.instrument({
      maxAge: 50,
    }),
    SocialLoginModule,
    AuthModule.forRoot({
      domain: 'dev-5cv7cv5t.us.auth0.com',
      clientId: 'NbmjIboNZcAIeNqL8HXg94InZ7NnLrHC',

      audience: 'https://woolworthsgrootsmartsearch20220220094337.azurewebsites.net/',

      scope: 'read:hello',
    }),
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
