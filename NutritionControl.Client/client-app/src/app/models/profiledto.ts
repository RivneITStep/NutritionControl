export class ProfileDto {
  height: number;
  weight: number;
  age: number;
  bmi: number;
  goalWeight: number;
  name: string;
  surname: string;
  email: string;
  gender: string;
}

export class PasswordChangeRequest{
  oldPassword: string;
  newPassword: string;
  confirmPassword: string;
}