import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { environment } from 'src/environments/environment';
import { TransactionDetail } from './transaction-detail.model';
import { NgForm } from '@angular/forms';


@Injectable({
  providedIn: 'root'
})
export class TransactionDetailService {
  filter(arg0: (list: any) => any): () => void {
    throw new Error('Method not implemented.');
  }

  url: string = environment.apiBaseUrl + '/TransactionDetail';
  list: TransactionDetail[] = [];
  formData : TransactionDetail = new TransactionDetail();
  formSubmitted: boolean = false;

  constructor(private http: HttpClient) { }

  refreshList(){
    this.http.get(this.url)
      .subscribe ({
        next: res => 
          { this.list = res as TransactionDetail[]
        }, 
         error: err => { console.log(err)}
    })
  
  }
  filterList(){
    this.http.get(this.url)
      .subscribe ({
        next: res => 
          { this.list = res as TransactionDetail[]
        }, 
         error: err => { console.log(err)}
    })
  
  }
   postTransactionDetail(){
    return this.http.post(this.url,this.formData)
   } 
   

   putTransactionDetail() {
    return this.http.put(this.url + '/' + this.formData.transactionDetailId, this.formData)
  }


  deleteTransactionDetail(id: number) {
    return this.http.delete(this.url + '/' + id)
  }


  resetForm(form: NgForm) {
    form.form.reset()
    this.formData = new TransactionDetail()
    this.formSubmitted = false
  }
}