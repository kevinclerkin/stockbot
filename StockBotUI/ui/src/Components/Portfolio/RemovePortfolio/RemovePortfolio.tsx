import React, { SyntheticEvent } from 'react'

interface Props {
    onPortfolioRemove: (e: SyntheticEvent) => void;
    portfolioItem: string;
}

const RemovePortfolio = ({onPortfolioRemove, portfolioItem}: Props) => {
  return (
    <div>
        <form onSubmit={onPortfolioRemove}>
            <input hidden={true} value={portfolioItem} />
            <button>Remove</button>
        </form>
    </div>
  )
}

export default RemovePortfolio