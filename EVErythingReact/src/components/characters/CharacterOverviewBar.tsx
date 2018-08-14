import * as React from 'react';

export interface ICharacterOverviewBarProps {
    character: any;
}

function CharacterOverviewBar(props: ICharacterOverviewBarProps) {
    return (
        <div className="container-fluid">
            <img src="https://image.eveonline.com/Character/2113547503_64.jpg"/>{props.character.name}
        </div>
    );
}

export default CharacterOverviewBar;