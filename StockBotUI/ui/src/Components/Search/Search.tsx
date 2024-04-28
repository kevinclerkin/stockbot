import React, { SyntheticEvent } from 'react'

type Props = {}

const Search : React.FC<Props> = (props: Props): JSX.Element => {
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
    <div><input value={search} onChange={(e)=> onHandleChange(e)}></input>
    <button onClick={(e)=> onClick(e)}/></div>
  )
}

export default Search