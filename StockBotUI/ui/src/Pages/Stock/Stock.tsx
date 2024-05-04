import React from 'react'
import { useParams } from 'react-router-dom'
import { CompanyProfile } from '../../company';
import { getCompanyProfile } from '../../FinPrepAPI';
import { AxiosResponse } from 'axios';

interface Props {}

const Stock = (props: Props) => {
  let {ticker} = useParams();
  const [company, setCompany] = React.useState<CompanyProfile>();

  React.useEffect(() => {
    const getStockProfileInit = async () => {
      const result = await getCompanyProfile(ticker!) as AxiosResponse<CompanyProfile[], any>;
      setCompany(result?.data[0]);
    }
    getStockProfileInit();
  }, [])
  return (
    <>
    { company ? (
    <div>{company?.companyName} {company?.exchange} {company?.mktCap}</div>
    ) : (
      <div>Company or Security Not Found</div>

    )}
    </>
  )
}

export default Stock