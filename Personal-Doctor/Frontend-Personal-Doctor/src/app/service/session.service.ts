import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SessionService {
  private sessionKey: string | null = null;

  setSessionKey(sessionKey: string): void {
    this.sessionKey = sessionKey;
  }

  getSessionKey(): string | null {
    return this.sessionKey;
  }
}
