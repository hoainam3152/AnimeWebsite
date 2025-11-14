import { Component, inject, OnInit } from '@angular/core';
import { IAnime } from '../../core/models/interfaces/anime.interface';
import { AnimeService } from '../../core/service/anime.service';
import { AnimeItemComponent } from '../../shared/component/anime-item/anime-item.component';
import { catchError, Observable, of } from 'rxjs';
import { AsyncPipe } from '@angular/common';
import { IPagedResult } from '../../core/models/interfaces/paged-result.interface';
import { RouterLink } from "@angular/router";

@Component({
  selector: 'app-home',
  imports: [
    AnimeItemComponent,
    AsyncPipe,
    RouterLink
],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  animes$!: Observable<IPagedResult<IAnime[]>>;
  animeService = inject(AnimeService);
  errorMessage: string | null = null;

  ngOnInit(): void {
    this.loadAnimes();
    console.log(this.animes$);
  }

  loadAnimes(): void {
    this.animes$ = this.animeService.getAnimes({ pageIndex: 0, pageSize: 6, select: 'id, title, coverImage' }).pipe(
      catchError(err => {
        console.log(err.message || 'Lỗi tải dữ liệu');
        const emptyPagedResult: IPagedResult<IAnime[]> = {
          items: [],
          totalCount: 0,
          pageIndex: 0,
          pageSize: 6 
        };

        return of(emptyPagedResult);
      })
    );
  }
}
