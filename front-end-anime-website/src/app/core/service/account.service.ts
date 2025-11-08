import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { IAccountCreate } from "../models/interfaces/account-create.interface";
import { IAccountLogin } from "../models/interfaces/account-login.interface";
import { catchError, map, Observable, throwError } from "rxjs";
import { IResponseData } from "../models/interfaces/response-data.interface";

@Injectable ({ 
    providedIn: "root" 
})
export class AccountService {
    private readonly TOKEN_KEY = "authToken";
    private httpClient = inject(HttpClient);
    private apiUrl = 'https://localhost:7155/api/v1/user-profile';

    isLoggedIn(): boolean {
        return !!this.getToken();
    }

    register(accountCreate: IAccountCreate): Observable<IResponseData<string>> {
        var responseData = this.httpClient.post<any>(`${this.apiUrl}/sign-up`, accountCreate);
        return responseData;
    }

    login(accountLogin: IAccountLogin): Observable<any> {
        return this.httpClient.post<IResponseData<string>>(`${this.apiUrl}/sign-in`, accountLogin).pipe(
            map(response => {
                if (response.statusCode > 200) {
                    throw new Error(response.message || "Lỗi lấy dữ liệu từ server!!!");
                }
                this.setToken(response.data);
            }),
            catchError(this.handleError)
        );
    }

    logout() {
        localStorage.removeItem(this.TOKEN_KEY);
    }

    private setToken(token: string): void {
        localStorage.setItem(this.TOKEN_KEY, token);
    }

    getToken(): string | null {
        return localStorage.getItem(this.TOKEN_KEY);
    }

    private handleError(error: HttpErrorResponse | Error): Observable<never> {
        let errorMessage = "Đã xảy ra lỗi không xác định.";

        if (error instanceof HttpErrorResponse) {
            errorMessage = `Lỗi Http: ${error.status} - ${error.statusText} || "Unknown Error!!!"`;
        } else {
            errorMessage = `Lỗi Ứng Dụng: ${error.message}`;
        }
        console.log(errorMessage);
        return throwError(() => new Error(error.message));
    }
}