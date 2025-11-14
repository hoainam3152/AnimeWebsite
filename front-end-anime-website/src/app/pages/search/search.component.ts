import { ChangeDetectorRef, Component, inject, OnInit } from '@angular/core';
import { IAnime } from '../../core/models/interfaces/anime.interface';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { BehaviorSubject, catchError, combineLatest, map, Observable, of, shareReplay, switchMap, tap } from 'rxjs';
import { AnimeService } from '../../core/service/anime.service';
import { AsyncPipe } from '@angular/common';
import { AnimeItemComponent } from '../../shared/component/anime-item/anime-item.component';
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-search',
  imports: [
    AsyncPipe,
    AnimeItemComponent,
    MatPaginatorModule,
  ],
  templateUrl: './search.component.html',
  styleUrl: './search.component.css'
})
export class SearchComponent implements OnInit {
  queryString!: string | null;
  //Nguồn phát ra các sự kiện thay đổi trang/kích thước trang từ mat-paginator. Lưu trữ trạng thái hiện tại của Paginator.  
  pageEventSubject = new BehaviorSubject<PageEvent>({
    length: 0,
    pageSize: 12,
    pageIndex: 0,
  });
  length$!: Observable<number>;
  animes$!: Observable<IAnime[]>;           //danh sách dữ liệu ban đầu 
  pagedAnimes$!: Observable<IAnime[]>;      //danh sách dữ liệu đã phân trang cho trang hiện tại

  route = inject(ActivatedRoute);           //lấy tham số trong url
  animeService = inject(AnimeService);
  private cdr = inject(ChangeDetectorRef);  //Inject để báo hiệu cho Angular cập nhật giao diện

  ngOnInit(): void {
    this.loadAnimes();    //tải dữ liệu ban đầu
    this.paginateData();  //phân trang từ nguồn dữ liệu đầu
  }

  //tải dữ liệu ban đầu
  loadAnimes(): void {
    this.animes$ = this.route.queryParamMap.pipe(
      switchMap((params: ParamMap) => {
        this.queryString = params.get('q');
        this.cdr.detectChanges(); // Cập nhật giao diện sau khi gán queryString
        //toán tử ba ngôi (Ternary Operator)
        const apiCall = this.queryString
          ? this.animeService.searchAnimes(this.queryString)
          : this.animeService.searchAnimes("")

        return apiCall.pipe(
          catchError(error => {
            console.log(error);
            return of([]);
          })
        )
      }),
      shareReplay({ bufferSize: 1, refCount: true })
    );
  };

  //phân trang từ nguồn dữ liệu đầu
  paginateData(): void {
    this.length$ = this.animes$.pipe(map(animes => animes.length));

    this.pagedAnimes$ = combineLatest([
      this.animes$,
      this.pageEventSubject.asObservable()
    ]).pipe(
      map(([animes, pageEvent]) => {
        const startIndex = pageEvent.pageIndex * pageEvent.pageSize;
        const endIndex = startIndex + pageEvent.pageSize;

        return animes.slice(startIndex, endIndex);
      })
    );
  };

  handlePageEvent(event: PageEvent): void {
    this.pageEventSubject.next(event);
  };
}