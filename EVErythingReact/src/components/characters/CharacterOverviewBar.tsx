import * as React from 'react';

export interface ICharacterOverviewBarProps {
    character: any;
    removeCharacter?: Function;
    refresh?: Function;
}

function CharacterOverviewBar(props: ICharacterOverviewBarProps) {
    return (
        <div className="card mb-2 p-1 text-white bg-dark">
            <div className="card-header p-1" id={"character_" + props.character.id + "_header"}>
                <div className="d-flex justify-content-start">
                    <div className="m-2">
                        <img className="avatar" src={"https://image.eveonline.com/Character/" + props.character.id + "_64.jpg"}/>
                    </div>
                    <div>
                        <p className="card-title">{props.character.name}</p>
                        <p>Wallet: 100.982.000,00 isk</p>
                        <p>SP: 145.673</p>
                    </div>
                    <div className="ml-auto">
                        {/* <div className="d-inline mt-1 mr-2" onClick={props.removeCharacter} data-item={props.character.id}><i className="fas fa-trash-alt"></i></div> */}
                        {/* <button className="card-link mt-1 mr-2 fas fa-trash-alt" onClick={props.removeCharacter}></button> */}
                        <div className="pointer d-inline mt-1 mr-2" onClick={(event) => props.removeCharacter(props.character.id)}><i className="fas fa-trash-alt"></i></div>
                        <div className="pointer d-inline ml-auto mt-1 mr-2" onClick={(event) => props.refresh(props.character.id)}><i className="fas fa-sync-alt"></i></div>
                    </div>
                </div>
                <div className="d-flex justify-content-end">
                    <a href="" data-toggle="collapse" data-target={"#character_"+ props.character.id + "_collapse"}>
                        <i className="fas fa-angle-down"></i>
                    </a>
                </div>
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