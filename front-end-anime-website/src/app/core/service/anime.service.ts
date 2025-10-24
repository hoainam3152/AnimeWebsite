import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IAnime } from "../models/interfaces/anime.interface";
import { IResponseData } from "../models/interfaces/response-data.interface";

@Injectable(
    {providedIn: 'root'}   
)
export class AnimeService {
    private http = inject(HttpClient);
    private apiUrl = 'http://localhost:5147/v1/api/Anime';

    getAnimes(): Observable<IResponseData<IAnime[]>> {
        return this.http.get<any>(this.apiUrl);
    }

    getAnimeDetail(id: number): Observable<IResponseData<IAnime>> {
        return this.http.get<any>(`${this.apiUrl}/id?id=${id}`);
    }
}