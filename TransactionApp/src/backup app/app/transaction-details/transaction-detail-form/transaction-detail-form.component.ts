import { Component } from '@angular/core';
import { TransactionDetailService } from 'src/app/shared/transaction-detail.service';
import { NgForm } from '@angular/forms';
import { TransactionDetail } from 'src/app/shared/transaction-detail.model';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-transaction-detail-form',
  templateUrl: './transaction-detail-form.component.html',
  styles: [
  ]
})

export class TransactionDetailFormComponent {

  constructor(public service: TransactionDetailService, private toastr:ToastrService) {
  }
    onSubmit(form: NgForm) {
      this.service.formSubmitted = true
      if (form.valid) {
        if (this.service.formData.transactionDetailId == 0)
          this.insertRecord(form)
        else
          this.updateRecord(form)
      }
  
    }
  
    insertRecord(form: NgForm) {
      this.service.postTransactionDetail()
        .subscribe({
          next: res => {
            this.service.list = res as TransactionDetail[]
            this.service.resetForm(form)
            this.toastr.success('Inserted successfully', 'Transaction Detail Register')
          },
          error: err => { console.log(err) }
        })
    }
    updateRecord(form: NgForm) {
      this.service.putTransactionDetail()
        .subscribe({
          next: res => {
            this.service.list = res as TransactionDetail[]
            this.service.resetForm(form)
            this.toastr.info('Updated successfully', 'Transaction Detail Register')
          },
          error: err => { console.log(err) }
        })
     }
  
  }


