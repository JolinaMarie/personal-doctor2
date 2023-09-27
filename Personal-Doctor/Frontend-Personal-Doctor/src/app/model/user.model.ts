export class User {
    constructor(
      public firstname: string = '',
      public lastname: string = '',
      public email: string = '',
      public confirmEmail: string = '',
      public password: string = '',
      public confirmPassword: string = ''
    ) {}

    clearFields() {
      this.firstname = '';
      this.lastname = '';
      this.email = '';
      this.confirmEmail = '';
      this.password = '';
      this.confirmPassword = '';
    }

    areFieldsEmpty(): boolean {
      return (
        !this.firstname ||
        !this.lastname ||
        !this.email ||
        !this.confirmEmail ||
        !this.password ||
        !this.confirmPassword
      );
    }
  }