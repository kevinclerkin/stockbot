import React, { SyntheticEvent } from 'react'
import { Company } from '../../company';
import { searchCompany } from '../../FinPrepAPI';
import PortfolioList from '../../Components/Portfolio/PortfolioList/PortfolioList';
import CardList from '../../Components/CardList/CardList';
import Search from '../../Components/Search/Search';
import { GetPortfolio } from '../../Models/Portfolio';
import { AddPortfolioFromAPI, DeletePortfolioFromAPI, GetPortfolioFromAPI } from '../../Services/PortfolioService';

interface Props {}

const SearchPage = (props: Props) => {
  const [search, setSearch] = React.useState<string>('');
  const [searchResults, setSearchResults] = React.useState<Company[]>([]);
  const [portfolio, setPortfolio] = React.useState<GetPortfolio[] | null>([]);
  const [serverError, setServerError] = React.useState<string | null>(null);

  const onHandleSearchChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setSearch(e.target.value);
    console.log(e);
}

React.useEffect(() => {
  getPortfolio();
}, []);

const getPortfolio = async () => {
  GetPortfolioFromAPI().then((res) => {
    if(res?.data) {
      setPortfolio(res.data);
    }
  }).catch((e) => {
    console.log(e);
  });
}

const onSearchSubmit = async (e: SyntheticEvent) => {
    e.preventDefault();
    const result = await searchCompany(search);
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
      if(res?.status === 204) {
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
      {serverError && <h1>{serverError}</h1>}
      <CardList searchResults={searchResults} onPortfolioAdd={onPortfolioAdd} />
    </>
  )
}

export default SearchPage