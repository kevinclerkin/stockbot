import React from "react";
import { TestDataCompany } from "../../Components/Table/TableData";
import MetricsList from "../../Components/MetricsList/MetricsList";
import Table from "../../Components/Table/Table";

type Props = {
  
}

const data = TestDataCompany;

const tableConfig = [
  {
    label: "symbol",
    render: (company: any) => company.symbol,
  },
];

const DesignPage = (props: Props) => {
  return (
    <>
    
      <MetricsList config={tableConfig} data={data} />
      <Table config={tableConfig} data={data} />
    
    </>
  )
}

export default DesignPage