import * as React from 'react';

export interface IPilotCardProps {
    pilot: any;
}

class PilotCard extends React.Component<IPilotCardProps> {
    render() {
        return (
            <div className="pilot-card">
                <p>id: {this.props.pilot.id}</p>
                <p>Name: {this.props.pilot.name}</p>
            </div>
        );
    }
}

export default PilotCard;