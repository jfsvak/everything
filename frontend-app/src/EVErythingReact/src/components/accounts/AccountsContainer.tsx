import * as React from 'react';
import { connect } from 'react-redux';
import * as accountsActions from '../../redux/accounts/actions';
import * as selectors from '../../redux/selectors';
import AccountRow from './AccountRow';
import { bindActionCreators } from 'redux';

export interface IAccountsContainerProps {
    accounts: any;
    getAccounts: Function;
}

class AccountsContainer extends React.Component<IAccountsContainerProps> {
    componentDidMount() {
        this.props.getAccounts();
    }

    render() {
        console.log("AccountList.accounts", this.props.accounts);
        return (
            <section className="p-3">
                <h1>Accounts</h1>
                <p>Coming soon (TM)...</p>
                {this.props.accounts && this.props.accounts.map((account, index) => 
                    <AccountRow key={index} account={account}/>
                )}
            </section>
        );
    }
}

function mapStateToProps(state) {
    return {
        accounts: selectors.getAllAccounts(state)
    };
};

function mapDispatchToProps(dispatch) {
    return {
        getAccounts: bindActionCreators(accountsActions.getAccounts as any, dispatch)
    };
}

export default connect(mapStateToProps, mapDispatchToProps)(AccountsContainer);