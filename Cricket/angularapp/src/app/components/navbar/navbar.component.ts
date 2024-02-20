import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  showLogoutPopup = false;
  isLoggedIn: boolean = false;
  userRole: string;

  constructor(private authService: AuthService, private router: Router) {
    this.authService.isAuthenticated$.subscribe((authenticated: boolean) => {
      this.isLoggedIn = authenticated;
      this.userRole = localStorage.getItem('userRole');
    });
  }

  ngOnInit(): void {
    // Initialize the properties on component initialization
    this.isLoggedIn = this.authService.isAuthenticated();
    this.userRole = localStorage.getItem('userRole');
    console.log(this.userRole)
  }

  logout(): void {
    this.isLoggedIn = false;
    this.authService.logout();
    this.router.navigate(['/login']);
  }

}
