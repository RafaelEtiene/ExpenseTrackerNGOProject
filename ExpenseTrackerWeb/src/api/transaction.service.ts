import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TransactionViewModel } from 'src/app/interfaces/transactionViewModel';
import { TransactionInfoAnalytics } from 'src/app/interfaces/transactionInfoAnalytics';

@Injectable({
  providedIn: 'root'
})

export class TransactionService {
  private basePath: string = 'http://localhost:5154';

  constructor(private httpClient: HttpClient) {}

  public GetAllTransactions() : Observable<TransactionViewModel[]> {
    return this.httpClient.get<TransactionViewModel[]>(`${this.basePath}/Transaction/GetAllTransactions`);
  }

  public GetTransactionInfoAnalytics() : Observable<TransactionInfoAnalytics> {
    return this.httpClient.get<TransactionInfoAnalytics>(`${this.basePath}/Transaction/GetTransactionInfoAnalytics`);
  }

  public InsertTransaction(transaction: TransactionViewModel) : Observable<any> {
    return this.httpClient.post<any>(`${this.basePath}/Transaction/GetTransactionInfoAnalytics`, transaction);
  }

  public UpdateTransaction(transaction: TransactionViewModel) : Observable<any> {
    return this.httpClient.put<any>(`${this.basePath}/Transaction/UpdateTransaction`, transaction);
  }

  public DeleteTransaction(idTransaction: number) : Observable<any> {
    return this.httpClient.delete<any>(`${this.basePath}/Transaction/DeleteTransaction/${idTransaction}`);
  }
}
