import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { AccountService } from '../../core/service/account.service';

const PUBLIC_URLS: string[] = [
  '/',
  '/sign-in',
  '/anime-detail'
];

export const tokenInterceptor: HttpInterceptorFn = (req, next) => {
  const isPulic = PUBLIC_URLS.some(url => req.url.includes(url));

  if (isPulic) {
    return next(req);
  }

  const auth = inject(AccountService);

  const authRequest = req.clone({
    setHeaders: {
      Authorization: `Bear ${auth.getToken}`
    }
  });

  return next(authRequest);
};
