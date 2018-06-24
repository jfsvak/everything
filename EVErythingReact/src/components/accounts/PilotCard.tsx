import * as React from 'react';
// 

export interface IPilotCardProps {
    pilot: any;
}

class PilotCard extends React.Component<IPilotCardProps> {
    render() {
        return (
            <span>{this.props.pilot}</span>
        );
    }
}

export default PilotCard;