import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { AnimeDetailComponent } from './pages/anime-detail/anime-detail.component';

export const routes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'anime-detail/:id', component: AnimeDetailComponent},
    // { 
    //     path: 'anime-detail/:id', 
    //     loadComponent: () => import('./pages/anime-detail/anime-detail.component').then((m) => m.AnimeDetailComponent),
    // },
    { 
        path: 'anime-watching', 
        loadComponent: () => import('./pages/anime-watching/anime-watching.component').then((m) => m.AnimeWatchingComponent),
    },
    { 
        path: 'sign-in', 
        loadComponent: () => import('./pages/sign-in/sign-in.component').then((m) => m.SignInComponent),
    },
    { 
        path: 'sign-up', 
        loadComponent: () => import('./pages/sign-up/sign-up.component').then((m) => m.SignUpComponent),
    },
];
