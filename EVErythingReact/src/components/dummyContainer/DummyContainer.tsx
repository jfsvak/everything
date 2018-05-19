import * as React from 'react';
import { withRouter } from 'react-router-dom';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import * as dummyActions from '../../actions/dummyActions';
import TextInput from '../common/elements/TextInput';
import Button from '../common/elements/Button';
import { navigate } from '../../utils/navigateUtil';
import { responseInterceptor } from '../../utils/responseInterceptor';
import { AppLanguageText } from '../../models/languageModel';

//sample image rendering
const testImg = require('../../assets/images/test.png');

export interface IDummyContainerProps {
    example: string,
    history: any;
    actions: any;
    dummyResult: any;
    language: AppLanguageText;
    changeLanguage: (code: string) => void;
}

export interface IDummyContainerState {
    textValue: string;
    dummyList: Array<any>;
}

class DummyContainer extends React.Component<IDummyContainerProps, IDummyContainerState>  {
    constructor(props: IDummyContainerProps) {
        super(props);

        this.state = {
            textValue: '',
            dummyList: []
        }

        this.updateState = this.updateState.bind(this);
        this.goToNextPage = this.goToNextPage.bind(this);
    }

    private loadDummyList() {
        this.props.actions.dummyListAction()
            .then(() => {
                responseInterceptor(this.props.dummyResult, (data) => {
                    console.log('Here is the successful dummy List ', data);
                    this.setState({ dummyList: data }, () => {
                        console.log('we successfully set the state in an async manner ')
                    });
                }, (error) => {
                    console.log("Something went wrong, we cant get dummy List", error);
                }, this.props.history);
            });
    }

    updateState(event: any): void { this.setState({ textValue: event.target.value }) }
    goToNextPage(): void { navigate(this.props.history, 'dummy2') }
    componentDidMount(): void { this.loadDummyList() }

    render() {
        let lang = this.props.language.dummyPage;
        return (
            <div className="dummy-container">
                <div className="image-holder">
                    <img className="image" src={testImg} />
                </div>
                <div>
                    <div>{lang.header}</div> <br />
                    DummyContainer is running with multiple type of bindings.
                    Here i gonna render a prop from my parent route: <b> {this.props.example}</b>
                    <br />
                    direct binding: {this.state.textValue}
                </div>
                <div>
                    here we change langauges which effect everywhere in app:<br />
                    <span onClick={() => { this.props.changeLanguage('en') }}>Click on EN</span> <br />
                    <span onClick={() => { this.props.changeLanguage('dk') }}>Click on DK</span> <br />
                    <span onClick={() => { this.props.changeLanguage('sw') }}>Click on SW</span><br />
                </div>

                <TextInput
                    name="textValue"
                    className="custom-input"
                    value={this.state.textValue}
                    onChange={this.updateState} />

                <Button
                    label="Go To Next Page"
                    onClick={this.goToNextPage} />


                <br />

                here we gonna have a list which simulate API call:
                <ul>
                    {this.state.dummyList && this.state.dummyList.length > 0 &&
                        this.state.dummyList.map((item, index) =>
                            <li key={index}>
                                <div className="values">{item.name}</div>
                            </li>
                        )}
                </ul>

            </div>
        );
    }
}

function mapStateToProps(state, ownProps) {
    return {
        dummyResult: state.dummyResponse
    };
}

function mapDispatchToProps(dispatch) {
    return {
        actions: bindActionCreators(dummyActions as any, dispatch)
    };
}

export default withRouter(connect(mapStateToProps, mapDispatchToProps)(DummyContainer));
