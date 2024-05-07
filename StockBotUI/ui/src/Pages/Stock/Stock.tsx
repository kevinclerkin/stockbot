import React from 'react'
import { useParams } from 'react-router-dom'
import { CompanyProfile } from '../../company';
import { getCompanyProfile } from '../../FinPrepAPI';
import { AxiosResponse } from 'axios';
import SideBar from '../../Components/SideBar/SideBar';
import Dashboard from '../../Components/Dashboard/Dashboard';
import Tile from '../../Components/Tile/Tile';
import Spinner from '../../Components/Spinner/Spinner';

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
  }, [ticker])
  return (
    <>
    { company ? (
    <div className="w-full relative flex ct-docs-disable-sidebar-content overflow-x-hidden">
      <SideBar />
      <Dashboard ticker={ticker!}>
        <Tile title="Stock" details={company.companyName}></Tile>
        <Tile title="Price" details={company.price.toString()}></Tile>
        <p className="bg-white shadow rounded text-medium font-medium text-gray-900 p-3 mt-1 m-4">
              {company.description}
        </p>
      </Dashboard>

  </div>
    ) : (
      <Spinner />

    )}
    </>
  )
}

export default Stock