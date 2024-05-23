import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  isLoggedIn: boolean = false;
  isAdmin: boolean = false;
  isUser: boolean = false;

  constructor(private authService: AuthService, private router: Router) {
    this.authService.isAuthenticated$.subscribe((authenticated) => {
      console.log('Authenticated:', authenticated); // Debug log
      this.isLoggedIn = authenticated;
      if (this.isLoggedIn) {
        this.authService.getUserRole().subscribe((role) => {
          console.log('Role:', role); // Debug log
          this.isAdmin = this.authService.isAdmin();
          this.isUser = this.authService.isUser();
          console.log('isAdmin:', this.isAdmin); // Debug log
          console.log('isUser:', this.isUser); // Debug log
        });
      } else {
        this.isAdmin = false;
        this.isUser = false;
      }
    });
  }

  ngOnInit(): void {
    this.isLoggedIn = this.authService.isAuthenticated();
    console.log('Initial isLoggedIn:', this.isLoggedIn); // Debug log
    if (this.isLoggedIn) {
      this.authService.getUserRole().subscribe((role) => {
        console.log('Initial Role:', role); // Debug log
        this.isAdmin = this.authService.isAdmin();
        this.isUser = this.authService.isUser();
        console.log('Initial isAdmin:', this.isAdmin); // Debug log
        console.log('Initial isUser:', this.isUser); // Debug log
      });
    }
  }

  logout(): void {
    this.isLoggedIn = false;
    this.isAdmin = false;
    this.isUser = false;
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
