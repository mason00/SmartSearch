import { Component, OnInit } from '@angular/core';
import { SocialAuthService, SocialUser } from 'angularx-social-login';
import { map, Observable } from 'rxjs';

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.css']
})
export class UserInfoComponent implements OnInit {
  userName$ : Observable<SocialUser> | undefined = undefined;

  constructor(private socialAuthService: SocialAuthService) { }

  ngOnInit(): void {
    this.userName$ = this.socialAuthService.authState.pipe(
      map((socialUser: SocialUser) => {
        console.warn(socialUser);
        return socialUser;
      }),
    );
  }

}
