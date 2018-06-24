import * as React from 'react';
import PilotCard from './PilotCard';

export interface IAccountRowProps {
    account: any;
}

class AccountRow extends React.Component<IAccountRowProps> {
    render() {
        console.log("accountRow. account", this.props.account);
        return (
            <div>
                {this.props.account && this.props.account.pilotIds.map((p, index) =>
                    <PilotCard key={index} pilot={p}/>
                )}
            </div>
        );
    }
}

export default AccountRow;