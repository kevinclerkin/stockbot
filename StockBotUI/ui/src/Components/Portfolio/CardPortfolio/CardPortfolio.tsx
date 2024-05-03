import React, { SyntheticEvent } from 'react'
import RemovePortfolio from '../RemovePortfolio/RemovePortfolio';

interface Props {
    portfolioItem: string;
    onPortfolioRemove: (e: SyntheticEvent) => void;
   
}

const CardPortfolio = ({portfolioItem, onPortfolioRemove}: Props) => {
  return (
    <>
    <div>{portfolioItem}</div>
    <RemovePortfolio onPortfolioRemove={onPortfolioRemove} portfolioItem={portfolioItem} />
    </>
  )
}

export default CardPortfolio