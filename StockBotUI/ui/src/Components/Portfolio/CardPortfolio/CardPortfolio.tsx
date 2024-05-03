import React, { SyntheticEvent } from 'react'
import RemovePortfolio from '../RemovePortfolio/RemovePortfolio';

interface Props {
    portfolioItem: string;
    onPortfolioRemove: (e: SyntheticEvent) => void;
   
}

const CardPortfolio = ({portfolioItem, onPortfolioRemove}: Props) => {
  return (
    <div className="flex flex-col w-full p-8 space-y-4 text-center rounded-lg shadow-lg md:w-1/3">
    <p className="pt-6 text-xl font-bold">{portfolioItem}</p>
    <RemovePortfolio
      portfolioItem={portfolioItem}
      onPortfolioRemove={onPortfolioRemove}
    />
  </div>
  )
}

export default CardPortfolio