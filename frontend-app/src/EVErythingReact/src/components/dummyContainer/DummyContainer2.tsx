import * as React from 'react';
import { withRouter } from 'react-router-dom';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import { Bar } from 'react-chartjs-2';

export interface IDummyContainer2Props {
    example: string
}

export interface IDummyContainer2State {
    textValue: string;
    data: any;
    options: any;
}

class DummyContainer2 extends React.Component<IDummyContainer2Props, IDummyContainer2State>  {
    constructor(props: IDummyContainer2Props) {
        super(props);

        this.state = {
            textValue: '',
            data: {
                labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'],
                datasets: [
                    {
                        label: 'My First dataset',
                        backgroundColor: 'rgba(255,99,132,0.2)',
                        borderColor: 'rgba(255,99,132,1)',
                        borderWidth: 1,
                        hoverBackgroundColor: 'rgba(255,99,132,0.4)',
                        hoverBorderColor: 'rgba(255,99,132,1)',
                        data: [65, 59, 80, 81, 56, 55, 40]
                    }
                ]
            },
            options: {
                maintainAspectRatio: false,
                legend: {
                    position: 'bottom',
                    labels: { padding: 15 }
                },
                scales: {
                    xAxes: [{
                        stacked: false,
                    }],
                    yAxes: [{
                        stacked: false,
                        ticks: {
                            beginAtZero: true,
                            callback: function (value: any, index: any, values: any[]) { return value + ' kr.'; }
                        }
                    }]
                }

            }
        }

        this.updateState = this.updateState.bind(this);
    }

    updateState(event: any) {
        this.setState({ textValue: event.target.value })
    }

    render() {
        return (
            <div className="dummy-container">
                <div>
                    DummyContainer 2 is running.
                    Here i gonna render a prop from my parent route: <b> {this.props.example}</b>
                </div>
                <br /><br />
                <h2>Bar chart sample based on react-chartjs-2 which is a wrapper around CHART.js</h2>
                <div className="bar-holder">
                    <Bar
                        data={this.state.data}
                        options={this.state.options}/>
                </div>

            </div>
        );
    }
}

function mapStateToProps(state, ownProps) {
    return {
    };
}

export default withRouter(connect(mapStateToProps)(DummyContainer2));
