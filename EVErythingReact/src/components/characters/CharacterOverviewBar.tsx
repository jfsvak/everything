import * as React from 'react';

export interface ICharacterOverviewBarProps {
    character: any;
}

function CharacterOverviewBar(props: ICharacterOverviewBarProps) {
    return (
            <div className="card mb-3">
                <div className="card-body">
                    <img src={"https://image.eveonline.com/Character/" + props.character.id + "_64.jpg"}/>{props.character.name}
                    <button type="button" className="btn btn-warning btn-sm">Remove</button>
                </div>
            </div>
    );
}

export default CharacterOverviewBar;