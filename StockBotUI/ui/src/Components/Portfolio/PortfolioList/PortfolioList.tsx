import React from 'react'
import CardPortfolio from '../CardPortfolio/CardPortfolio';

interface Props {
    portfolio: string[];
}

const PortfolioList = ({portfolio}: Props) => {
  return (
    <div>
        <h3>Portfolio</h3>
        {portfolio && portfolio.map((portfolioItem) => {
            return <CardPortfolio portfolio={portfolioItem} />
        })}
    </div>
  )
}

export default PortfolioList