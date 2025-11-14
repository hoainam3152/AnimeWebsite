import { Component, inject } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { AccountService } from '../../../core/service/account.service';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-header',
  imports: [RouterLink, ReactiveFormsModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {
  searchInput = new FormControl('');

  accountService = inject(AccountService);
  router = inject(Router);

  handleLogout() {
    this.accountService.logout();
  }

  handleKeyupEnter(): void {
    const value = this.searchInput.value;
    this.router.navigate(['search'], {
      queryParams: { q: value }
    });
  }
}
