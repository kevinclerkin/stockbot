import React, { SyntheticEvent } from 'react'
import CardPortfolio from '../CardPortfolio/CardPortfolio';

interface Props {
    portfolio: string[];
    onPortfolioRemove: (e: SyntheticEvent) => void;
    
}

const PortfolioList = ({portfolio, onPortfolioRemove}: Props) => {
  return (
    <div>
        <h3>Portfolio</h3>
        {portfolio && portfolio.map((portfolioItem) => {
            return <CardPortfolio portfolioItem={portfolioItem} onPortfolioRemove={onPortfolioRemove}/>
        })}
    </div>
  )
}

export default PortfolioList