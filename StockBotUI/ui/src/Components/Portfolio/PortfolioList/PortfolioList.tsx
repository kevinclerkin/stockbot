import React, { SyntheticEvent } from 'react'
import CardPortfolio from '../CardPortfolio/CardPortfolio';

interface Props {
    portfolio: string[];
    onPortfolioRemove: (e: SyntheticEvent) => void;
    
}

const PortfolioList = ({portfolio, onPortfolioRemove}: Props) => {
  return (
    <section id="portfolio">
      <h2 className="mb-3 mt-3 text-3xl font-semibold text-center md:text-4xl">
        My Portfolio
      </h2>
      <div className="relative flex flex-col items-center max-w-5xl mx-auto space-y-10 px-10 mb-5 md:px-6 md:space-y-0 md:space-x-7 md:flex-row">
        <>
          {portfolio.length > 0 ? (
            portfolio.map((portfolioItem) => {
              return (
                <CardPortfolio
                  portfolioItem={portfolioItem}
                  onPortfolioRemove={onPortfolioRemove}
                />
              );
            })
          ) : (
            <h3 className="mb-3 mt-3 text-xl font-semibold text-center md:text-xl">
              No Portfolio.
            </h3>
          )}
        </>
      </div>
    </section>
  )
}

export default PortfolioList