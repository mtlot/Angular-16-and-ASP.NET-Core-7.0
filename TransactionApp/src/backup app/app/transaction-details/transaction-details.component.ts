import { Component, OnInit } from '@angular/core';
import { TransactionDetailService } from '../shared/transaction-detail.service';
import { ToastrService } from 'ngx-toastr';
import { TransactionDetail } from '../shared/transaction-detail.model';

@Component({
  selector: 'app-transaction-details',
  templateUrl: './transaction-details.component.html',
  styles: [
  ]
})

export class TransactionDetailsComponent implements OnInit {
 
  constructor(public service: TransactionDetailService , private toastr: ToastrService) {
  }
  ngOnInit(): void{
    this.service.refreshList();
  }
  populateForm(selectedRecord: TransactionDetail) {
    this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(id: number) {
    if (confirm('Are you sure to delete this record?'))
      this.service.deleteTransactionDetail(id)
        .subscribe({
          next: (res:any) => {
            this.service.list = res as TransactionDetail[]
            this.toastr.error('Deleted successfully', 'Transaction Detail Register')
          },
          error: (err: any)=> { console.log(err) }
        })
  }

}
