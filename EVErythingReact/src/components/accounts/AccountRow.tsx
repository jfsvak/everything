import * as React from 'react';
import CharacterCard from './characterCard';

export interface IAccountRowProps {
    account: any;
}

class AccountRow extends React.Component<IAccountRowProps> {
    render() {
        console.log("accountRow. account", this.props.account);
        return (
            <div className="account-row">
                <p>Account : {this.props.account.name}</p>
                {this.props.account.characterIds && this.props.account.characterIds.map((character, index) =>
                    <CharacterCard key={index} character={character}/>
                )}
            </div>
        );
    }
}

export default AccountRow;