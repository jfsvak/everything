import * as React from 'react';
// 

export interface IPilotCardProps {
    pilot: any;
}

class PilotCard extends React.Component<IPilotCardProps> {
    render() {
        return (
            <span className="card" style={{width: "6rem"}}>{this.props.pilot}</span>
        );
    }
}

export default PilotCard;