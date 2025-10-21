import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IAnime } from "../models/interfaces/anime.interface";

@Injectable(
    {providedIn: 'root'}   
)
export class AnimeService {
    private http = inject(HttpClient);
    private apiUrl = 'http://localhost:5147/v1/api/Anime';

    getAnimes(): Observable<IAnime[]> {
        return this.http.get<IAnime[]>(this.apiUrl);
    }

    getAnimeDetail(id: number): Observable<IAnime> {
        return this.http.get<IAnime>(`${this.apiUrl}/id?id=${id}`);
    }
}