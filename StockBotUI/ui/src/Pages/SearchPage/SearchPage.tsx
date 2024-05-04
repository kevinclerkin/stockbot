import React, { SyntheticEvent } from 'react'
import { Company } from '../../company';
import { searchCompany } from '../../FinPrepAPI';
import PortfolioList from '../../Components/Portfolio/PortfolioList/PortfolioList';
import CardList from '../../Components/CardList/CardList';
import Search from '../../Components/Search/Search';

interface Props {}

const SearchPage = (props: Props) => {
  const [search, setSearch] = React.useState<string>('');
  const [searchResults, setSearchResults] = React.useState<Company[]>([]);
  const [portfolio, setPortfolio] = React.useState<string[]>([]);
  const [serverError, setServerError] = React.useState<string | null>(null);

  const onHandleSearchChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setSearch(e.target.value);
    console.log(e);
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
    const exists = portfolio.find((value) => value === e.target[0].value);
    if(exists){return;}
    const updatedPortfolio = [...portfolio, e.target[0].value];
    setPortfolio(updatedPortfolio);
}

const onPortfolioRemove = (e: any) => {
    e.preventDefault();
    const updatedPortfolio = portfolio.filter((company) => company !== e.target[0].value);
    setPortfolio(updatedPortfolio);
}
  
  
  return (
    <>
      <Search onSearchSubmit={onSearchSubmit} search={search} onHandleSearchChange={onHandleSearchChange} />
      <PortfolioList portfolio={portfolio} onPortfolioRemove={onPortfolioRemove}/>
      {serverError && <h1>{serverError}</h1>}
      <CardList searchResults={searchResults} onPortfolioAdd={onPortfolioAdd} />
    </>
  )
}

export default SearchPage