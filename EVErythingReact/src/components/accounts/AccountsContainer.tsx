import * as React from 'react';
import { connect } from 'react-redux';
import * as accountsActions from '../../actions/accountsActions';
import AccountRow from './AccountRow';
import { bindActionCreators } from 'redux';

export interface IAccountsContainerProps {
    accounts: any;
    accountsActions: any;
}

class AccountsContainer extends React.Component<IAccountsContainerProps> {
    componentDidMount() {
        console.log("In AccountsContainer.componentDidMount:");
        this.props.accountsActions.getAccounts().then(() => {
            // do whatever, but its voluntary. 
            // Data is now already available in props/state if subscribed to in reduc
        });
    }

    render() {
        console.log("AccountsContainer.accounts", this.props.accounts);
        return (
            <div>
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

function mapDispatchToProps(dispatch) {
    return {
        accountsActions: bindActionCreators(accountsActions as any, dispatch)
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(AccountsContainer);