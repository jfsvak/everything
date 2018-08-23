import * as React from 'react';

export interface ICharacterOverviewBarProps {
    character: any;
}

function CharacterOverviewBar(props: ICharacterOverviewBarProps) {
    return (
            <div className="card mb-2 p-1">
                <div className="card-header p-1" id={"character_" + props.character.id + "_header"}>
                    <a data-toggle="collapse" data-target={"#character_"+ props.character.id + "_collapse"}>

                        <div className="d-flex justify-content-start">
                            <div className="m-2">
                                <img src={"https://image.eveonline.com/Character/" + props.character.id + "_64.jpg"}/>
                            </div>
                            <div>
                                <p>{props.character.name}</p>
                                <p>Wallet: 100.982.000,00 isk</p>
                                <p>SP: 145.673</p>
                            </div>
                            <a href="#" className="ml-auto"><i className="fas fa-trash-alt"></i></a>
                        </div>
                    </a>
                </div>

                <div id={"character_" + props.character.id + "_collapse"} className="collapse" aria-labelledby={"character_" + props.character.id + "_header"} data-parent="characterCards">
                    <div className="card-body p-1">
                        <p>bunch of content</p>
                        <p>bunch of content</p>
                        <p>bunch of content</p>
                        <p>bunch of content</p>
                        <p>bunch of content</p>
                        <p>bunch of content</p>
                        <p>bunch of content</p>
                        <p>bunch of content</p>
                        <p>bunch of content</p>
                    </div>
                </div>
            </div>
    );
}

export default CharacterOverviewBar;