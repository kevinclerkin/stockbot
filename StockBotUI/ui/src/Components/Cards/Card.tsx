import React from 'react'
import './Card.css'
import { Company } from '../../company';
import AddPortfolio from '../Portfolio/AddPortfolio';
import { Link } from 'react-router-dom';

interface Props {
  id: string;
  searchResult: Company;
  onPortfolioAdd: (e: React.SyntheticEvent) => void;

}

const Card = ({id, searchResult, onPortfolioAdd}: Props) => {
  return (
    <div
      className="flex flex-col items-center justify-between w-full p-6 bg-slate-100 rounded-lg md:flex-row"
      key={id}
      id={id}
    >
      <Link to={`/stock/${searchResult.symbol}`} className="font-bold text-center text-veryDarkViolet md:text-left">
        {searchResult.name} ({searchResult.symbol})
      </Link>
      <p className="text-veryDarkBlue">{searchResult.currency}</p>
      <p className="font-bold text-veryDarkBlue">
        {searchResult.exchangeShortName} - {searchResult.stockExchange}
      </p>
      <AddPortfolio
        onPortfolioAdd={onPortfolioAdd}
        symbol={searchResult.symbol}
      />
    </div>
  )
}

export default Card