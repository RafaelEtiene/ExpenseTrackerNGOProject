import { TransactionViewModel } from "./transactionViewModel"

export interface TransactionInfoAnalytics {
  totalExpenses: number,
  totalIncome: number,
  balance: number,
  amountInMonths: AmountInMonth[],
  lastTransactions: TransactionViewModel[]
}

interface AmountInMonth {
  expenses: number,
  income: number,
  month: string
}