import { Component, inject, OnInit } from '@angular/core';
import { AnimeService } from '../../core/service/anime.service';
import { catchError, Observable, of, switchMap } from 'rxjs';
import { IAnime } from '../../core/models/interfaces/anime.interface';
import { AsyncPipe } from '@angular/common';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { AccountService } from '../../core/service/account.service';

@Component({
  selector: 'app-anime-detail',
  imports: [AsyncPipe],
  templateUrl: './anime-detail.component.html',
  styleUrl: './anime-detail.component.css'
})
export class AnimeDetailComponent implements OnInit {
  anime$!: Observable<IAnime>;
  errorMessage: string | null = null;

  private animeService = inject(AnimeService);
  private route = inject(ActivatedRoute);
  private accountService = inject(AccountService);
  private router = inject(Router);

  ngOnInit(): void {
    this.getAnimeDetail();
  }

  createMockAnime(): Observable<IAnime> {
    const mockData: IAnime = {
      id: 999,
      title: 'Anime Giả Lập: Tạm Thời',
      alternateTitle: 'Mock Data Testing',
      coverImage: 'assets/anime/details-pic.jpg',
      synopsis: 'Đây là dữ liệu anime giả lập, dùng cho mục đích kiểm thử mà không cần gọi API.',
    }
    return of(mockData);
  }

  getAnimeDetail(): void {
    this.anime$ = this.route.paramMap.pipe(
      switchMap((params: ParamMap) => {
        const idString = params.get('id');

        if (idString) {
          return this.animeService.getAnimeDetail(Number(idString)).pipe(
            catchError(err => {
              this.errorMessage = err.message || 'Lỗi tải dữ liệu';
              console.log(this.errorMessage);
              return this.createMockAnime();
            })
          );
        }
        else {
            this.errorMessage = 'Không tìm thấy ID trên URL.';
            console.log(this.errorMessage);
            return this.createMockAnime();
        }
      })
    );
  }

  handleWatchButton(): void {
    if (this.accountService.isLoggedIn()) {
      console.log("da dang nhap");
      this.router.navigate(['anime-watching']);
    }
    else {
      console.log("chua dang nhap");
      alert('Vui lòng đăng nhập để tiếp tục.');
      this.router.navigate(['sign-in']);
    }
  }
}
