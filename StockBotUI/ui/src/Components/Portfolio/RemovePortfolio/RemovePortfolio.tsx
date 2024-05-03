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
            <button className="block w-full py-3 text-white duration-200 border-2 rounded-lg bg-black-500 hover:text-red-500 hover:bg-white border-red-500">
          Remove
        </button>
        </form>
    </div>
  )
}

export default RemovePortfolio