import React from 'react'
import Card from '../Cards/Card'

interface Props {}

const CardList = (props: Props) => {
  return (
    <div>
    <Card companyName='AMZN' stockPrice={1173}  />
    <Card companyName='AAPL' stockPrice={877} />
    <Card companyName='MSFT' stockPrice={216} />
    
    </div>
  )
}

export default CardList