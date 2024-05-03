import React, { SyntheticEvent } from 'react'

interface Props {
    portfolio: string;
    onPortfolioRemove: (e: SyntheticEvent) => void;
}

const CardPortfolio = ({portfolio, onPortfolioRemove}: Props) => {
  return (
    <div>{portfolio}</div>
  )
}

export default CardPortfolio