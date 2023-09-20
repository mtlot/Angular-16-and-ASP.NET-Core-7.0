import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { AuthService } from '../services/auth.service';
import { User } from '../model/user';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, MatButtonModule, RouterLink],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  styles: [
  ]
})


export class HomeComponent implements OnInit {
  isAuthenticated!: boolean;
  user!: User;

  constructor(public auth: AuthService) {
  }

  async ngOnInit() {
    /*this.isAuthenticated = await this.auth.isAuthenticated();
    await this.auth.getUser().subscribe(data => this.user = data);
  */}

  logout(){
    this.auth.signOut();
  }

}

