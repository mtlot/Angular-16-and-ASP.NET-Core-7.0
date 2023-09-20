import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

import { TransactionDetailService } from '../shared/transaction-detail.service';
import { TransactionDetail } from '../shared/transaction-detail.model';
import { AuthService } from './../services/auth.service';

@Component({
  selector: 'app-transaction-details',
  templateUrl: './transaction-details.component.html',
  styles: []
})
export class TransactionDetailsComponent implements OnInit {
  
  searchTerm: string = '';
  filteredList: any[] = []; // Corrected the variable name to 'filteredList'
  list: string = '';

  constructor(
    public service: TransactionDetailService, 
    private auth: AuthService, 
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.service.refreshList(); // Assuming this populates the 'list' property in service.
    
    this.list = this.list;
    console.log('Object list',this.list);
    this.filterList();
  }

  filterList() {
    if(!this.service.list) return;

    // Corrected the assignment from 'this.filterList' to 'this.filteredList'
    this.filteredList = this.service.list.filter(listItem => {
      return listItem.loT_NO.toString().toLowerCase().includes(this.searchTerm.toLowerCase());
    });
  }

  populateForm(selectedRecord: TransactionDetail) {
    this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(id: number) {
    if (confirm('Are you sure to delete this record?')) {
      this.service.deleteTransactionDetail(id).subscribe({
        next: (res: any) => {
          this.service.list = res as TransactionDetail[];
          this.toastr.error('Deleted successfully', 'Transaction Detail Register');
        },
        error: (err: any) => {
          console.log(err);
        }
      })
    }
  }

  logout() {
    this.auth.signOut();
  }
}
