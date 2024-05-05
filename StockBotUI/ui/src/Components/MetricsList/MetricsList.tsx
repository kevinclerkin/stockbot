import React from 'react'
import { TestDataCompany } from '../Table/TableData'

type Props = {}

const data = TestDataCompany[0];

type Company = typeof data;

const MetricsList = (props: Props) => {
  return (
    <div>MetricsList</div>
  )
}

export default MetricsList