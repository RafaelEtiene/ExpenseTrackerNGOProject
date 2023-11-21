import { Component, OnInit } from '@angular/core';
import { Chart } from 'chart.js';
import { TransactionViewModel } from '../interfaces/transactionViewModel';
import { TransactionService } from 'src/api/transaction.service';
import { AmountInMonth, TransactionInfoAnalytics } from '../interfaces/transactionInfoAnalytics';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  constructor(private transactionService: TransactionService) {}

  ngOnInit(): void {
    this.getTransactionInfoAnalytics();
    this.getAllTransactions();
  }
  
  transactions: TransactionViewModel[] = [];
  transactionsInfoAnalytics: TransactionInfoAnalytics = null!
  amountMonth: AmountInMonth[] = [];
  chart: any;

  public getAllTransactions() {
    this.transactionService.GetAllTransactions()
     .subscribe(r => {
       this.transactions = r;
     });
   }

   public getTransactionInfoAnalytics() {
    this.transactionService.GetTransactionInfoAnalytics()
     .subscribe(r => {
       this.transactionsInfoAnalytics = r;
       this.amountMonth = r.amountInMonths;
       this.generateGraphic();
     });
   }

  generateGraphic() {
    const expensesData = this.amountMonth.map(e => e.expenses);
    const incomesData = this.amountMonth.map(e => e.incomes);
    console.log(incomesData)

    this.chart = new Chart("MyChart", {
      type: 'bar', //this denotes tha type of chart

      data: {// values on X-Axis
        labels: ['January', 'February', 'March','April',
								 'May', 'June', 'July','August', 'September', 'October', 'November', 'December' ], 
	       datasets: [
          {
            label: "Expenses",
            data: expensesData,
            backgroundColor: 'blue'
          },
          {
            label: "Incomes",
            data: incomesData,
            backgroundColor: 'limegreen'
          }  
        ]
      },
      options: {
        aspectRatio:2.5
      }
    });
  }
}
