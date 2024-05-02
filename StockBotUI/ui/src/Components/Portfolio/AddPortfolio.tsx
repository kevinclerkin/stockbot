import React, { SyntheticEvent } from 'react'

interface Props {
  onPortfolioAdd: (e: SyntheticEvent) => void;
  symbol: string;
}

const AddPortfolio = ({onPortfolioAdd, symbol}: Props) => {
  return (
    <form onSubmit={onPortfolioAdd}>
      <input readOnly={true} hidden={true} value={symbol} />
      <button type="submit">Add to Portfolio</button>
      </form>
)}

export default AddPortfolio