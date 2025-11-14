import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { catchError, map, Observable, throwError } from "rxjs";
import { IAnime } from "../models/interfaces/anime.interface";
import { IResponseData } from "../models/interfaces/response-data.interface";
import { PaginatorConstant } from "../constants/paginator.constant";
import { IPagedResult } from "../models/interfaces/paged-result.interface";

@Injectable(
    {providedIn: 'root'}   
)
export class AnimeService {
    private http = inject(HttpClient);
    private apiUrl = 'http://localhost:5147/v1/api/animes';

    // getAnimes(): Observable<IAnime[]> {
    //     return this.http.get<IResponseData<IAnime[]>>(this.apiUrl).pipe(
    //         map(response => {
    //             if (response.statusCode > 200) {
    //                 throw new Error(response.message || "Lỗi lấy dữ liệu từ server!!!");
    //             }
    //             return response.data;
    //         }),
    //         catchError(this.handleError)
    //     );
    // }

    getAnimes({
        pageIndex = PaginatorConstant.DEFAULT_PAGE_INDEX, 
        pageSize = PaginatorConstant.DEFAULT_PAGE_SIZE, 
        sortBy = PaginatorConstant.DEFAULT_SORT_BY, 
        order = PaginatorConstant.SORT_ORDER.ASCENDING, 
        select = ''
    } = {}): Observable<IPagedResult<IAnime[]>> {
        return this.http.get<IPagedResult<IAnime[]> | string>(this.apiUrl, {
            params: {
                pageIndex: pageIndex,
                pageSize: pageSize,
                sortBy: sortBy,
                order: order,
                select: select
            }
        }).pipe(
            map(response => {
                if (typeof response === 'string') {
                    throw new Error(response || "Lỗi lấy dữ liệu từ server!!!");
                }

                return response as IPagedResult<IAnime[]>;
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

    searchAnimes(query: string): Observable<IAnime[]> {
        return this.http.get<IResponseData<IAnime[]>>(`${this.apiUrl}/search`, {
            params: { q: query }
        }).pipe(
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
            errorMessage = `Lỗi Http: ${error.message} - ${error.status} - ${error.statusText}` || `"Unknown Error!!!"`;
        } else {
            errorMessage = `Lỗi Ứng Dụng: ${error.message}`;
        }
        return throwError(() => new Error(error.message));
    }
}