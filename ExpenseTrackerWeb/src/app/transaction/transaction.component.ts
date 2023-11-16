import { Component, OnInit } from '@angular/core';
import { TransactionViewModel } from '../interfaces/transactionViewModel';
import { TransactionService } from 'src/api/transaction.service';
import { CurrencyPipe } from '@angular/common';


@Component({
  selector: 'app-transaction',
  templateUrl: './transaction.component.html',
  styleUrls: ['./transaction.component.css']
})
export class TransactionComponent implements OnInit {
  ngOnInit(): void {
    this.GetAllTransactions();
  }
  constructor(private transactionSerivce: TransactionService, private currencyPipe: CurrencyPipe) {}

  transactions: TransactionViewModel[] = [];
  transaction: TransactionViewModel = null!;
  showTemplate: boolean = false; 

  public GetAllTransactions() {
   this.transactionSerivce.GetAllTransactions()
    .subscribe(r => {
      this.transactions = r;
    });
  }

  public ShowAddTemplate() {
    this.showTemplate = true;
    this.transaction = {
      idTransaction : 0,
      description: '',
      amount: 0,
      date: new Date(),
      type: 0
    };
  }

  public CloseTemplate() {
    this.showTemplate = false;
  }
}
