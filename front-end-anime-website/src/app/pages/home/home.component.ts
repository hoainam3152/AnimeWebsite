import { Component, inject, OnInit } from '@angular/core';
import { IAnime } from '../../core/models/interfaces/anime.interface';
import { AnimeService } from '../../core/service/anime.service';
import { AnimeItemComponent } from '../../shared/component/anime-item/anime-item.component';
import { catchError, Observable, of } from 'rxjs';
import { AsyncPipe } from '@angular/common';

@Component({
  selector: 'app-home',
  imports: [
    AnimeItemComponent,
    AsyncPipe
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  animes$!: Observable<IAnime[]>
  animeService = inject(AnimeService);
  errorMessage: string | null = null;

  ngOnInit(): void {
    this.loadAnimes();
  }

  loadAnimes(): void {
    this.animes$ = this.animeService.getAnimes().pipe(
      catchError(err => {
        this.errorMessage = err.message || 'Lỗi tải dữ liệu';
        console.log(this.errorMessage);
        return of([]);
      })
    );
  }
}
