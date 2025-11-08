import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { catchError, map, Observable, throwError } from "rxjs";
import { IAnime } from "../models/interfaces/anime.interface";
import { IResponseData } from "../models/interfaces/response-data.interface";

@Injectable(
    {providedIn: 'root'}   
)
export class AnimeService {
    private http = inject(HttpClient);
    private apiUrl = 'http://localhost:5147/v1/api/Anime';

    getAnimes(): Observable<IAnime[]> {
        return this.http.get<IResponseData<IAnime[]>>(this.apiUrl).pipe(
            map(response => {
                if (response.statusCode > 200) {
                    throw new Error(response.message || "Lỗi lấy dữ liệu từ server!!!");
                }
                return response.data;
            }),
            catchError(this.handleError)
        );
    }

    getAnimeDetail(id: number): Observable<IAnime> {
        return this.http.get<IResponseData<IAnime>>(`${this.apiUrl}/id?id=${id}`).pipe(
            map(response => {
                if (response.statusCode > 200) {
                    throw new Error(response.message || "Lỗi lấy dữ liệu từ server!!!");
                }
                return response.data;
            }),
            catchError(this.handleError)
        );
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