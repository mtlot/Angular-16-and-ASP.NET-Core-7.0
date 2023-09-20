import { Injectable } from '@angular/core';
import { TransactionDetail } from '../shared/transaction-detail.model';
import { Event } from './event';
import { Group } from './group';

@Injectable({
  providedIn: 'root'
})
export class TransactionDetailMapper {

  constructor() { }

  mapToEvent(transaction: TransactionDetail): Event {
    return new Event({
      id: transaction.transactionDetailId,
      date: transaction.loG_CREATED_TS, 
      title: transaction.deeD_INO
    });
  }

  mapToGroup(transaction: TransactionDetail): Group {
    return new Group({
      id: transaction.transactionDetailId,
      name: transaction.conV_DEED_ABBREVIATION,
      events: [this.mapToEvent(transaction)] 
    });
  }
  
}
