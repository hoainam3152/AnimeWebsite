import { Component, effect, inject, input, OnInit } from '@angular/core';
import { AnimeService } from '../../core/service/anime.service';
import { map, Observable, switchMap } from 'rxjs';
import { IAnime } from '../../core/models/interfaces/anime.interface';
import { AsyncPipe } from '@angular/common';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { IResponseData } from '../../core/models/interfaces/response-data.interface';

@Component({
  selector: 'app-anime-detail',
  imports: [AsyncPipe],
  templateUrl: './anime-detail.component.html',
  styleUrl: './anime-detail.component.css'
})
export class AnimeDetailComponent implements OnInit {
  anime$!: Observable<IAnime>;

  private animeService = inject(AnimeService);
  private route = inject(ActivatedRoute);

  ngOnInit(): void {
    this.getAnimeDetail();
  }

  getAnimeDetail(): void {
    this.anime$ = this.route.paramMap.pipe(
      switchMap((params: ParamMap) => {
        const idString = params.get('id');

        if (idString) {
          return this.animeService.getAnimeDetail(Number(idString));
        }

        return new Observable<IResponseData<IAnime>>();
      }),
      map((response: IResponseData<IAnime>) => response.data)
    );
  }
}
