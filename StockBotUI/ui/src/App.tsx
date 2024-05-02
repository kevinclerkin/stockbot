import React, { SyntheticEvent } from 'react';
import './App.css';
import CardList from './Components/CardList/CardList';
import Search from './Components/Search/Search';
import { Company } from './company';
import { searchCompany } from './FinPrepAPI';

function App() {
  const [search, setSearch] = React.useState<string>('');
  const [searchResults, setSearchResults] = React.useState<Company[]>([]);
  const [serverError, setServerError] = React.useState<string>('');
    const onHandleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setSearch(e.target.value);
        console.log(e);
    }

    const onClick = async (e: SyntheticEvent) => {
        const result = await searchCompany(search);
        if(typeof result === 'string') {
            setServerError(result);
        } else if (Array.isArray(result.data)) {
            setSearchResults(result.data);
        }
        console.log(searchResults);
    }
  return (
    <div className="App">
      <Search onClick={onClick} search={search} onHandleChange={onHandleChange} />
      {serverError && <h1>{serverError}</h1>}
      <CardList />
    </div>
  );
}

export default App;
