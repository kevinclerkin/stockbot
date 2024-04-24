import React from 'react'
import './Card.css'
type Props = {}

const Card = (props: Props) => {
  return (
    <div className="card">
      <div className="card-header">
        <h2>Stock</h2>
      </div>
      <div className="card-body">
        <h3>AMZN</h3>
        <p>$177</p>
      </div>
    </div>
  )
}

export default Card