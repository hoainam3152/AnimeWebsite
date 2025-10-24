import { Component, input } from '@angular/core';
import { RouterLink } from '@angular/router';
import { IAnime } from '../../../core/models/interfaces/anime.interface';

@Component({
  selector: 'app-anime-item',
  imports: [ RouterLink ],
  templateUrl: './anime-item.component.html',
  styleUrl: './anime-item.component.css'
})
export class AnimeItemComponent {
  anime = input.required<IAnime>();
}
