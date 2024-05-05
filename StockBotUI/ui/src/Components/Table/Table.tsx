import React from 'react'
import { testIncomeStatementData } from './TableData'
import { Company } from '../../company';

const data = testIncomeStatementData;

const config = [
    {
        label: "Year",
        render: (company: Company) => company.name
    }
]

interface Props {}

const Table = (props: Props) => {
  return (
    <div>Table</div>
  )
}

export default Table