export class User {
    constructor(
      public firstname: string = '',
      public lastname: string = '',
      public email: string = '',
      public confirmEmail: string = '',
      public password: string = '',
      public confirmPassword: string = ''
    ) {}
  }