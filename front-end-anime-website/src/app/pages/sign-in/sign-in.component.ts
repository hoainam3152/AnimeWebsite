import { Component, inject } from '@angular/core';
import { RouterLink } from '@angular/router';
import { AccountService } from '../../core/service/account.service';
import { IAccountLogin } from '../../core/models/interfaces/account-login.interface';
import { catchError, Observable, of } from 'rxjs';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { AsyncPipe } from '@angular/common';

@Component({
  selector: 'app-sign-in',
  imports: [
    RouterLink,
    ReactiveFormsModule,
    AsyncPipe
  ],
  templateUrl: './sign-in.component.html',
  styleUrl: './sign-in.component.css'
})
export class SignInComponent {
  loginForm = new FormGroup ({
    email: new FormControl(''),
    password: new FormControl('')
  })

  private accountService = inject(AccountService);
  token$!:  Observable<string>;

  handleSignInButton() {
    let accountLogin: IAccountLogin = {
      email: this.loginForm.value.email?.trim() ?? "",
      password: this.loginForm.value.password?.trim() ?? ""
    };

    this.token$ = this.accountService.login(accountLogin).pipe(
      catchError(err => {
        console.log(err.message || 'Lỗi tải dữ liệu');
        alert('Tên đăng nhập hoặc mật khẩu không đúng !!!');
        return of('');
      })
    );
  }
}
