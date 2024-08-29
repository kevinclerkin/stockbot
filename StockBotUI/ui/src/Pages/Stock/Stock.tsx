import React from 'react';
import { useParams } from 'react-router-dom';
import { CompanyProfile } from '../../company';
import { getCompanyProfile } from '../../Services/StockDataService';
import { AxiosResponse } from 'axios';
import SideBar from '../../Components/SideBar/SideBar';
import Dashboard from '../../Components/Dashboard/Dashboard';
import Tile from '../../Components/Tile/Tile';
import Spinner from '../../Components/Spinner/Spinner';

interface Props {}

const Stock: React.FC<Props> = () => {
  let { ticker } = useParams<{ ticker: string }>();
  const [company, setCompany] = React.useState<CompanyProfile | null>(null);
  //const [loading, setLoading] = React.useState<boolean>(true);
  ///const [error, setError] = React.useState<string | null>(null);

  React.useEffect(() => {
    /*if (!ticker) {
      setError("No ticker symbol provided");
      //setLoading(false);
      return;
    }*/

    const getStockProfileInit = async () => {
      try {
        console.log("Fetching company profile for ticker:", ticker);
        const result = await getCompanyProfile(ticker!) as AxiosResponse<CompanyProfile>;
        if (result) {
          setCompany(result.data);
        } else {
          console.log("No company data found");
        }
      } catch (error) {
        console.error("Error fetching company profile:", error);
        //setError("Error fetching company profile");
      } /*finally {
        setLoading(false);
      }*/
    };

    getStockProfileInit();
  }, [ticker]);

 

  return (
    <>
    {company ? (
    <div className="w-full relative flex ct-docs-disable-sidebar-content overflow-x-hidden">
      <SideBar />
      <Dashboard ticker={ticker!}>
        <Tile title="Stock" details={company.companyName}></Tile>
        <Tile title="Price" details={'$' + company.price.toString()}></Tile>
      </Dashboard>
      </div>
     ) : (
      <Spinner />
     )}
   </>
  );
}; 

export default Stock;
