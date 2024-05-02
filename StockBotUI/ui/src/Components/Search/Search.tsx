import React, { SyntheticEvent } from 'react'

interface Props {
    onSearchSubmit: (e: SyntheticEvent) => void;
    search: string | undefined;
    onHandleSearchChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
}

const Search : React.FC<Props> = ({search, onSearchSubmit, onHandleSearchChange}: Props): JSX.Element => {
  
    return (
    <form onSubmit={onSearchSubmit}>
        <input value={search} onChange={onHandleSearchChange} />

    </form>
  )
}

export default Search