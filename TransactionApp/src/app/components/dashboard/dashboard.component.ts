import { AuthService } from './../../services/auth.service';
import { ApiService } from './../../services/api.service';
import { Component, OnInit } from '@angular/core';
import { UserStoreService } from 'src/app/services/user-store.service';
import { User } from './user.model'; 

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  public users: User[] = []; // typed as User[]
  public role!:string;
  filteredUsers: User[] = []; // typed as User[]
  searchTerm = '';
  

  public fullName : string = "";
  constructor(private api : ApiService, private auth: AuthService, private userStore: UserStoreService) { }

  ngOnInit() {
    this.api.getUsers()
    .subscribe((users: User[]) => { 
      // typed response as User[]
      this.users = users;
      console.log('Object Users',this.users);
      this.filterUsers();
    });

    this.userStore.getFullNameFromStore()
    .subscribe(val=>{
      const fullNameFromToken = this.auth.getfullNameFromToken();
      this.fullName = val || fullNameFromToken
      console.log('user current:',this.userStore)
    });

    this.userStore.getRoleFromStore()
    .subscribe(val=>{
      const roleFromToken = this.auth.getRoleFromToken();
      this.role = val || roleFromToken;
    })
  }
  // dashboard.component.ts

  filterUsers() {
  if(!this.users) return;
  this.filteredUsers = this.users.filter((user) => {
    return user.firstName.toLowerCase().includes(this.searchTerm.toLowerCase()); 
  });
  }

  Transaction(){
    this.auth.Transaction();
  }
  Groups(){
    this.auth.Groups();
  }
  Home(){
    this.auth.Home();
  }

  logout(){
    this.auth.signOut();
  }

}
