import React from 'react'

interface Props {
    portfolio: string;
}

const CardPortfolio = ({portfolio}: Props) => {
  return (
    <div>{portfolio}</div>
  )
}

export default CardPortfolio