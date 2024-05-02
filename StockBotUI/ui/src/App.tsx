import React, { SyntheticEvent } from 'react';
import './App.css';
import CardList from './Components/CardList/CardList';
import Search from './Components/Search/Search';
import { Company } from './company';
import { searchCompany } from './FinPrepAPI';

function App() {
  const [search, setSearch] = React.useState<string>('');
  const [searchResults, setSearchResults] = React.useState<Company[]>([]);
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

    const onPortfolioAdd = (e: SyntheticEvent) => {
        e.preventDefault();
        console.log(e);
    }
  
  return (
    <div className="App">
      <Search onSearchSubmit={onSearchSubmit} search={search} onHandleSearchChange={onHandleSearchChange} />
      {serverError && <h1>{serverError}</h1>}
      <CardList searchResults={searchResults} onPortfolioAdd={onPortfolioAdd} />
    </div>
  );
}

export default App;
