import * as React from 'react';

export interface ICharacterOverviewBarProps {
    character: any;
}

function CharacterOverviewBar(props: ICharacterOverviewBarProps) {
    return (
            <div className="card mb-2 p-1 text-white bg-dark">
                <div className="card-header p-1" id={"character_" + props.character.id + "_header"}>
                    <a data-toggle="collapse" data-target={"#character_"+ props.character.id + "_collapse"}>

                        <div className="d-flex justify-content-start">
                            <div className="m-2">
                                <img src={"https://image.eveonline.com/Character/" + props.character.id + "_64.jpg"}/>
                            </div>
                            <div>
                                <p className="">{props.character.name}</p>
                                <p>Wallet: 100.982.000,00 isk</p>
                                <p>SP: 145.673</p>
                            </div>
                            <div className="ml-auto">
                                <a href="#" className="ml-auto mt-1 mr-2"><i className="fas fa-trash-alt"></i></a>
                                <a href="#" className="ml-auto mt-1 mr-2"><i className="fas fa-sync-alt"></i></a>
                            </div>
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