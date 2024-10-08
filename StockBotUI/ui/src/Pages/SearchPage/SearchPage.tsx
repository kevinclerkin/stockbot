import React, { SyntheticEvent } from 'react'
import { Company } from '../../company';
import PortfolioList from '../../Components/Portfolio/PortfolioList/PortfolioList';
import CardList from '../../Components/CardList/CardList';
import Search from '../../Components/Search/Search';
import { GetPortfolio } from '../../Models/Portfolio';
import { AddPortfolioFromAPI, DeletePortfolioFromAPI, GetPortfolioFromAPI } from '../../Services/PortfolioService';
import { getStockData } from '../../Services/StockDataService';

interface Props {}

const SearchPage = (props: Props) => {
  const [search, setSearch] = React.useState<string>('');
  const [portfolio, setPortfolio] = React.useState<GetPortfolio[] | null>([]);
  const [searchResults, setSearchResults] = React.useState<Company[]>([]);
  const [serverError, setServerError] = React.useState<string | null>(null);

  React.useEffect(() => {
    getPortfolio();
  }, []);

  const onHandleSearchChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setSearch(e.target.value);
};

const getPortfolio = () => {
  GetPortfolioFromAPI().then((res) => {
    if(res?.data) {
      setPortfolio(res?.data);
    }
  }).catch((e) => {
    setPortfolio(null);
  });
}

const onSearchSubmit = async (e: SyntheticEvent) => {
    e.preventDefault();
    const result = await getStockData(search);
    if(typeof result === 'string') {
        setServerError(result);
    } else if (Array.isArray(result.data)) {
        setSearchResults(result.data);
    }
    console.log(searchResults);
}

const onPortfolioAdd = (e: any) => {
    e.preventDefault();
    AddPortfolioFromAPI(e.target[0].value).then((res) => {
      if(res?.status === 200) {
        getPortfolio();
      }
    }).catch((e) => {
      console.log(e);
    });
}

const onPortfolioRemove = (e: any) => {
    e.preventDefault();
    DeletePortfolioFromAPI(e.target[0].value).then((res) => {
      if(res?.status === 200) {
        getPortfolio();
      }
    }).catch((e) => {
      console.log(e);
    });
}
  
  
  return (
    <>
      <Search onSearchSubmit={onSearchSubmit} search={search} onHandleSearchChange={onHandleSearchChange} />
      <PortfolioList portfolio={portfolio!} onPortfolioRemove={onPortfolioRemove}/>
      <CardList searchResults={searchResults} onPortfolioAdd={onPortfolioAdd} />
      {serverError && <h1>{serverError}</h1>}
    </>
  )
}

export default SearchPage