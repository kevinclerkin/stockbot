import React from 'react'
import './Card.css'
import { Company } from '../../company';
import AddPortfolio from '../Portfolio/AddPortfolio';

interface Props {
  id: string;
  searchResult: Company;
  onPortfolioAdd: (e: React.SyntheticEvent) => void;

}

const Card = ({id, searchResult, onPortfolioAdd}: Props) => {
  return (
    <div className="card">
      <div className="card-header">
        <h2>Stock</h2>
      </div>
      <div className="card-body">
        <h3>{searchResult.name}</h3>
        <p>${searchResult.stockExchange}</p>
        <AddPortfolio onPortfolioAdd={onPortfolioAdd} symbol={searchResult.symbol} />
      </div>
    </div>
  )
}

export default Card