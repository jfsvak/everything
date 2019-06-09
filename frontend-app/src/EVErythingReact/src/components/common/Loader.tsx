import * as React from 'react'

export interface ILoaderProps {
    callsInProgress: number;
}

const Loader: React.StatelessComponent<ILoaderProps> = (prop: ILoaderProps) => {
    return (
        <div>
            {prop.callsInProgress > 0 &&
                <div className="loader-holder">
                    <div className="loader"></div>
                </div>
            }
        </div>

    )
};

export default Loader;
