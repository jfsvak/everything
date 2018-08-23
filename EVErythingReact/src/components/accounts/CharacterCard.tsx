import * as React from 'react';

export interface ICharacterCardProps {
    character: any;
}

class CharacterCard extends React.Component<ICharacterCardProps> {
    render() {
        return (
            <div className="card d-inline">
                <p>id: {this.props.character.id}</p>
                <p>Name: {this.props.character.name}</p>
            </div>
        );
    }
}

export default CharacterCard;