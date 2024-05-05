import React from 'react'
import { useParams } from 'react-router-dom'
import { CompanyProfile } from '../../company';
import { getCompanyProfile } from '../../FinPrepAPI';
import { AxiosResponse } from 'axios';
import SideBar from '../../Components/SideBar/SideBar';
import Dashboard from '../../Components/Dashboard/Dashboard';
import Tile from '../../Components/Tile/Tile';

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
    <div className="w-full relative flex ct-docs-disable-sidebar-content overflow-x-hidden">
      <SideBar />
      <Dashboard>
        <Tile title="Stock" details={company.companyName}></Tile>
      </Dashboard>

  </div>
    ) : (
      <div>Company or Security Not Found</div>

    )}
    </>
  )
}

export default Stock