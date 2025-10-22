import { Component, inject, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { IAnime } from '../../core/models/interfaces/anime.interface';
import { AnimeService } from '../../core/service/anime.service';

@Component({
  selector: 'app-home',
  imports: [RouterLink],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  animesList:IAnime[] = [];
  animeService = inject(AnimeService);

  ngOnInit(): void {
    this.getAllAnime();
    console.log(this.animesList);
  }

  getAllAnime(): void {
    this.animeService.getAnimes().subscribe(res => {
      this.animesList = res;
    });
  }
}
