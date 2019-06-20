import * as React from 'react';
import CharacterCard from './characterCard';

export interface IAccountRowProps {
    account: any;
}

class AccountRow extends React.Component<IAccountRowProps> {
    render() {
        console.log("accountRow. account", this.props.account);
        return (
            <div className="card mb-2 p-1 text-white bg-dark">
                <p>Name: {this.props.account.name}</p>
                <div className="d-inline-flex justify-content-start">
                    {this.props.account.characterIds && this.props.account.characterIds.map((character, index) =>
                        <CharacterCard key={index} character={character}/>
                    )}
                </div>
            </div>
        );
    }
}

export default AccountRow;