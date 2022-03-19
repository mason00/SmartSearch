import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ThemeList, ThemeService } from '@core/services/theme';
import { ROUTER_UTILS } from '@core/utils/router.utils';
import { GoogleLoginProvider, SocialAuthService } from 'angularx-social-login';

@Component({
  templateUrl: './home.page.html',
  styleUrls: ['./home.page.css'],
})
export class HomePage {
  path = ROUTER_UTILS.config;
  theme = ThemeList;

  constructor(private router: Router,
    private themeService: ThemeService,
    private socialAuthService: SocialAuthService) {}

  onClickChangeTheme(theme: ThemeList): void {
    this.themeService.setTheme(theme);
  }

  loginWithGoogle(): void {
    const { root, userInfo } = ROUTER_UTILS.config.auth;
    this.socialAuthService.signIn(GoogleLoginProvider.PROVIDER_ID)
      .catch(err => console.error('google login', err))
      .then(() => this.router.navigate(['/', root, userInfo]));
  }
}
