import React, { SyntheticEvent } from 'react';
import './App.css';
import CardList from './Components/CardList/CardList';
import Search from './Components/Search/Search';

function App() {
  const [search, setSearch] = React.useState<string>('');
    const onHandleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setSearch(e.target.value);
        console.log(e);
    }

    const onClick = (e: SyntheticEvent) => {
        e.preventDefault();
        console.log(search);
    }
  return (
    <div className="App">
      <Search onClick={onClick} search={search} onHandleChange={onHandleChange} />
      <CardList />
    </div>
  );
}

export default App;
