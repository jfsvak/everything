import * as React from 'react';

export interface ICheckBoxProps {
    id: string;
    name?: string;
    defaultChecked?: boolean;
    onChange: (event: any) => void;
    className?: string;
    label: string;
    topLabel?: string;
    disabled?: boolean;
    error?: string;
}

const CheckBox: React.StatelessComponent<ICheckBoxProps> = (prop: ICheckBoxProps) => {
    return (
        <div className={"input-field " + (prop.className ? prop.className : "")}>
            {prop.topLabel && <label htmlFor={prop.name}>{prop.topLabel}</label>}

            <div className="custom-control custom-checkbox">
                <input
                    type="checkbox"
                    className="custom-control-input"
                    disabled={prop.disabled}
                    onChange={prop.onChange}
                    defaultChecked={prop.defaultChecked}
                    id={prop.id} />
                <label className="custom-control-label" htmlFor={prop.id}></label>
                {prop.label && <span className="checkbox-label">{prop.label}</span>}
            </div>

        </div>
    );
};

export default CheckBox;
