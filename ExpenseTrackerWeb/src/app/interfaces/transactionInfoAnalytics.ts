import { TransactionViewModel } from "./transactionViewModel"

export interface TransactionInfoAnalytics {
  totalExpenses: number,
  totalIncome: number,
  balance: number,
  amountInMonths: AmountInMonth[],
  lastTransactions: TransactionViewModel[]
}

export interface AmountInMonth {
  expenses: number,
  incomes: number,
  month: string
}