import * as React from 'react';
import PilotCard from './PilotCard';

export interface IAccountRowProps {
    account: any;
}

class AccountRow extends React.Component<IAccountRowProps> {
    render() {
        console.log("accountRow. account", this.props.account);
        return (
            <div className="account-row">
                <p>Account : {this.props.account.name}</p>
                {this.props.account.pilotIds && this.props.account.pilotIds.map((pilot, index) =>
                    <PilotCard key={index} pilot={pilot}/>
                )}
            </div>
        );
    }
}

export default AccountRow;