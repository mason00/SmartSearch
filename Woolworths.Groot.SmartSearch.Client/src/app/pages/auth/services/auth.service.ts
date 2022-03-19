import { Injectable } from '@angular/core';
import { getItem, removeItem, setItem, StorageItem } from '@core/utils';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  isLoggedIn$ = new BehaviorSubject<boolean>(!!getItem(StorageItem.Auth));

  get isLoggedIn(): boolean {
    return this.isLoggedIn$.getValue();
  }

  signIn(idToken = ''): void {
    const token = Array(4)
      .fill(0)
      .map(() => Math.random() * 99)
      .join('-');

    setItem(StorageItem.Auth, token);
    setItem(StorageItem.GoogleIdToken, idToken);
    this.isLoggedIn$.next(true);
  }

  signOut(): void {
    removeItem(StorageItem.Auth);
    removeItem(StorageItem.GoogleIdToken);
    this.isLoggedIn$.next(false);
  }
}
