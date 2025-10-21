import { Component, effect, inject, input, OnInit } from '@angular/core';
import { AnimeService } from '../../core/service/anime.service';
import { map, Observable, switchMap } from 'rxjs';
import { IAnime } from '../../core/models/interfaces/anime.interface';
import { AsyncPipe } from '@angular/common';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-anime-detail',
  imports: [AsyncPipe],
  templateUrl: './anime-detail.component.html',
  styleUrl: './anime-detail.component.css'
})
export class AnimeDetailComponent implements OnInit {
  anime$!: Observable<IAnime>;
  id: number | null = null;

  private animeService = inject(AnimeService);
  private route = inject(ActivatedRoute);

  ngOnInit(): void {
    this.getAnimeDetail();
  }

  getAnimeDetail() {
    this.anime$ = this.route.paramMap.pipe(
      switchMap(param => {
        this.id = Number(param.get('id'));
        return this.animeService.getAnimeDetail(this.id);
      })
    );
  }
}
