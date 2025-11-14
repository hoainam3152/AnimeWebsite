import { Component, inject, OnInit } from '@angular/core';
import { catchError, Observable, of } from 'rxjs';
import { IPagedResult } from '../../core/models/interfaces/paged-result.interface';
import { IAnime } from '../../core/models/interfaces/anime.interface';
import { AnimeService } from '../../core/service/anime.service';
import { error } from 'console';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { AsyncPipe } from '@angular/common';
import { AnimeItemComponent } from '../../shared/component/anime-item/anime-item.component';

@Component({
  selector: 'app-anime-componet',
  imports: [
    MatPaginator,
    AsyncPipe,
    AnimeItemComponent
  ],
  templateUrl: './anime.componet.html',
  styleUrl: './anime.componet.css'
})
export class AnimeComponet implements OnInit {
  pagedResults$!: Observable<IPagedResult<IAnime[]>>;

  animeService = inject(AnimeService);

  ngOnInit(): void {
    this.loadAnimes();
  }

  loadAnimes(): void {
    this.pagedResults$ = this.animeService.getAnimes( { pageSize: 10 } ).pipe(
      catchError(err => {
        console.log(err.message || "Lỗi không xác định");
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

  handlePageEvent(event: PageEvent) {
    this.pagedResults$ = this.animeService.getAnimes({ pageIndex: event.pageIndex, pageSize: event.pageSize }).pipe(
      catchError(err => {
        console.log(err.message || "Lỗi không xác định");
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
