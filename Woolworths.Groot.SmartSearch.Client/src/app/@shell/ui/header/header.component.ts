import { ChangeDetectionStrategy, Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService as Auth0 } from '@auth0/auth0-angular';
import { ROUTER_UTILS } from '@core/utils/router.utils';
import { AuthService } from '@pages/auth/services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class HeaderComponent {
  path = ROUTER_UTILS.config.base;

  constructor(private router: Router,
    private authService: AuthService,
    private auth0: Auth0) {}

  onClickSignOut(): void {
    this.authService.signOut();

    this.auth0.logout({ returnTo: document.location.origin });

    const { root, signIn } = ROUTER_UTILS.config.auth;
    this.router.navigate(['/', root, signIn]);
  }
}
