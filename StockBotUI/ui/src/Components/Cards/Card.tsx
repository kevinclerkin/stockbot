import React from 'react'
import './Card.css'
import { Company } from '../../company';

interface Props {
  id: string;
  searchResult: Company;

}

const Card = ({id, searchResult}: Props) => {
  return (
    <div className="card">
      <div className="card-header">
        <h2>Stock</h2>
      </div>
      <div className="card-body">
        <h3>{searchResult.name}</h3>
        <p>${searchResult.stockExchange}</p>
      </div>
    </div>
  )
}

export default Card