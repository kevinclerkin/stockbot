import React from 'react'
import './Card.css'

interface Props {
  companyName: string;
  stockPrice: number;

}

const Card = ({companyName, stockPrice}: Props) => {
  return (
    <div className="card">
      <div className="card-header">
        <h2>Stock</h2>
      </div>
      <div className="card-body">
        <h3>{companyName}</h3>
        <p>${stockPrice}</p>
      </div>
    </div>
  )
}

export default Card