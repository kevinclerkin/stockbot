import React, { SyntheticEvent } from 'react'

interface Props {
    onClick: (e: SyntheticEvent) => void;
    search: string | undefined;
    onHandleChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
}

const Search : React.FC<Props> = ({onClick, search, onHandleChange}: Props): JSX.Element => {
  
    return (
    <div><input value={search} onChange={(e)=> onHandleChange(e)}></input>
    <button onClick={(e)=> onClick(e)}/></div>
  )
}

export default Search