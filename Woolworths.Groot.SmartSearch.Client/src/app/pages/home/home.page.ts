import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService as Auth0 } from '@auth0/auth0-angular';
import { ThemeList, ThemeService } from '@core/services/theme';
import { ROUTER_UTILS } from '@core/utils/router.utils';
import { AuthService } from '@pages/auth/services/auth.service';
import { GoogleLoginProvider, SocialAuthService, SocialUser } from 'angularx-social-login';

@Component({
  templateUrl: './home.page.html',
  styleUrls: ['./home.page.css'],
})
export class HomePage {
  path = ROUTER_UTILS.config;
  theme = ThemeList;

  constructor(private router: Router,
    private themeService: ThemeService,
    private socialAuthService: SocialAuthService,
    private authService: AuthService,
    private auth0: Auth0) {}

  onClickChangeTheme(theme: ThemeList): void {
    this.themeService.setTheme(theme);
  }

  loginWithGoogle(): void {
    const { root, userInfo } = ROUTER_UTILS.config.auth;
    this.socialAuthService.signIn(GoogleLoginProvider.PROVIDER_ID)
      .then((socialUser: SocialUser) => {
        this.authService.signIn(socialUser.idToken);
        this.router.navigate(['/', root, userInfo]);
      })
      .catch(err => console.error('google login', err));
  }

  loginWithAuth0() {
    this.auth0.loginWithRedirect();
  }
}
