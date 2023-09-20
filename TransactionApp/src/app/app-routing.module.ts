import { DashboardComponent } from './components/dashboard/dashboard.component';
import { SignupComponent } from './components/signup/signup.component';
import { LoginComponent } from './components/login/login.component';
import { TransactionDetailsComponent } from './transaction-details/transaction-details.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { GroupListComponent } from './group-list/group-list.component';
import { GroupEditComponent } from './group-edit/group-edit.component';
import { AuthGuard } from './guards/auth.guard';

export const routes: Routes = [
  
  { path:'', redirectTo:'login', pathMatch:'full'},

  { path:'login',
    component:LoginComponent},

  { path:'signup',
    component:SignupComponent},

  { path:'dashboard', component:DashboardComponent, canActivate:[AuthGuard]},
  { path:'transaction', component:TransactionDetailsComponent},

  { path: '', redirectTo: '/home', pathMatch: 'full' },
  {
    path: 'home',
    component: HomeComponent
  },
  {
    path: 'groups',
    component: GroupListComponent
  },
  {
    path: 'group/:id',
    component: GroupEditComponent
  }
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }