import React, { SyntheticEvent } from "react";
import Card from "../Cards/Card";
import { Company } from "../../company";
import { v4 as uuidv4 } from "uuid";

interface Props {
  searchResults: Company[];
  onPortfolioAdd: (e: SyntheticEvent) => void;
  
}

const CardList: React.FC<Props> = ({
  searchResults,
  onPortfolioAdd,
}: Props): JSX.Element => {
  return (
    <div>
      {searchResults.length > 0 ? (
        searchResults.map((result) => {
          return (
            <Card
              id={result.symbol}
              key={uuidv4()}
              searchResult={result}
              onPortfolioAdd={onPortfolioAdd}
            />
          );
        })
      ) : (
        <p className="mb-3 mt-3 text-xl font-semibold text-center md:text-xl">
          Search companies to add to portfolio!
        </p>
      )}
    </div>
  );
};

export default CardList;