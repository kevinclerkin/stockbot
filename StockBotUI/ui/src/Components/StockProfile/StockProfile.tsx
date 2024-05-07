import React, { useEffect } from 'react'
import { CompanyKeyMetrics } from '../../company';
import { useOutlet, useOutletContext } from 'react-router-dom';
import { getKeyMetrics } from '../../FinPrepAPI';
import { AxiosResponse } from 'axios';
import MetricsList from '../MetricsList/MetricsList';

interface Props {}

const tableConfig = [
  {
    label: "Market Cap",
    render: (company: CompanyKeyMetrics) => company.marketCapTTM,
  },
  {
    label: "Current Ratio",
    render: (company: CompanyKeyMetrics) => company.currentRatioTTM,
  },
  {
    label: "Return On Equity",
    render: (company: CompanyKeyMetrics) => company.roeTTM,
  },
  {
    label: "Cash Per Share",
    render: (company: CompanyKeyMetrics) => company.cashPerShareTTM,
  },
  {
    label: "Current Ratio",
    render: (company: CompanyKeyMetrics) => company.currentRatioTTM,
  },
  {
    label: "PE Ratio",
    render: (company: CompanyKeyMetrics) => company.peRatioTTM,
  },
];

const StockProfile = (props: Props) => {
  const ticker = useOutletContext<string>();
  const [stock, setStock] = React.useState<CompanyKeyMetrics>();
  useEffect(() => {
    const getStockKeyMetrics = async () => {
      const result = await getKeyMetrics(ticker!) as AxiosResponse<CompanyKeyMetrics[], any>;
      setStock(result?.data[0]);
    };
    getStockKeyMetrics();
  }, [ticker])
  return (
    <>
      {stock ? (
        <>
          <MetricsList config={tableConfig} data={stock} />
        </>
      ) : (
        <h1>No data found</h1>
      )}
    </>
  )
}

export default StockProfile