import * as React from 'react';
import PilotCard from './PilotCard';

export interface IAccountRowProps {
    account: any;
}

class AccountRow extends React.Component<IAccountRowProps> {
    render() {
        console.log("accountRow. account", this.props.account);
        return (
            <div className="row">
                {this.props.account && this.props.account.pilotIds.map((p, index) =>
                    <div className="col-sm-6" key={index}>
                        <PilotCard key={index} pilot={p}/>
                    </div>
                )}
            </div>
        );
    }
}

export default AccountRow;