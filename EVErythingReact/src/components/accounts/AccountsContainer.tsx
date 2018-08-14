import * as React from 'react';
import { connect } from 'react-redux';
import * as accountsActions from '../../actions/accountsActions';
import AccountRow from './AccountRow';
import { bindActionCreators } from 'redux';

export interface IAccountListProps {
    accounts: any;
}

class AccountList extends React.Component<IAccountListProps> {

    render() {
        console.log("AccountList.accounts", this.props.accounts);
        return (
            <div className="account-list">
                <h1>Accounts. Coming soon...</h1>
                {this.props.accounts && this.props.accounts.map((account, index) => 
                    <AccountRow key={index} account={account}/>
                )}
            </div>
        );
    }
}

function mapStateToProps(state) {
    return {
        accounts: state.accounts
    };
};

export default connect(mapStateToProps)(AccountList);