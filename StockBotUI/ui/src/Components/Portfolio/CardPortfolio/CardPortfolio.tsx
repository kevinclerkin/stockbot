import React, { SyntheticEvent } from 'react'
import RemovePortfolio from '../RemovePortfolio/RemovePortfolio';
import { Link } from 'react-router-dom';
import { GetPortfolio } from '../../../Models/Portfolio';

interface Props {
    portfolioItem: GetPortfolio;
    onPortfolioRemove: (e: SyntheticEvent) => void;
   
}

const CardPortfolio = ({portfolioItem, onPortfolioRemove}: Props) => {
  return (
    <div className="flex flex-col w-full p-8 space-y-4 text-center rounded-lg shadow-lg md:w-1/3">
    <Link to={`/stock/${portfolioItem.symbol}/stock-profile`} className="pt-6 text-xl font-bold">{portfolioItem.symbol}</Link>
    <RemovePortfolio
      portfolioItem={portfolioItem.symbol}
      onPortfolioRemove={onPortfolioRemove}
    />
  </div>
  )
}

export default CardPortfolio