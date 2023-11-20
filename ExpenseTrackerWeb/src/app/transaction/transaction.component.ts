import { Component, OnInit } from '@angular/core';
import { TransactionViewModel } from '../interfaces/transactionViewModel';
import { TransactionService } from 'src/api/transaction.service';

@Component({
  selector: 'app-transaction',
  templateUrl: './transaction.component.html',
  styleUrls: ['./transaction.component.css']
})
export class TransactionComponent implements OnInit {
  ngOnInit(): void {
    this.getAllTransactions();
  }
  constructor(private transactionService: TransactionService) {}

  transactions: TransactionViewModel[] = [];
  transaction: TransactionViewModel = null!;
  showTemplate: boolean = false; 
  types = [{
      idType: 1,
      name: 'Expense'
    },
    {
      idType: 2,
      name: 'Income'
    }];
  
  public getAllTransactions() {
   this.transactionService.GetAllTransactions()
    .subscribe(r => {
      this.transactions = r;
    });
  }

  public showAddTemplate() {
    this.transaction = {
      idTransaction : 0,
      description: '',
      amount: 0,
      date: new Date(),
      type: 0
    };
    this.showTemplate = true;
  }

  public showUpdateTemplate(idTransaction: number) {
    this.transactionService.GetTransactionById(idTransaction)
    .subscribe(r => {
      this.transaction = r;
    });

    this.showTemplate = true;
  }

  public closeTemplate() {
    this.showTemplate = false;
  }

  public insertNewTransaction() {
    debugger
    if(this.transaction.idTransaction == 0){
      this.transactionService.InsertTransaction(this.transaction)
      .subscribe();
    }
    else{
      this.transactionService.UpdateTransaction(this.transaction)
        .subscribe();
    }
    location.reload();
  }

  public removeTransaction(idTransaction: number) {
    this.transactionService.DeleteTransaction(idTransaction)
      .subscribe();

    location.reload();
  }
}

